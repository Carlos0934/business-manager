using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessManager.Core;
namespace BusinessManager.Webservices
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class CRUDController<T> :  ControllerBase where T : Entity
    {   
        protected ICRUDRepository<T>  repository; 
        public CRUDController(ICRUDRepository<T> repository)
        {
            this.repository = repository;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOne(uint id)
        {   
            try
            {
                var entity = await repository.GetOne(id);
                return Ok(entity);
            }
            catch (EntityNotFound)
            {
                return NotFound();
            }
           
           
        }
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var entities = await repository.GetAll();

            return Ok(entities);
        }
        [HttpPost]
        public async Task<IActionResult> Save( [FromBody] T entity )
        {
            try
            {
                await repository.Save(entity);
                return Ok(entity);
            }
            catch (AlreadyEntityExists err)
            {
                
                return BadRequest(err.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] T entity , uint id)
        {
            try
            {
                await repository.Update(entity , id);
                return Ok(entity);
            }
            catch (EntityNotFound err)
            {
               return BadRequest(err.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(uint id)
        {
            try
            {
                await repository.Delete(id);
                return Ok();
            }
            catch (EntityNotFound err)
            {
               return BadRequest(err.Message);
            }
        }
      
    }
}