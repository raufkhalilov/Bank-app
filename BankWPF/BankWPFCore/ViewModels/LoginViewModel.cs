using BankWPFCore.Commands;
using BankWPFCore.Services;
using BankWPFCore.Stores;
using System.Windows.Input;

namespace BankWPFCore.ViewModels
{


    internal class LoginViewModel : BaseViewModel
    {

        private string _username;
        private string _password;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand OpenStartPageCommand { get; }

        public ICommand LoginCommand { get; }

        public LoginViewModel(NavigationStore navigationStore, NavigationViewModel navigationViewModel, IAuthService authService)
        {
            LoginCommand = new LoginCommand(this, authService);

            OpenStartPageCommand = new NavigationCommand<StartViewModel>(new NavigationService<StartViewModel>(navigationStore,
                () => new StartViewModel(navigationViewModel)));
        }

        ~LoginViewModel() { }

    }
}
