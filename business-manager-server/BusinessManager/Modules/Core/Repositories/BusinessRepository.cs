using Microsoft.EntityFrameworkCore;
namespace BusinessManager.Core 
{
    public abstract class BusinessRepository<T> : EFCRUDRepository<T, BusinessContext> where T : Entity
    {
        public BusinessRepository(BusinessContext context, DbSet<T> dbset) : base(context, dbset) 
        {

        }
    }
}