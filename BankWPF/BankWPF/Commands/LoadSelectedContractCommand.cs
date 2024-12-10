using BankWPF.Models;
using BankWPF.Services;
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
    internal class LoadSelectedContractCommand : BaseAsyncCommand
    {
        private readonly ContractBlankViewModel _contractCardViewModel;
        private readonly IRequestsToApiService _requestsToApiService;

        public LoadSelectedContractCommand(ContractBlankViewModel contractCardViewModel, IRequestsToApiService requestsToApiService)
        {
            _contractCardViewModel = contractCardViewModel;
            _requestsToApiService = requestsToApiService;
        }

        public override async Task ExecuteAsync()
        {

            var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Clients"/*, this, btn_Click_Del, sender, e*/);

            if (jsonData != null)
            {
                ObservableCollection<Client> parsedData = JsonConvert.DeserializeObject<ObservableCollection<Client>>(jsonData);
                ObservableCollection<Client> clients = new ObservableCollection<Client>(parsedData);
                //_contractCardViewModel. = parsedData;
                //var v1 = clients.Where(d => d.ClientId == _contractCardViewModel.ClientID);
                //string v2 = v1.Select(c => c.ClientName).FirstOrDefault();
                _contractCardViewModel.ClientName = clients.Where(d => d.ClientId == _contractCardViewModel.ClientID).Select(c => c.ClientName).FirstOrDefault();
                    
                    
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


        }
    }
}

