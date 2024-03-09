using ProjectMateApp.Models;

namespace ProjectMateApp.Services
{
    public interface IDataBase
    {
        public IEnumerable<Manager> Managers { get; }
        public IEnumerable<Client> Clients { get; }
        public IEnumerable<Product> Products { get; }

        public void Add(Manager manager);
        public void Delete(Manager manager);
        public bool Exists(Manager manager);

        public void Add(Product product);
        public void Delete(Product product);
        public bool Exists(Product product);

        public void Add(Client client);
        public void Delete(Client client);
        public bool Exists(Client client);
    }
}
