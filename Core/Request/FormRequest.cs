using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Core.Request;

internal sealed class FormRequest : IRequest
{
    private readonly IReadOnlyCollection<Param> _params;

    private FormRequest(IReadOnlyCollection<Param> @params) => _params = @params;

    public HttpContent Get()
    {
        var multipart = new MultipartFormDataContent();
        foreach (var kv in _params) AddToMultipart(multipart, kv.Key, kv.Value);
        return multipart;
    }

    public bool CanRetry => false;

    public static FormRequest Create(IReadOnlyCollection<Param> @params) => new(@params);

    #region Helpers

    private static bool IsSimpleType(Type t) =>
        t.IsPrimitive
        || t.IsEnum
        || t == typeof(string)
        || t == typeof(decimal)
        || t == typeof(DateTime)
        || t == typeof(DateTimeOffset)
        || t == typeof(Guid)
        || t == typeof(TimeSpan);

    private static void AddToMultipart(MultipartFormDataContent multipart, string name, object? value)
    {
        if (value == null)
        {
            multipart.Add(new StringContent(string.Empty), name);
            return;
        }

        if (IsFileLike(value, out var fileBytes, out var fileStream, out var fileName, out var contentType))
        {
            HttpContent fileContent;
            if (fileBytes != null)
                fileContent = new ByteArrayContent(fileBytes);
            else
                fileContent = new StreamContent(fileStream!);

            if (!string.IsNullOrEmpty(contentType))
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            // Add content disposition
            var disposition = new ContentDispositionHeaderValue("form-data") { Name = $"\"{name}\"" };
            if (!string.IsNullOrEmpty(fileName))
                disposition.FileName = $"\"{fileName}\"";
            fileContent.Headers.ContentDisposition = disposition;

            multipart.Add(fileContent, name, fileName ?? "file");
            return;
        }

        // Strings should be plain StringContent
        if (value is string str)
        {
            multipart.Add(new StringContent(str), name);
            return;
        }

        // IEnumerable -> add each element as repeated field
        if (value is IEnumerable enumerable and not byte[])
        {
            foreach (var item in enumerable) AddToMultipart(multipart, name, item);

            return;
        }

        var type = value.GetType();

        if (IsSimpleType(type))
        {
            multipart.Add(new StringContent(ConvertToString(value)), name);
            return;
        }

        // Complex object -> flatten properties as name.child
        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.GetIndexParameters().Length == 0 && p.CanRead);

        var hadProps = false;
        foreach (var p in props)
        {
            hadProps = true;
            AddToMultipart(multipart, $"{name}.{p.Name}", p.GetValue(value));
        }

        if (!hadProps)
            // fallback
            multipart.Add(new StringContent(ConvertToString(value)), name);
    }

    /// <summary>
    ///     Detects file-like objects and extracts a stream or bytes, filename and content-type where possible.
    ///     Supports: byte[], Stream, FileInfo, types with "OpenReadStream"/"FileName" (IFormFile-like), and HttpContent.
    ///     Returns true when a file-like object is found. When returning a stream, caller is responsible for disposal when
    ///     content is disposed.
    /// </summary>
    private static bool IsFileLike(object value, out byte[]? bytes, out Stream? stream, out string? fileName,
        out string? contentType)
    {
        bytes = null;
        stream = null;
        fileName = null;
        contentType = null;

        if (value is byte[] b)
        {
            bytes = b;
            fileName = "file";
            return true;
        }

        if (value is Stream s)
        {
            stream = s;
            fileName = "file";
            return true;
        }

        if (value is FileInfo fi)
        {
            stream = fi.OpenRead();
            fileName = fi.Name;
            contentType = GetMimeFromFileName(fi.Name);
            return true;
        }

        // HttpContent (already a content object): wrap it
        if (value is HttpContent hc)
        {
            // Attempt to get filename from headers
            fileName = hc.Headers.ContentDisposition?.FileName?.Trim('"') ?? "file";
            contentType = hc.Headers.ContentType?.MediaType;
            // We cannot extract bytes/stream easily here - caller can add the HttpContent directly instead
            // But for uniformity, treat as file: the AddToMultipart path will add it as-is if it's already HttpContent.
            return true;
        }

        // Look for typical IFormFile-like shape using reflection (ASP.NET Core)
        var t = value.GetType();
        var openReadMethod = t.GetMethod("OpenReadStream", BindingFlags.Instance | BindingFlags.Public);
        var fileNameProp = t.GetProperty("FileName", BindingFlags.Instance | BindingFlags.Public);
        //var lengthProp = t.GetProperty("Length", BindingFlags.Instance | BindingFlags.Public);
        var contentTypeProp = t.GetProperty("ContentType", BindingFlags.Instance | BindingFlags.Public);

        if (openReadMethod != null && fileNameProp != null)
            try
            {
                var opened = openReadMethod.Invoke(value, []);
                if (opened is Stream st)
                {
                    stream = st;
                    fileName = fileNameProp.GetValue(value)?.ToString() ?? "file";
                    contentType = contentTypeProp?.GetValue(value)?.ToString();
                    return true;
                }
            }
            catch
            {
                // ignore reflection errors and continue
            }

        // Some types may carry RawBytes property or Data
        var bytesProp = t.GetProperty("Content", BindingFlags.Instance | BindingFlags.Public) ??
                        t.GetProperty("Bytes", BindingFlags.Instance | BindingFlags.Public) ??
                        t.GetProperty("RawBytes", BindingFlags.Instance | BindingFlags.Public);

        if (bytesProp != null && bytesProp.PropertyType == typeof(byte[]))
            try
            {
                bytes = (byte[])bytesProp.GetValue(value)!;
                fileName = t.GetProperty("Name")?.GetValue(value)?.ToString() ?? "file";
                return true;
            }
            catch
            {
                /* ignore */
            }

        return false;
    }

    private static string ConvertToString(object? value)
    {
        if (value == null) return string.Empty;
        return value switch
        {
            DateTime dt => dt.ToString("o", CultureInfo.InvariantCulture),
            DateTimeOffset dto => dto.ToString("o", CultureInfo.InvariantCulture),
            bool b => b ? "true" : "false",
            _ => Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty
        };
    }

    private static string GetMimeFromFileName(string? fileName)
    {
        if (string.IsNullOrEmpty(fileName)) return "application/octet-stream";
        var ext = Path.GetExtension(fileName).ToLowerInvariant();
        return ext switch
        {
            ".txt" => "text/plain",
            ".json" => "application/json",
            ".xml" => "application/xml",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".pdf" => "application/pdf",
            _ => "application/octet-stream"
        };
    }

    #endregion
}