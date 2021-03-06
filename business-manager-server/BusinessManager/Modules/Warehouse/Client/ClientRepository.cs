
using BusinessManager.Core;

namespace BusinessManager.Warehouse
{
    public class ClientRepository : BusinessRepository<Client>
    {
        public ClientRepository(BusinessContext context) : base(context, context.Clients)
        {

        }
    }
}