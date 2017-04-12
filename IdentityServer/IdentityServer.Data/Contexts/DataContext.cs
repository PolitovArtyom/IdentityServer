using System.Data.Entity;
using IdentityServer.Data.Models;

namespace IdentityServer.Data.Contexts
{
    internal class DataContext : DbContext
    {
        public DataContext() : base("DbContext")
        {
        
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}
