using ProjectMateApp.Models;

namespace ProjectMateApp.Services
{
    public interface IDataBase
    {
        public IEnumerable<Manager> Managers { get; }
        public IEnumerable<Product> Products { get; }
        public void AddManager(Manager manager);
        public void AddProduct(Product product);
    }
}
