namespace ECommerce.CouponServiceAPI.Domain.Entities;

public class Coupon : BaseEntity
{
    public string CouponCode { get; set; }
    public decimal DiscountAmount { get; set; }
}
