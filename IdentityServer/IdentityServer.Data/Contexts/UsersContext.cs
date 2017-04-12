using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityServer.Data.Contexts
{
    public class UsersContext : IdentityDbContext<IdentityUser>
    {
        public UsersContext()
            : base("DbContext")
        {
        }
    }
}