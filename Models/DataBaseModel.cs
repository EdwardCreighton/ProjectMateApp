using ProjectMateApp.Exceptions;
using ProjectMateApp.Services;

namespace ProjectMateApp.Models
{
    public class DataBaseModel : IDataBase
    {
        private readonly List<Manager> _managers;
        private readonly List<Product> _products;
        private readonly List<Client> _clients;

        public IEnumerable<Manager> Managers => _managers;
        public IEnumerable<Product> Products => _products;
        public IEnumerable<Client> Clients => _clients;

        public DataBaseModel()
        {
            _managers = new List<Manager>(0);
            _products = new List<Product>(0);
            _clients = new List<Client>(0);
        }

        public IEnumerable<Manager> GetManagers()
        {
            return _managers;
        }

        public void AddManager(Manager manager)
        {
            foreach (var existingManager in _managers)
            {
                if (existingManager.Equals(manager))
                {
                    throw new DataBaseElementAlreadyExistsException();
                }
            }

            _managers.Add(manager);
        }

        public void AddProduct(Product product)
        {
            foreach (var existingProduct in _products)
            {
                if (existingProduct.Equals(product))
                {
                    throw new DataBaseElementAlreadyExistsException();
                }
            }

            _products.Add(product);
        }

        public void AddClient(Client client)
        {
            foreach(var existingClient in _clients)
            {
                if (existingClient.Equals(client))
                {
                    throw new DataBaseElementAlreadyExistsException();
                }
            }

            _clients.Add(client);
        }
    }
}
