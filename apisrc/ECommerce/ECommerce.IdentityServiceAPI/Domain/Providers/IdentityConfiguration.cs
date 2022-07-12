using IdentityServer4;
using IdentityServer4.Models;

namespace ECommerce.IdentityServiceAPI.Domain.Providers;

public class IdentityConfiguration
{
    public const string Admin = "Admin";
    public const string Client = "Client";


    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("ecommerce", "Ecommerce Server"),
            new ApiScope(name: "read", "Read data."),
            new ApiScope(name: "write", "Write data."),
            new ApiScope(name: "delete", "Delete data.")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientSecrets = {new Secret("My_Super_Secret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"read", "write", "profile"}
            },
            new Client
            {
                ClientId = "ecommerce",
                ClientSecrets = {new Secret("My_Super_Secret".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = {"URLs SignIn Client side"},
                PostLogoutRedirectUris = { "URLs SignOut Client side" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "ecommerce"
                }
            },
        };
}
