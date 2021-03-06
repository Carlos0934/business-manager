using BusinessManager.Core;
namespace BusinessManager.Warehouse
{
    public class Client : Entity
    {
        public string Name {get; set;}
        public string Address {get; set;}
        public string Email {get; set;}
        public string Phone {get; set;}
    }
}