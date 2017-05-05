using AspNet.Identity.SQLite;

namespace IdentityServer.AuthorizationProvider.NetIdentity
{
    public class UsersContext : SQLiteDatabase
    {
        public UsersContext(string connectionName)
            : base(connectionName)
        {
        }
    }
}