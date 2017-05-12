using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Data.Contexts;
using IdentityServer.Data.Models;

namespace IdentityServer.Data.Repositories
{
    public class ClientsRepository : IDisposable
    {
        private readonly DataContext _ctx;

        public ClientsRepository()
        {
            _ctx = new DataContext();
        }

        public async Task<IEnumerable<Client>> List()
        {
            return await _ctx.Clients.ToListAsync();
        }

        public Client Get(int id)
        {
            return _ctx.Clients.Find(id);
        }

        public Client Get(string identifier)
        {
            return _ctx.Clients.SingleOrDefault(c => c.Identifier.Equals(identifier, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(Client client)
        {
            if (_ctx.Clients.Any(a => a.Identifier.Equals(client.Identifier, StringComparison.OrdinalIgnoreCase)))
                throw new ApplicationException($"Client with identifier {client.Identifier} already exists");
            _ctx.Entry(client).State = EntityState.Added;
            _ctx.SaveChanges();
        }

        public void Update(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            _ctx.Entry(client).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            _ctx.Entry(new Client {Id = id}).State = EntityState.Deleted;
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
