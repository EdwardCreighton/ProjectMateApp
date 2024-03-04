
namespace ProjectMateApp.Models
{
    public class Client
    {
        public string Name { get; }
        public ClientStatus Status { get; }
        public Manager Manager { get; }
        public List<Product> BoughtProducts { get; }

        public Client(string name, ClientStatus status, Manager manager)
        {
            Name = name;
            Status = status;
            Manager = manager;
            BoughtProducts = new List<Product>(0);
        }

        public override bool Equals(object? obj)
        {
            return obj != null
                && obj is Client client
                && client.Name == Name
                && client.Status == Status
                && client.Manager == Manager;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Status, Manager, BoughtProducts);
        }
    }
}
