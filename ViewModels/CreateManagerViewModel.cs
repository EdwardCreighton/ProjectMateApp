using ProjectMateApp.Commands;
using ProjectMateApp.Services;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class CreateManagerViewModel : BaseViewModel
    {
		private string _firstName;
		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				_firstName = value;
				OnPropertyChanged(nameof(FirstName));
			}
		}

		private string _surname;
		public string Surname
		{
			get
			{
				return _surname;
			}
			set
			{
				_surname = value;
				OnPropertyChanged(nameof(Surname));
			}
		}

		private string _lastName;
		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				_lastName = value;
				OnPropertyChanged(nameof(LastName));
			}
		}

		public ICommand Create { get; }
        public ICommand Cancel { get; }

        public CreateManagerViewModel(NavigationService toListingNavigationService, IDataBase dataBase)
        {
            Create = new CreateManagerCommand(toListingNavigationService, dataBase, this);
            Cancel = new NavigateCommand(toListingNavigationService);
        }
    }
}
