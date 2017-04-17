using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IdentityServer.Data.Contexts;
using IdentityServer.Data.Models;

namespace IdentityServer.Data.Repositories
{
    public class RolesRepository : IDisposable
    {
        private readonly DataContext _ctx;

        public RolesRepository()
        {
            _ctx = new DataContext();
        }

        public IEnumerable<Role> GetClientRoles(int clientId)
        {
            return _ctx.Roles.Where(a => a.Client.Id == clientId);
        }

        public void Add(Role role)
        {
            //TODO Check possibility of dublicates.
            _ctx.Entry(role).State = EntityState.Added;
            _ctx.SaveChanges();
        }

        public void Update(Role role)
        {
            _ctx.Entry(role).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            _ctx.Entry(new Role() { Id = id }).State = EntityState.Deleted;
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
