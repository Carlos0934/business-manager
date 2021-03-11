using Microsoft.EntityFrameworkCore;
using BusinessManager.Warehouse;
namespace BusinessManager.Core 
{
    public class BusinessContext : DbContext
    {   
        private DbClientBuilder clientBuilder;
        public DbSet<Client> Clients {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            clientBuilder.Build<Client>(modelBuilder);
        }
    }
}