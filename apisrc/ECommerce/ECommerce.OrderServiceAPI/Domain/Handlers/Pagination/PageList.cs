namespace ECommerce.OrderServiceAPI.Domain.Handlers.Pagination;

public class PageList<TEntity>
{
    public List<TEntity> Result { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public PageList() { }

    public PageList(List<TEntity> items, int count, int pageNumber, int pageSize)
    {
        this.Result = new List<TEntity>();

        this.TotalCount = count;
        this.PageSize = pageSize;
        this.CurrentPage = pageNumber;
        this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        this.Result.AddRange(items);
    }
}
