namespace Threadnos_API.Application.Contracts
{
    public class PagedResult<T>
    {
        public int PageIndex { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public int TotalCount { get; init; }
        public IReadOnlyList<T>? Items { get; init; }
    }
}
