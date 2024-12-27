
using BankWPF.Commands;
using BankWPF.Models;
using BankWPF.Services;
using BankWPF.Stores;
using BankWPFCore.Services.ApiServices.Get;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    internal class ClientsListingViewModel : /*ListingDataViewModel<Client>*/BaseViewModel
    {

        //Bank _bank;

        private Client _selectedClient;

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        

        private ObservableCollection<Client> _clients;

        #region Поля модели представления
        public ObservableCollection<Client> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");//
            }
        }
        #endregion



        //Список клиентов теперь хранится в _data родительского класса ListingDataViewModel<TModel>
        //Это сделано для возможности использования одной команды
        //загрузки для всех моделей, всесто нескольких под разные типы


        public NavigationViewModel NavigationViewModel { get; }



        public ICommand OpenAddClientDialogCommand { get; }

        public ICommand OpenClientCardCommand { get; }

        public ICommand DblOpenClientCardCommand { get; }

        public ICommand LoadDataCommand { get; }



        private readonly IRequestsToApiService _requestsToApiService;

        //private readonly IDialogService _dialogService;

        public ICommand HelperCommand { get; }



        //public bool dataChangedFlag = true;
        private BankStore _bankStore;

        public ClientsListingViewModel(BankStore bankStore, /*IRequestsToApiService requestService,*/ NavigationViewModel navigationViewModel, NavigationStore navigationStore, IClientsProvider clientsProvider, IContractsProvider contractsProvider)
        {



            _bankStore = bankStore;
            NavigationViewModel = navigationViewModel;

            Clients = new ObservableCollection<Client>(); //v1

            //_requestsToApiService = requestService;


            OpenClientCardCommand = new NavigationCommand<ClientBlankViewModel>(new NavigationService<ClientBlankViewModel>(navigationStore,
                () => ClientBlankViewModel.LoadClientCardViewModel(bankStore, navigationViewModel, navigationStore, clientsProvider, contractsProvider)));

            DblOpenClientCardCommand = new NavigationCommand<ClientBlankViewModel>(new NavigationService<ClientBlankViewModel>(navigationStore,
                () => ClientBlankViewModel.LoadClientCardViewModel(bankStore, navigationViewModel, navigationStore, clientsProvider, contractsProvider, SelectedClient)));


            LoadDataCommand = new LoadClientsCommand(this, bankStore/*, _requestsToApiService*/);

            HelperCommand = new ConnectionCommand(bankStore, navigationViewModel, navigationStore);

            bankStore.ClientAdded += OnClientMode;

        }

        private void OnClientMode(Client client)
        {
            //Client client = new Client();
            _clients.Add(client);
        }

        public override void Dispose()
        {
            _bankStore.ClientAdded -= OnClientMode;
            base.Dispose();
        }

        public static ClientsListingViewModel LoadViewModel(BankStore bankStore, /*IRequestsToApiService requestService,*/ IClientsProvider clientsProvider, IContractsProvider contractsProvider,
            NavigationViewModel navigationViewModel, NavigationStore navigationStore)
        {
            ClientsListingViewModel viewModel = new ClientsListingViewModel(bankStore, /*requestService,*/ navigationViewModel, navigationStore, clientsProvider, contractsProvider);

            viewModel.LoadDataCommand.Execute(viewModel);


            return viewModel;
        }

        public void UpdateClientsList(IEnumerable<Client> clients)
        {
            _clients.Clear();

            foreach (var client in clients)
            {
                _clients.Add(client);
            }
        }


        #region Методы класса
/*
        private void OpenDialog(object parameter)
        {
            //_dialogService.ShowAddClientDialog();
            //this.LoadData(parameter);
        }
*/
        #endregion

    }
}
