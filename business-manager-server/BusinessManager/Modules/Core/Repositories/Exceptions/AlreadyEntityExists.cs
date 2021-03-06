
using System;
namespace BusinessManager.Core
{
    public class AlreadyEntityExists : Exception
    {
        public AlreadyEntityExists(Entity entity) : base($"Already entity with id {entity.Id} exists") {

        }
    }
}