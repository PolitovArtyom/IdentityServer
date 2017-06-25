using System.Data.Entity;
using IdentityServer.Data.Models;
using SQLite.CodeFirst;

namespace IdentityServer.Data.Contexts
{
    internal class DataContext : DbContext
    {
        public DataContext() : base("IdentityServer")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<DataContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<ProviderRight> ResourceRights { get; set; }

        public DbSet<AuthorisationResource> Resources { get; set; }
    }
}
