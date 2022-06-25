using Microsoft.AspNetCore.Identity;

namespace ECommerce.IdentityServiceAPI.Domain.Entities
{
    public class Role : IdentityRole
    {
        public List<User> Users { get; set; }
    }
}
