namespace ECommerce.PaymentServiceAPI.Domain.Handlers.Pagination;

public class PageParams
{
    private const int MaxPageSize = 10;
    public string IndexDescription { get; set; } = string.Empty;
    public int pageNumber = 1;
    public int pageSize = 2;


    public int PageSize
    {
        get { return pageSize; }
        set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
    }

    public int PageNumber
    {
        get { return pageNumber; }
        set { pageNumber = (value <= 0) ? pageNumber : value; }
    }

}
