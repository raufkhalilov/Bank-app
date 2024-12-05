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
    internal class LoadUserContractsCommand : BaseAsyncCommand
    {
        private readonly ClientBlankViewModel _clientCardViewModel;
        private readonly IRequestsToApiService _requestsToApiService;

        public LoadUserContractsCommand(ClientBlankViewModel clientsViewModel, IRequestsToApiService requestsToApiService)
        {
            _clientCardViewModel = clientsViewModel;
            _requestsToApiService = requestsToApiService;
        }

        public override async Task ExecuteAsync()
        {

            var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Contracts"/*, this, btn_Click_Del, sender, e*/);

            if (jsonData != null)
            {
                ObservableCollection<Contract> parsedData = JsonConvert.DeserializeObject<ObservableCollection<Contract>>(jsonData);
                _clientCardViewModel.ClientsActiveContracts = parsedData;

                //_clientCardViewModel.ClientsActiveContracts = _clientCardViewModel.ClientsActiveContracts.Where(c => c.ClientID == _clientCardViewModel.ClientID);

                _clientCardViewModel.ClientsActiveContracts = new ObservableCollection<Contract>(
                    _clientCardViewModel.ClientsActiveContracts.Where(c => c.ClientID == _clientCardViewModel.ClientID));
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
