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

        private readonly IRequestsToApiService _requestsToApiService;

        public ICommand GetDataCommand { get; }
        public ICommand PostDataCommand { get; }

        private Client newClient;

        public ClientAddingViewModel(/*Client nc,*/ IRequestsToApiService requestService)
        {
            newClient = new Client();

            _requestsToApiService = requestService;
            PostDataCommand = new RelayCommand(PostData);
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


        private async void PostData(object parameter)
        {
            //if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
            //    return;

            string url = "http://localhost:8080/post/Client";

            /* Client client1 = new Client()
             {
                 //client_name = "Test3",
                 //phone_number = "Test",
                 ClientId = 1,
                 ClientName = "Dimooooon",
                 PhoneNumber = "1234567890"
             };*/
            string request = null;

            if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                request = await _requestsToApiService.PostDataToApi(url, newClient);
            }

            if (request != null)
            {
                //this.LoadData(parameter);
                MessageBox.Show("Клиент успешно добавлен!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                if(MessageBox.Show("При добавлении клиента произошла ошибка!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Error)==MessageBoxResult.OK)
                {
                    
                }
            }
            //this.clients_window_loaded(sender, e); */
        }

    }
}
