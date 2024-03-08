using ProjectMateApp.Commands;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Utils;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class EditManagerViewModel : BaseViewModel
    {
		private Manager _manager;
		public Manager Manager
		{
			get => _manager;
			set
			{
				_manager = value;
				if (_manager != null)
				{
                    NameValidator.SeparateName(_manager.Name, out _firstName, out _surname, out _lastName);
                }
			}
		}

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

		public ICommand Apply { get; }
        public ICommand Cancel { get; }
        public ICommand Delete { get; }

        public EditManagerViewModel(NavigationService toListingNavigationService, IDataBase dataBase)
        {
            Apply = new ApplyManagerChangesCommand(this, () => Manager, toListingNavigationService, dataBase);
            Cancel = new NavigateCommand(toListingNavigationService);
			Delete = new DeleteManagerCommand(() => Manager, toListingNavigationService, dataBase);
        }
    }
}
