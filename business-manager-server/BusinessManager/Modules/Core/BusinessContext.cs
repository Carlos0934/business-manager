using Microsoft.EntityFrameworkCore;
using BusinessManager.Warehouse;
namespace BusinessManager.Core 
{
    public class BusinessContext : DbContext
    {   
        private DbClientBuilder clientBuilder = new DbClientBuilder();
        public DbSet<Client> Clients {get; set;}
        public BusinessContext(DbContextOptions<BusinessContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            clientBuilder.Build<Client>(modelBuilder);
        }
    }
}