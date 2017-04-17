using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using IdentityServer.Data.Repositories;
using IdentityServer.Models;

namespace IdentityServer.Controllers
{
    [RoutePrefix("client")]
    //  [Authorize]
    public class ClientController : ApiController
    {
        private readonly ClientsRepository _repository;

        public ClientController()
        {
            _repository = new ClientsRepository();
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            var client = _repository.Get(id);

            return Ok(new ClientDTO(client));
        }

        public async Task<IHttpActionResult> Get()
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            var clients = await _repository.List();
            return Ok(clients.Select(client => new ClientDTO(client)));
        }

        public async Task<IHttpActionResult> Post(ClientDTO client)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            _repository.Add(client.ToModel());
            return Ok();
        }

        public async Task<IHttpActionResult> Put(ClientDTO client)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            _repository.Update(client.ToModel());
            return Ok();
        }


        public async Task<IHttpActionResult> Delete(int id)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            _repository.Delete(id);
            return Ok();
        }
    }
}