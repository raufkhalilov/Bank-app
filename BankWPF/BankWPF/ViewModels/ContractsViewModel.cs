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
using System.Windows.Input;
using System.Windows;
using System.Diagnostics.Contracts;
using Contract = BankWPF.Models.Contract;

namespace BankWPF.ViewModels
{
    internal class ContractsViewModel : BaseViewModel
    {

        private ObservableCollection<Contract> contracts;

        #region Поля модели представления
        public ObservableCollection<Contract> Contracts
        {
            get
            {
                return contracts;
            }
            set
            {
                contracts = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private readonly IRequestsToApiService _requestsToApiService;

        public ICommand GetDataCommand { get; }

        public ContractsViewModel(IRequestsToApiService dialogService)
        {
            Contracts = new ObservableCollection<Contract>();

            _requestsToApiService = dialogService;
            GetDataCommand = new RelayCommand(LoadData);
        }

        private async void LoadData(object parameter)
        {
            var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Clients"/*, this, btn_Click_Del, sender, e*/);

            if (jsonData != null)
            {
                ObservableCollection<Contract> parsedData = JsonConvert.DeserializeObject<ObservableCollection<Contract>>(jsonData);
                Contracts = parsedData;
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
    }
}
