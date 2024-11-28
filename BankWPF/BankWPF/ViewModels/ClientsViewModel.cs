using BankWPF.Classes;
using BankWPF.Commands;
using BankWPF.Models;
using BankWPF.Services;
using BankWPF.Stores;
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

        public NavigationViewModel NavigationViewModel { get; }

        private readonly IRequestsToApiService _requestsToApiService;

        //public ICommand GetDataCommand { get; }

    
        public ICommand LoadDataCommand { get; }


        //public ICommand OpenContractsViewCommand { get; }

        public bool dataChangedFlag = true;

        public ClientsViewModel(IRequestsToApiService requestService, NavigationViewModel navigationViewModel/*,, IDialogService dialogServiceNavigationStore navigationStore*/)
        {


            NavigationViewModel = navigationViewModel;

            Clients = new ObservableCollection<Client>();
            
            
            _requestsToApiService = requestService;
           
           


            _dialogService = new DialogService();
            OpenAddClientDialogCommand = new RelayCommand(OpenDialog);

            LoadDataCommand = new LoadClientsCommand(this, _requestsToApiService);
        }

        public static ClientsViewModel LoadViewModel(IRequestsToApiService requestService, NavigationViewModel navigationViewModel/*, IDialogService dialogServiceNavigationStore navigationStore*/)
        {
            ClientsViewModel viewModel = new ClientsViewModel(requestService, navigationViewModel/*, navigationStore*/);

            viewModel.LoadDataCommand.Execute(viewModel);

            return viewModel;
        }


        #region Методы класса

        private void OpenDialog(object parameter)
        {
            _dialogService.ShowAddClientDialog();
            //this.LoadData(parameter);
        }

        #endregion

    }
}
