using System.Collections.ObjectModel;

namespace ProjectMateApp.ViewModels
{
    public class ManagersListViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ManagerViewModel> _managers;

        public IEnumerable<ManagerViewModel> Managers => _managers;

        public ManagersListViewModel()
        {
            _managers = new ObservableCollection<ManagerViewModel>();

            _managers.Add(new ManagerViewModel(new Models.Manager("John Stachelzky")));
            _managers.Add(new ManagerViewModel(new Models.Manager("Frederic Buckovich")));
            _managers.Add(new ManagerViewModel(new Models.Manager("Aster Vil-Usov")));
            _managers.Add(new ManagerViewModel(new Models.Manager("Frensis Dormut")));
        }
    }
}
