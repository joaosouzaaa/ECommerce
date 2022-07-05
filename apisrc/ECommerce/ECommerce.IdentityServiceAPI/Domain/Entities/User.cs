using Microsoft.AspNetCore.Identity;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public List<Role> Roles { get; set; }
}
