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
    internal class LoadDataCommand : BaseCommand
    {

        private readonly IRequestsToApiService _requestsToApiService;
        private readonly ClientsViewModel _clientVM;


        private bool _isExecuting;

        private bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }

            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }


        public LoadDataCommand(ClientsViewModel clientVM, IRequestsToApiService requestsToApiService)
        {
            _clientVM = clientVM;
            _requestsToApiService = requestsToApiService;
        }
        /// <summary>
        /// errors
        /// </summary>
        /// <param name="parameter"></param>
        public override async void Execute(object parameter)
        {

            ///1
            /*_requestsToApiService.LoadData();*/

            //var requestToApiServise = new RequestsToApiService();

            var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Clients"/*, this, btn_Click_Del, sender, e*/);

            if (jsonData != null)
            {
                ObservableCollection<Client> parsedData = JsonConvert.DeserializeObject<ObservableCollection<Client>>(jsonData);
                _clientVM.Clients = parsedData;
            }
            else
            {

                if (MessageBox.Show("Ошибка подключения к серверу " + ".\nПопробовать попробовать подключиться снова? ",
                    "Ошибка",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                    //btn_Click_Del(sender, e);
                    this.Execute(parameter);
                }
                else
                {
                    //this.Close();
                }

            }
        }
    }
}
