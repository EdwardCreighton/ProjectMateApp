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
    }
}
