using BankWPF.Services;
using BankWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF.Commands
{
    internal class LoginCommand : BaseAsyncCommand
    {

        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthService _authService;

        public LoginCommand(LoginViewModel loginViewModel, IAuthService authService)
        {
            _loginViewModel = loginViewModel;
            _authService = authService;
        }

        public override async Task ExecuteAsync()
        {
            if( await _authService.IsAuthenticated(_loginViewModel.Username, _loginViewModel.Password))
            {
                _loginViewModel.OpenStartPageCommand.Execute(_authService);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
