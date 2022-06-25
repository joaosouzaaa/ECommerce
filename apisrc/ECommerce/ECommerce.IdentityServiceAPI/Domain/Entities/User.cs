using Microsoft.AspNetCore.Identity;

namespace ECommerce.IdentityServiceAPI.Domain.Entities;

public class User : IdentityUser
{
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public List<Role> Roles { get; set; }
}
