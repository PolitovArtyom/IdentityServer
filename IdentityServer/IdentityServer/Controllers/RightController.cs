using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using IdentityServer.AuthorizationProvider;
using IdentityServer.Models;

namespace IdentityServer.Controllers
{
    [RoutePrefix("right")]
    #if RELEASE
    [Authorize]
    #endif
    public class RightController : ApiController
    {
        //TODO implement validation attribute and put model validation code there
        private readonly IAuthorisationProvider _provider;
        public RightController(IAuthorisationProvider provider)
        {
            _provider = provider;
        }

        public async Task<IHttpActionResult> Get()
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            var result = await _provider.GetAllRights();
            
            return Ok(result.Select(role => new ProviderRightDTO(role)));
        }

        public async Task<IHttpActionResult> Get(string id)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            var rights = await _provider.GetAllRights();
            var result = rights.FirstOrDefault(r => r.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (result == null)
                return NotFound();

            return Ok(new ProviderRightDTO(result));
        }

        public async Task<IHttpActionResult> Post(ProviderRightDTO model)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            var rights = await _provider.GetAllRights();
            var result = rights.Where(r => r.Name.Contains(model.Name));

            return Ok(result.Select(role => new ProviderRightDTO(role)));
        }
    }
}
