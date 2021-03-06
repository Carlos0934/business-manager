using Microsoft.EntityFrameworkCore;
using BusinessManager.Warehouse;
namespace BusinessManager.Core 
{
    public class BusinessContext : DbContext
    {
        public DbSet<Client> Clients {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Client>()
                .Property(client => client.Id)
                .HasColumnName("Id")
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}