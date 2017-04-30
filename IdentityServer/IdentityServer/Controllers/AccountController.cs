using System.Threading.Tasks;
using System.Web.Http;
using IdentityServer.AuthorizationProvider;
using IdentityServer.Models;

namespace IdentityServer.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : ApiController
    {
        private IRegistrationProvider _provider = null;

        public AccountController(IRegistrationProvider provider)
        {
            _provider = provider;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> Register(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_provider == null)
            {
                return BadRequest("Proivder doesn't support registration");
            }

            var result = await _provider.Register(user.UserName, user.Password);

           
            if (result.Success == false)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}