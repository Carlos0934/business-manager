
using Microsoft.EntityFrameworkCore;
namespace BusinessManager.Core 
{
    public abstract class EFRepository<C> : IRepository where C : DbContext
    {   
        protected C context;
        public EFRepository(C context) 
        {
            this.context = context;
        }
    }
}