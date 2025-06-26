namespace Threadnos_API.Application.Contracts
{
    public class PagedResult<T>
    {        
        public IReadOnlyList<T>? Items { get; init; }
        public int TotalCount { get; init; }
        public int PageIndex { get; init; }
        public int PageSize { get; init; }


        public PagedResult(IReadOnlyList<T>? items, int totalCount, int pageIndex = 1, int pageSize = 10)
        {            
            Items = items;
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
