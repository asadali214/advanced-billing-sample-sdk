using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Core;

internal sealed class TemplateParamsFactory
{
    private readonly IReadOnlyCollection<TemplateParam> _defaultParams;

    public TemplateParamsFactory(IReadOnlyCollection<TemplateParam> defaultParams) => _defaultParams = defaultParams;

    public string Create(UrlTemplate urlTemplate, IReadOnlyCollection<TemplateParam> templateParams)
    {
        var baseUrl = ExpandTemplate(urlTemplate.BaseUrl, urlTemplate.Variables);
        var path = ExpandTemplate(urlTemplate.Path, templateParams.Concat(_defaultParams));
        return $"{baseUrl.TrimEnd('/')}/{path.TrimStart('/')}";
    }

    private static string ExpandTemplate(string template, IEnumerable<TemplateParam> parameters)
    {
        foreach (var (key, value) in parameters)
        {
            var replacement = value is IEnumerable enumerable and not string
                ? string.Join("/", enumerable.Cast<object?>().Select(Encode))
                : Encode(value);
            template = template.Replace($"{{{key}}}", replacement);
        }

        return template;

        static string Encode(object? v) => Uri.EscapeDataString(v?.ToString() ?? string.Empty);
    }
}