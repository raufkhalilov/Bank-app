using BankWPFCore.Exceptions;
using BankWPFCore.Models;
using BankWPFCore.Services;
using BankWPFCore.Stores;
using BankWPFCore.ViewModels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace BankWPFCore.Commands
{
    internal class PostClientCommand : BaseAsyncCommand
    {
        private BankStore _bankStore;

        private readonly Client _newClient;

        private readonly NavigationViewModel _navigationViewModel;

        private readonly NavigationService<ClientsListingViewModel> _navigationService;

        public PostClientCommand(BankStore bankStore, Client newClient, NavigationViewModel navigationViewModel, NavigationService<ClientsListingViewModel> navigationService)
        {
            _bankStore = bankStore;
            _newClient = newClient;
            _navigationViewModel = navigationViewModel;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync()
        {


            if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                try
                {
                    await _bankStore.AddNewClient(_newClient);
                    MessageBox.Show("Клиент успешно добавлен!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Information);

                    //_navigationViewModel.NavigateClientsViewCommand.Execute(_newClient);
                    _navigationService.Navigate();
                    //_navigationService.Dispose();
                }
                catch (ClientConflictException)
                {
                    MessageBox.Show("Клиент с такими уникальными полями уже существует!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (ApiConnectionException ex)
                {
                    MessageBox.Show("При добавлении клиента произошла ошибка!\n" + ex.Message, "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        ~PostClientCommand() { }
    }
}
