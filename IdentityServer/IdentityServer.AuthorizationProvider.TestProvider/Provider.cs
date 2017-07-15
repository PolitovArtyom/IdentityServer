using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.AuthorizationProvider.TestProvider.Models;

namespace IdentityServer.AuthorizationProvider.TestProvider
{
    public class Provider : IRegistrationProvider
    {
        private IDictionary<string, string> _params;
        private ILogger _log;
        private DbContext _dbContext;
        public void Initialize(IDictionary<string, string> parameters, ILogger log)
        {
            _log = log;
            _params = parameters;
            _dbContext = new DbContext(_params["ConnectionString"]);
        }

        public async Task<Result> Authorize(string user, string password)
        {
            User account = await _dbContext.GetUser(user);
            if (account == null)
            {
                return new Result()
                {
                    Success = false,
                    Message = $"User {user} not registered"
                };
            }
              

            bool isAuthentificated = PasswordManager.CheckPassword(password, account.PasswordHash);
            if (isAuthentificated == false)
            {
                return new Result()
                {
                    Success = true,
                    Message = "Wrong password"
                };
            }

            var userRoles = await _dbContext.GetUserRoles(account.Id);

            return new Result()
            {
                Success = true,
                Rights = userRoles.Select(r => new Right()
                {
                    Id = r.Id.ToString(),
                    Name = r.Name, 
                    Issuer = "TestProvider"
                })
            };

        }

        public async Task<IEnumerable<Right>> GetAllRights()
        {
            var roles = await _dbContext.GetAllRoles();
            return roles.Select(r => new Right()
            {
                Id = r.Id.ToString(),
                Name = r.Name,
                Issuer = "TestProvider"
            });
        }

        public async Task<Right> GetRight(string id)
        {
            var role = await _dbContext.GetRole(id);
            return new Right()
            {
                Id = role.Id.ToString(),
                Name = role.Name,
                Issuer = "TestProvider"
            };
        }

        public async Task<Result> Register(string user, string password)
        {
            if(await _dbContext.GetUser(user) != null)
                return new Result()
                {
                    Success = false,
                    Message = $"User with login {user} already exists"
                };    

            var passwordHash = PasswordManager.GetHash(password);
            var allRoles = await _dbContext.GetAllRoles();
            await _dbContext.AddUser(user, passwordHash, allRoles);
            return new Result()
            {
                Success = true
            };
        }

        public void Dispose()
        {
        }
    }
}
