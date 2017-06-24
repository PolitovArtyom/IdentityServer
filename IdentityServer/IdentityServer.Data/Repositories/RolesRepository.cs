using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IQueryable<Role>> GetClientRoles(int clientId)
        {
            return _ctx.Roles.Where(a => a.Client.Id == clientId);
        }

        public async Task Add(Role role)
        {
           bool isUniqueRoleName = await IsUniqueRoleName(role.Name, role.ClientId);
           if (isUniqueRoleName == false)
                throw new DuplicateNameException($"Role with name {role.Name} already exisits for client {role.Client.Name}");
           
            _ctx.Entry(role).State = EntityState.Added;
            await _ctx.SaveChangesAsync();
        }

        public async Task Update(Role role)
        {
            _ctx.Entry(role).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _ctx.Entry(new Role() { Id = id }).State = EntityState.Deleted;
            await _ctx.SaveChangesAsync();
        }

        private async Task<bool> IsUniqueRoleName(string name, int clientId)
        {
            var clientRoles = await GetClientRoles(clientId);
            return await clientRoles.AnyAsync(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
