using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using IdentityServer.Data.Contexts;
using IdentityServer.Data.Models;

namespace IdentityServer.Data.Repositories
{
    public class ClientsRepository : IDisposable
    {
        private DataContext _ctx;

        public ClientsRepository()
        {
            _ctx = new DataContext();
        }

        public async Task<IEnumerable<Client>> List()
        {
            return await _ctx.Clients.ToListAsync();
        }

        public  Client Get(int id)
        {
            return  _ctx.Clients.Find(id);
        }

        public void Add(Client client)
        {
            try
            {
                _ctx.Entry(client).State = EntityState.Added;
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw;
            }
           
        }

        public void Update(Client client)
        {
            if(client == null)
                throw new ArgumentNullException(nameof(client));
            _ctx.Entry(client).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Remove(Client client)
        {
            _ctx.Entry(client).State = EntityState.Deleted;
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
