using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using IdentityServer.Data.Models;
using IdentityServer.Data.Repositories;
using IdentityServer.Models;

namespace IdentityServer.Controllers
{
    [RoutePrefix("client")]
    [Authorize]
    public class ClientController : ApiController
    {
        private ClientsRepository _repository;

        public ClientController()
        {
            _repository = new ClientsRepository();
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            var result = _repository.Get(id);
            return Ok( result );
        }

        public async Task<IHttpActionResult> Get()
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            var clients = await _repository.List();
            return Ok(clients);
        }

        public async Task<IHttpActionResult> Post(IdentityServer.Data.Models.Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(client);
            return Ok();
        }

        public async Task<IHttpActionResult> Put(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Update(client);
            return Ok();
        }

      
      
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Remove(id);
            return Ok();
        }

    }
}