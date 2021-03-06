
using System;
namespace BusinessManager.Core
{
    public class EntityNotFound : Exception
    {
        public EntityNotFound(uint id) : base($"Entity with id '${id}' not found") 
        {
            
        }
    }
}