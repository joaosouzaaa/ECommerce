using Microsoft.AspNetCore.Identity;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Entities;

public class Role : IdentityRole
{
    public List<User> Users { get; set; }
}
