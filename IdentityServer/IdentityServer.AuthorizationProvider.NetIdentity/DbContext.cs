using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityServer.AuthorizationProvider.NetIdenity
{
    public class UsersContext : IdentityDbContext<IdentityUser>
    {
        public UsersContext(string connectionName)
            : base(connectionName)
        {
        }
    }
}