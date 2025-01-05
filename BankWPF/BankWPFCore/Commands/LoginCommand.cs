using BankWPFCore.Services;
using BankWPFCore.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPFCore.Commands
{
    internal class LoginCommand : BaseAsyncCommand
    {

        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthService _authService;
        private readonly NavigationService<StartViewModel> _navigationService;

        public LoginCommand(LoginViewModel loginViewModel, IAuthService authService/*, NavigationService<StartViewModel> navigationService*/)
        {
            _loginViewModel = loginViewModel;
            _authService = authService;
            //_navigationService = navigationService;
        }

        public override async Task ExecuteAsync()
        {
            if (await _authService.IsAuthenticated(_loginViewModel.Username, _loginViewModel.Password))
            {

                _loginViewModel.OpenStartPageCommand.Execute(_authService);
                //_navigationService.Navigate();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
