using ProjectMateApp.Models;

namespace ProjectMateApp.Services
{
    public interface IDataBase
    {
        public IEnumerable<Manager> GetManagers();
        public void AddManager(Manager manager);
    }
}
