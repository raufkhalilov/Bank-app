using BankWPFCore.Commands;
using BankWPFCore.Models;
using BankWPFCore.Services;
using BankWPFCore.Services.ApiServices.Providers;
using BankWPFCore.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using LiveCharts.Wpf;
using LiveCharts;
using System.Linq;
using System.Runtime.CompilerServices;
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

        #region Вспомогательные поля

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

        private string _errorMessage;

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(_errorMessage);

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

        private BankStore _bankStore;


        //=======================================================
        //============Graphics===================================


        private SeriesCollection _seriesCollection;
        private string[] _labels;
        private Func<double, string> _formatter;

        public SeriesCollection SeriesCollection
        {
            get
            {
                return _seriesCollection;
            }
            set
            {
                _seriesCollection = value;
                OnPropertyChanged(nameof(SeriesCollection));
            }
        }

        public string[] Labels
        {
            get
            {
                return _labels;
            }
            set
            {
                _labels = value;
                OnPropertyChanged(nameof(Labels));
            }
        }

        public Func<double, string> Formatter
        {
            get
            {
                return _formatter;
            }
            set
            {
                _formatter = value;
                OnPropertyChanged(nameof(Formatter));
            }
        }





        //============Graphics===================================
        //=======================================================




        public ClientsListingViewModel(BankStore bankStore,
            AccountStore accountStore,
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
                () => ClientBlankViewModel.LoadClientCardViewModel(bankStore, accountStore, navigationViewModel, navigationStore, clientsProvider, contractsProvider)));

            DblOpenClientCardCommand = new NavigationCommand<ClientBlankViewModel>(new NavigationService<ClientBlankViewModel>(navigationStore,
                () => ClientBlankViewModel.LoadClientCardViewModel(bankStore, accountStore, navigationViewModel, navigationStore,  clientsProvider, contractsProvider, SelectedClient)));


            LoadDataCommand = new LoadClientsCommand(this, bankStore/*, _requestsToApiService*/);

            HelperCommand = new ConnectionCommand(bankStore, navigationViewModel, navigationStore);

            bankStore.ClientAdded += OnClientMode;

            //=======================================

            SeriesCollection = new SeriesCollection
            {
                /*new StackedColumnSeries
                {
                    Values = new ChartValues<double> {4, 5, 6, 8, 7},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true,
                    Title="Credits"


                },
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {2, 5, 6, 7},
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    Title="Debts"
                },
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {6, 2, 7, 2, 7},
                StackMode = StackMode.Values,
                DataLabels = true,
                Title = "Cards"
                }*/
            };


            

            
            Formatter = value => value + " $";

            //=======================================

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

        public static ClientsListingViewModel LoadViewModel(BankStore bankStore, AccountStore accountStore,/*IRequestsToApiService requestService,*/ IClientsProvider clientsProvider, IContractsProvider contractsProvider,
            NavigationViewModel navigationViewModel, NavigationStore navigationStore)
        {
            ClientsListingViewModel viewModel = new ClientsListingViewModel(bankStore, accountStore, /*requestService,*/ navigationViewModel, navigationStore, clientsProvider, contractsProvider);

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

            //Labels = new string[Clients.Count];
            //adding values also updates and animates
            //SeriesCollection[2].Values.Add(4d);
            /*for (int i = 0; i < Clients.Count; i++)
            {
                Labels[i] = Clients[i].ClientName;
                //SeriesCollection[0].Values.Add(Clients[i].)
            }*/
        }
    }
}
