namespace MaxioAdvancedBilling.Core.Pagination;

internal sealed record OffsetState(int Offset, int Limit);

internal sealed record CursorState(string? Cursor, int Limit);

internal sealed record LinkState(string NextLink);
