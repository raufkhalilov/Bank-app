using BankWPFCore.Exceptions;
using BankWPFCore.Models;
using BankWPFCore.Services;
using BankWPFCore.Stores;
using BankWPFCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPFCore.Commands
{
    internal class UpdateClientCommand : BaseAsyncCommand
    {
        private BankStore _bankStore;

        private readonly Client _updatedClient;

        private readonly NavigationViewModel _navigationViewModel;

        private readonly NavigationService<ClientsListingViewModel> _navigationService;

        public UpdateClientCommand(BankStore bankStore, Client updatedClient, NavigationViewModel navigationViewModel, NavigationService<ClientsListingViewModel> navigationService)
        {
            _bankStore = bankStore;
            _updatedClient = updatedClient;
            _navigationViewModel = navigationViewModel;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync()
        {


            if (MessageBox.Show("Вы действительно хотите поменять данные клиента?", "Редактирование", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                try
                {
                    await _bankStore.UpdateClient(_updatedClient);
                    MessageBox.Show("Данные обновлены!", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Information);

                    //_navigationViewModel.NavigateClientsViewCommand.Execute(_newClient);
                    _navigationService.Navigate();
                    //_navigationService.Dispose();
                }
                catch (ClientConflictException)
                {
                    MessageBox.Show("Клиент с такими уникальными полями уже существует!", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (ApiConnectionException ex)
                {
                    MessageBox.Show("При обновлении данных клиента произошла ошибка!\n" + ex.Message, "Редактирование", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
