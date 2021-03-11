using Microsoft.EntityFrameworkCore;
using BusinessManager.Core;

namespace BusinessManager.Warehouse
{
    public class DbClientBuilder
    {   
        private DBEntityBuilder entityBuilder = new DBEntityBuilder();
        public void Build<T>(ModelBuilder builder) where T : Client
        {   
            entityBuilder.Build<T>(builder);
            
            builder.Entity<T>()
            .Property(client => client.Name)
            .HasMaxLength(50)
            .IsRequired();

            builder.Entity<T>()
            .Property(client => client.Email)
            .HasMaxLength(100)
            .IsRequired();

            builder.Entity<T>()
            .Property(client => client.Phone)
            .HasMaxLength(20);
            
            builder.Entity<T>()
            .Property(client => client.Address)
            .HasMaxLength(50);
          
            
        }
    }
}