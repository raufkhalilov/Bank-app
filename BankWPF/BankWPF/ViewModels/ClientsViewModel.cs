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
    internal class ClientsViewModel : BaseViewModel
    {
        private ObservableCollection<Client> clients;

        #region Поля модели представления
        public ObservableCollection<Client> Clients {
            get
            {
                return clients;
            }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");//
            }
        }
        #endregion


        private readonly IDialogService _dialogService;

        public ICommand OpenAddClientDialogCommand { get; }



        private readonly IRequestsToApiService _requestsToApiService;

        public ICommand GetDataCommand { get; }

        public ICommand PostDataCommand { get; }

        public ClientsViewModel(IRequestsToApiService requestService, IDialogService dialogService)
        {
            Clients = new ObservableCollection<Client>();
    
            _requestsToApiService = requestService;
            GetDataCommand = new RelayCommand(LoadData);
            PostDataCommand = new RelayCommand(PostData);

            _dialogService = dialogService;
            OpenAddClientDialogCommand = new RelayCommand(OpenDialog);
        }


        #region Методы класса

        private void OpenDialog(object parameter)
        {
            _dialogService.ShowAddClientDialog();
            this.LoadData(parameter);
        }

        private async void PostData(object parameter)
        {
            //if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
            //    return;

            string url = "http://localhost:8080/post/Client";

            Client client1 = new Client()
            {
                //client_name = "Test3",
                //phone_number = "Test",
                ClientId = 1,
                ClientName = "Test1711",
                PhoneNumber = "1234567890"
            };

            string request = await _requestsToApiService.PostDataToApi(url, client1);

            if (request != null)
            {
                this.LoadData(parameter);
            }
                //this.clients_window_loaded(sender, e); */
        }

        private async void LoadData(object parameter)
        {
            var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Clients"/*, this, btn_Click_Del, sender, e*/);

            if (jsonData != null)
            {
                ObservableCollection<Client> parsedData = JsonConvert.DeserializeObject<ObservableCollection<Client>>(jsonData);
                Clients = parsedData;
            }
            else
            {
                if (MessageBox.Show("Ошибка подключения к серверу " + ".\nПопробовать попробовать подключиться снова? ", 
                    "Ошибка", 
                    MessageBoxButton.OKCancel, 
                    MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                    //btn_Click_Del(sender, e);
                    this.LoadData(parameter);
                }
                else
                {
                    //this.Close();
                }

            }
        }

        #endregion

    }
}
