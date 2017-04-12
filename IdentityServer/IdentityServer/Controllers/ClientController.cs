using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using IdentityServer.Data.Models;
using IdentityServer.Data.Repositories;

namespace IdentityServer.Controllers
{
    [RoutePrefix("client")]
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
            return Ok(new List<Client>() { result });
        }

        public async Task<IHttpActionResult> Get()
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            var clients = await _repository.List();
            return Ok(clients);
        }

        public async Task<IHttpActionResult> Post(Client client)
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

      
      
        public async Task<IHttpActionResult> Delete(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Remove(client);
            return Ok();
        }

    }
}