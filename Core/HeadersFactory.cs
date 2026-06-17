using System.Collections.Generic;
using System.Linq;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Core;

internal sealed class HeadersFactory
{
    private readonly IReadOnlyCollection<HeaderParam> _defaultHeaders;

    public HeadersFactory(IReadOnlyCollection<HeaderParam> defaultHeaders) =>
        _defaultHeaders = defaultHeaders;

    public IReadOnlyCollection<HeaderParam> Create(IReadOnlyCollection<HeaderParam> headerParameters) =>
        _defaultHeaders.Concat(headerParameters).ToList();
}