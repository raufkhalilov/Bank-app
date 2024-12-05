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
    internal class LoadDataCommand<TModel> : BaseAsyncCommand
        where TModel : BaseModel
    {

        private readonly ListingDataViewModel<TModel> _clientViewModel;
        private readonly IRequestsToApiService _requestsToApiService;

        public LoadDataCommand(ListingDataViewModel<TModel> clientsViewModel, IRequestsToApiService requestsToApiService)
        {
            _clientViewModel = clientsViewModel;
            _requestsToApiService = requestsToApiService;
        }

        public override async Task ExecuteAsync()
        {

            var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Clients"/*, this, btn_Click_Del, sender, e*/);

            if (jsonData != null)
            {
                ObservableCollection<TModel> parsedData = JsonConvert.DeserializeObject<ObservableCollection<TModel>>(jsonData);
                _clientViewModel.Data = parsedData;
            }
            else
            {

                MessageBox.Show("Ошибка подключения к серверу " + ".\nПопробовать попробовать подключиться снова? ",
                     "Ошибка",
                     MessageBoxButton.OKCancel,
                     MessageBoxImage.Exclamation);
                

            }


        }
    }
    
}
