using BankWPF.Commands;
using BankWPF.Services;
using BankWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankWPF.ViewModels
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
