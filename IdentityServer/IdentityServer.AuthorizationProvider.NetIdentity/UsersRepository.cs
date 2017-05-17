using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using AspNet.Identity.SQLite;


namespace IdentityServer.AuthorizationProvider.NetIdentity
{
    public class UsersRepository : IDisposable
    {
        private UsersContext _ctx;
        private UserManager<IdentityUser> _userManager;

        public UsersRepository(string connectionName)
        {
            _ctx = new UsersContext(connectionName);
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser, IdentityRole>(_ctx));
            //  _userManager = new UserManager<IdentityUser>(_ctx);
        }

        public async Task<IdentityResult> RegisterUser(string login, string password)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = login
            };

            var result = await _userManager.CreateAsync(user, password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
