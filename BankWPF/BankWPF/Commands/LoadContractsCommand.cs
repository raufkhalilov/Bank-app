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
    internal class LoadContractsCommand : BaseAsyncCommand
    {
        private readonly BankStore _bankStore;
        private readonly ContractsListingViewModel _contractsViewModel;
        private readonly IRequestsToApiService _requestsToApiService;

        public LoadContractsCommand(ContractsListingViewModel clientsViewModel, BankStore bankStore, IRequestsToApiService requestsToApiService)
        {
            _bankStore = bankStore;
            _contractsViewModel = clientsViewModel;
            _requestsToApiService = requestsToApiService;
        }

        public override async Task ExecuteAsync()
        {



            var jsonData = true;//await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Clients");

            if (jsonData != null)
            {


                await _bankStore.LoadContracts();
                _contractsViewModel.UpdateContractsList(_bankStore.Contracts);

                //IEnumerable<Client> clients = await _bank.GetAllClients();//JsonConvert.DeserializeObject<ObservableCollection<Client>>(jsonData);
                //_clientViewModel.UpdateClientsList(clients);

                //ObservableCollection<Client> parsedData = JsonConvert.DeserializeObject<ObservableCollection<Client>>(jsonData);
                //_clientViewModel.Clients = parsedData;
            }
            else
            {

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

            }


            /*
               var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Contracts"*//*, this, btn_Click_Del, sender, e*//*);

             if (jsonData != null)
             {
                            ObservableCollection<Contract> parsedData = JsonConvert.DeserializeObject<ObservableCollection<Contract>>(jsonData);
                            _contractsViewModel.Contracts = parsedData;
                        }
                        else
                        {

                            if (MessageBox.Show("Ошибка подключения к серверу " + ".\nПопробовать попробовать подключиться снова? ",
                                "Ошибка",
                                MessageBoxButton.OKCancel,
                                MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                            {

                                await ExecuteAsync();
                            }
                            else
                            {
                                //this.Close();
                            }

                        }*/


        }
    }
}
