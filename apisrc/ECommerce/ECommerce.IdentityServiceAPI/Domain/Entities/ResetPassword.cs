namespace ECommerce.IdentityServiceAPI.Domain.Entities
{
    public class ResetPassword
    {
        public string Token { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
