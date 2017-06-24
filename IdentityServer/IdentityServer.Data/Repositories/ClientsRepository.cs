using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

        public Task<Client> Get(int id)
        {
            return _ctx.Clients.FindAsync(id);
        }

        public Task<Client> Get(string identifier)
        {
            return
                _ctx.Clients.SingleOrDefaultAsync(
                    c => c.Identifier.Equals(identifier, StringComparison.OrdinalIgnoreCase));
        }

        public async Task Add(Client client)
        {
            if ( await _ctx.Clients.AnyAsync(a => a.Identifier.Equals(client.Identifier, StringComparison.OrdinalIgnoreCase)))
                 throw new DuplicateNameException($"Client with identifier {client.Identifier} already exists");
            _ctx.Entry(client).State = EntityState.Added;
           await _ctx.SaveChangesAsync();
        }

        public async Task Update(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            _ctx.Entry(client).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _ctx.Entry(new Client {Id = id}).State = EntityState.Deleted;
            await _ctx.SaveChangesAsync();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
