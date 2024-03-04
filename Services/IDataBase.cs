using ProjectMateApp.Models;

namespace ProjectMateApp.Services
{
    public interface IDataBase
    {
        public IEnumerable<Manager> Managers { get; }
        public IEnumerable<Product> Products { get; }
        public IEnumerable<Client> Clients { get; }
        public void AddManager(Manager manager);
        public void AddProduct(Product product);
        public void AddClient(Client client);
    }
}
