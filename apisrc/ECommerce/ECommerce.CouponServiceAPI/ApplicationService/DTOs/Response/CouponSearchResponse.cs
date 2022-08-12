namespace ECommerce.CouponServiceAPI.ApplicationService.DTOs.Response
{
    public class CouponSearchResponse
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
