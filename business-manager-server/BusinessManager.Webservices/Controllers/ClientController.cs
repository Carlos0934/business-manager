using BusinessManager.Warehouse;
using BusinessManager.Core;
namespace BusinessManager.Webservices
{
    public class ClientController : CRUDController<Client>
    {
        public ClientController(ICRUDRepository<Client> repository) : base(repository)
        {

        }
    }
}