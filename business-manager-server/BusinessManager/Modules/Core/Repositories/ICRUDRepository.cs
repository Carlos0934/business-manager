

using System.Collections.Generic;
using System.Threading.Tasks;
namespace BusinessManager.Core 
{
    public interface ICRUDRepository<T> where T : Entity
    {
        Task<T> GetOne(uint id); 
        Task<IEnumerable<T>> GetAll();
        Task Save(T entity);
        Task Update(T entity, uint id);
        Task Delete(uint id);
    } 
}