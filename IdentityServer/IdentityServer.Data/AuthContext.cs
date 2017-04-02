using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityServer.Data
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {
        }
    }
}