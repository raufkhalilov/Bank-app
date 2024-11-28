using BankWPF.Classes;
using BankWPF.Models;
using BankWPF.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    internal class ClientAddingViewModel : BaseViewModel
    {
        #region поля класса

        private readonly IRequestsToApiService _requestsToApiService;
        private Client newClient;

        #endregion

        #region публичные свойства класса

        public ICommand GetDataCommand { get; }
        public ICommand PostDataCommand { get; }


        public ClientAddingViewModel(/*Client nc,*/ IRequestsToApiService requestService)
        {
            newClient = new Client();

            _requestsToApiService = requestService;
            PostDataCommand = new RelayCommand(PostClientData);
        }

        public int ClientID
        {
            get { return newClient.ClientId; }
            set
            {
                newClient.ClientId = value;
                OnPropertyChanged("Title");
            }
        }

        public string ClientName
        {
            get { return newClient.ClientName; }
            set
            {
                newClient.ClientName = value;
                OnPropertyChanged("Company");
            }
        }

        public string PhoneNumber
        {
            get { return newClient.PhoneNumber; }
            set
            {
                newClient.PhoneNumber = value;
                OnPropertyChanged("Price");
            }
        }

        #endregion

        private async void PostClientData(object parameter)
        {
            string url = "http://localhost:8080/post/Client";

            string request = null;

            if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                request = await _requestsToApiService.PostDataToApi(url, newClient);
            }

            if (request != null)
            {
                MessageBox.Show("Клиент успешно добавлен!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Information);
                if (parameter is Window window)
                {
                    window.Close();
                }
            }
            else
            {
                if (MessageBox.Show("При добавлении клиента произошла ошибка!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                {
                    /*if (parameter is Window window)
                    {
                        window.Close();
                    }*/
                }
            }
        }

    }
}
