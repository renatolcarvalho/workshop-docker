using Example.Domain.Models;
using Example.Infra.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Example.Infra.Repository.Context
{
    public class ClientManagementContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        private readonly string _connectionString;
        public ClientManagementContext(string connectionString)
        {
            _connectionString = connectionString;            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientEntityConfiguration());
        }
    }
}
