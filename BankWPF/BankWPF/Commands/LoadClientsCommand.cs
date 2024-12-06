using BankWPF.Models;
using BankWPF.Services;
using BankWPF.Stores;
using BankWPF.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF.Commands
{
    internal class LoadClientsCommand : BaseAsyncCommand
    {
        private readonly ClientsListingViewModel _clientViewModel;
        private readonly IRequestsToApiService _requestsToApiService;
        private BankStore _bankStore;

        public LoadClientsCommand(ClientsListingViewModel clientsViewModel, BankStore bankStore, IRequestsToApiService requestsToApiService) 
        {
            _bankStore = bankStore;
            _clientViewModel = clientsViewModel;
            _requestsToApiService = requestsToApiService;
        }

        public override async Task ExecuteAsync()
        {

            var jsonData = true;//await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Clients");

            //if (jsonData != null)
            //{

            _clientViewModel.IsLoading = true;

                await _bankStore.LoadClients();
                _clientViewModel.UpdateClientsList(_bankStore.Clients);

            _clientViewModel.IsLoading = false;

                //IEnumerable<Client> clients = await _bank.GetAllClients();//JsonConvert.DeserializeObject<ObservableCollection<Client>>(jsonData);
                //_clientViewModel.UpdateClientsList(clients);

                //ObservableCollection<Client> parsedData = JsonConvert.DeserializeObject<ObservableCollection<Client>>(jsonData);
                //_clientViewModel.Clients = parsedData;
           // }
            //else
          /*  {

                if (MessageBox.Show("Ошибка подключения к серверу " + ".\nПопробовать попробовать подключиться снова? ",
                    "Ошибка",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                    //btn_Click_Del(sender, e);
                    //this.Execute(parameter);
                }
                else
                {
                    //this.Close();
                }

            }*/


        }
    }
}
