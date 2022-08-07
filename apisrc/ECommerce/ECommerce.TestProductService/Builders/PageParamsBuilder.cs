using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;

namespace ECommerce.TestProductService.Builders
{
    public class PageParamsBuilder
    {
        private string _indexDescription = string.Empty;
        private int _pageNumber = 1;
        private int _pageSize = 2;

        public static PageParamsBuilder NewObject()
        {
            return new PageParamsBuilder();
        }

        public PageParams DomainBuild()
        {
            return new PageParams
            {
                PageNumber = _pageNumber,
                PageSize = _pageSize,
                IndexDescription = _indexDescription
            };
        }
    }
}
