using BankWPFCore.Commands;
using BankWPFCore.Services;
using BankWPFCore.Services.AuthenticationServices;
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
                ErrorMessage = string.Empty;
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
                ErrorMessage = string.Empty;
                OnPropertyChanged(nameof(Password));
            }
        }

        //==========================

        private string _errorMessage;

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(_errorMessage);

        //==========================

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
