using Microsoft.EntityFrameworkCore;
namespace BusinessManager.Core
{
    public class DBEntityBuilder 
    {
        
        public void Build<T>(ModelBuilder builder) where T : Entity
        {   
            builder.Entity<T>()
            .HasKey(entity => entity.Id);

            builder.Entity<T>()
            .Property(entity => entity.Id)
            .HasDefaultValue(0)
            .IsRequired()
            .ValueGeneratedOnAdd();
            

        }
    }
}