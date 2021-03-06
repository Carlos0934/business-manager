using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace BusinessManager.Core 
{
    public abstract class EFCRUDRepository<T , C> : EFRepository<C>, ICRUDRepository<T> where T : Entity where C : DbContext
    {   
        protected DbSet<T> dbset;
        public EFCRUDRepository(C context, DbSet<T> dbset) : base(context)
        {   
            this.dbset = dbset;
        } 
        private async Task<bool> CheckIfEntityExists(uint id)
        {
            var entity = await dbset.SingleAsync(entity => entity.Id == id);
            return entity == null;
        }
        public Task<T> GetOne(uint id)
        {
            var entity = dbset.SingleAsync(entity => entity.Id == id);
            if(entity == null)
                throw new EntityNotFound(id);

            return entity;
        }
        public async Task<IEnumerable<T>> GetAll()
            => await dbset.ToListAsync();
        public async Task Save(T entity)
        {   
            await dbset.AddAsync(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw new AlreadyEntityExists(entity);
            }
          
            
        }

        public async Task Update(T entity, uint id)
        {   
            var exists = await CheckIfEntityExists(id);
            if(!exists)
                throw new EntityNotFound(id);

            entity.Id = id;
            dbset.Update(entity);

            await context.SaveChangesAsync();
        }

        public async Task Delete(uint id)
        {  
            var exists = await CheckIfEntityExists(id);
            if(!exists)
                throw new EntityNotFound(id);

            var entity = await GetOne(id);
            dbset.Remove(entity);
            await context.SaveChangesAsync();

        }
    } 
}