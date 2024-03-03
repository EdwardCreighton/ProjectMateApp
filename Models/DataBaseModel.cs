using ProjectMateApp.Exceptions;
using ProjectMateApp.Services;

namespace ProjectMateApp.Models
{
    public class DataBaseModel : IDataBase
    {
        private readonly List<Manager> _managers;
        private readonly List<Product> _products;

        public IEnumerable<Manager> Managers => _managers;
        public IEnumerable<Product> Products => _products;

        public DataBaseModel()
        {
            _managers = new List<Manager>(0);
            _products = new List<Product>(0);
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
                    throw new ManagerAlreadyExistsException();
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
                    throw new ProductAlreadyExistsException();
                }
            }

            _products.Add(product);
        }
    }
}
