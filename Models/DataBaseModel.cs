using ProjectMateApp.Exceptions;
using ProjectMateApp.Services;

namespace ProjectMateApp.Models
{
    public class DataBaseModel : IDataBase
    {
        private readonly List<Manager> _managers;

        public DataBaseModel()
        {
            _managers = new List<Manager>(0);
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
    }
}
