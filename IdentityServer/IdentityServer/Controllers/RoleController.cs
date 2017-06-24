using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using IdentityServer.Data.Repositories;
using IdentityServer.Models;

namespace IdentityServer.Controllers
{
    [RoutePrefix("role")]

    #if RELEASE
    [Authorize]
    #endif
    public class RoleController : ApiController
    {
        private readonly RolesRepository _roleRepo;
        public RoleController()
        {
            _roleRepo = new RolesRepository();
        }

        public async Task<IHttpActionResult> Get(int clientId)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);
            var result = await _roleRepo.GetClientRoles(clientId);
            return Ok(result.Select(role => new RoleDTO(role)));
        }

        public async Task<IHttpActionResult> Post(RoleDTO role)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            var roleModel = role.ToModel();
            await _roleRepo.Add(roleModel);

            return Ok();
        }

        public async Task<IHttpActionResult> Put(RoleDTO role)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);
            var roleModel = role.ToModel();
            await _roleRepo.Update(roleModel);

            return Ok();
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            await _roleRepo.Delete(id);
            return Ok();
        }
    }
}