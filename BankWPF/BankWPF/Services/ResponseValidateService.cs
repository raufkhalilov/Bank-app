using BankWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF.Services
{
    internal class ResponseValidateService<TModel>
    {
        private readonly RequestsToApiService _requestsToApiService;
        private ObservableCollection<TModel> _modelData;

        public ResponseValidateService(RequestsToApiService requestsToApiService,ObservableCollection<TModel> modelData)
        {
            _requestsToApiService = requestsToApiService;
            _modelData = modelData;
        }

        public async void GetData()
        {
            var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Clients"/*, this, btn_Click_Del, sender, e*/);

            if (jsonData != null)
            {

                _modelData = JsonConvert.DeserializeObject<ObservableCollection<TModel>>(jsonData);
                //ObservableCollection<Client> parsedData = JsonConvert.DeserializeObject<ObservableCollection<Client>>(jsonData);
                //Clients = parsedData;
                //dataChangedFlag = true;
            }
            else
            {
                if (MessageBox.Show("Ошибка подключения к серверу " + ".\nПопробовать попробовать подключиться снова? ",
                    "Ошибка",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                    //btn_Click_Del(sender, e);
                    this.GetData();
                }
                else
                {
                    //this.Close();
                }

            }
        }
    }
}
