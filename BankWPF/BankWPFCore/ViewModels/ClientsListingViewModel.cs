using BankWPFCore.Commands;
using BankWPFCore.Models;
using BankWPFCore.Services;
using BankWPFCore.Services.ApiServices.Providers;
using BankWPFCore.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows.Input;

namespace BankWPFCore.ViewModels
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
                //ApplyFilter();
                //OnPropertyChanged("Clients");//
            }
        }
        #endregion


        //===================================

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                ApplyFilter();
            }
        }

        private ObservableCollection<Client> _filteredData;

        public ObservableCollection<Client> FilteredData
        {
            get
            {
                return _filteredData;
            }
            set
            {
                _filteredData = value;
                OnPropertyChanged(nameof(FilteredData));
                //ApplyFilter();
            }
        }

        private void ApplyFilter()
        {
            // Implement logic to filter Data based on SearchText
            var bufContracts = new List<Client>(Clients);
            FilteredData = new ObservableCollection<Client>(bufContracts.Where(item => item.ClientName.Contains(SearchText) || (item.ClientId.ToString()).Contains(SearchText) || item.PhoneNumber.ToString().Contains(SearchText)));
        }

        //===================================



        public NavigationViewModel NavigationViewModel { get; }



        public ICommand OpenAddClientDialogCommand { get; }

        public ICommand OpenClientCardCommand { get; }

        public ICommand DblOpenClientCardCommand { get; }

        public ICommand LoadDataCommand { get; }

        public ICommand HelperCommand { get; }



        //public bool dataChangedFlag = true;
        private BankStore _bankStore;

        public ClientsListingViewModel(BankStore bankStore,
            NavigationViewModel navigationViewModel, 
            NavigationStore navigationStore, 
            IClientsProvider clientsProvider, 
            IContractsProvider contractsProvider)
        {

            _bankStore = bankStore;
            NavigationViewModel = navigationViewModel;

            Clients = new ObservableCollection<Client>(); //v1

            //_requestsToApiService = requestService;


            OpenClientCardCommand = new NavigationCommand<ClientBlankViewModel>(new NavigationService<ClientBlankViewModel>(navigationStore,
                () => ClientBlankViewModel.LoadClientCardViewModel(bankStore, navigationViewModel, navigationStore, clientsProvider, contractsProvider)));

            DblOpenClientCardCommand = new NavigationCommand<ClientBlankViewModel>(new NavigationService<ClientBlankViewModel>(navigationStore,
                () => ClientBlankViewModel.LoadClientCardViewModel(bankStore, navigationViewModel, navigationStore,  clientsProvider, contractsProvider, SelectedClient)));


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

            viewModel.FilteredData = viewModel.Clients;

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
