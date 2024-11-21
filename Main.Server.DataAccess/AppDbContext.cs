using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Main.Server.Core.Entities.ProductEntities;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
namespace Main.Server.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}


