using System.Collections.ObjectModel;
using System.Windows.Input;
using BankWPFCore.Stores;
using BankWPFCore.Models;
using BankWPFCore.Services.ApiServices.Providers;
using BankWPFCore.Commands;
using BankWPFCore.Services;
using System.Linq.Expressions;

namespace BankWPFCore.ViewModels
{
    internal class ClientBlankViewModel : BaseViewModel
    {

        //private readonly IRequestsToApiService _requestsToApiService;

        private readonly Client _client;
        private ObservableCollection<Contract> _clientsActiveContracts;


        public NavigationViewModel NavigationViewModel { get; }

        public int ClientID
        {
            get { return _client.ClientId; }
            set
            {
                _client.ClientId = value;
                OnPropertyChanged("ClientID");
            }
        }

        public string ClientName
        {
            get { return _client.ClientName; }
            set
            {
                _client.ClientName = value;
                OnPropertyChanged("ClientName");
            }
        }

        public string PhoneNumber
        {
            get { return _client.PhoneNumber; }
            set
            {
                _client.PhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public ObservableCollection<Contract> ClientsActiveContracts
        {
            get
            {
                return _clientsActiveContracts;
            }
            set
            {
                _clientsActiveContracts = value;
                OnPropertyChanged(nameof(ClientsActiveContracts));
            }
        }

        private Contract _selectedContract;

        public Contract SelectedContract
        {
            get { return _selectedContract; }
            set
            {
                _selectedContract = value;
                OnPropertyChanged("SelectedContract");
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

        //===================================

        private bool _canChange;

        public bool CanChange
        {
            get
            {
                return _canChange;
            }
            set
            {
                _canChange = value;
                OnPropertyChanged(nameof(CanChange));
            }
        }

        //===================================

        public ICommand PostDataCommand { get; }

        public ICommand GetUserContracts { get; }

        public ICommand OpenContractBlankCommand { get; }

        public ICommand ReturnToClientsViewCommand { get; }

        public ICommand DblOpenContractCardCommand { get; }

        public ClientBlankViewModel(
            BankStore bankStore,
            AccountStore accountStore,
            NavigationViewModel navigationViewModel,
            NavigationStore navigationStore,
            
            IClientsProvider clientsProvider,
            IContractsProvider contractsProvider,
            Client client = null)
        {

            bool loadContracts = false;

            _canChange = accountStore.CurrentAccount.Permission;

            if (client == null)
                _client = new Client();
            else
            {
                _client = client;
                loadContracts = true;
            }

            NavigationViewModel = navigationViewModel;

            //_requestsToApiService = new RequestsToApiService();

            //PostDataCommand = new PostDataCommand<Client>(bankStore, _requestsToApiService, _client);

            PostDataCommand = new PostClientCommand(bankStore, _client, navigationViewModel,  
                new NavigationService<ClientsListingViewModel>(navigationStore, 
                () => ClientsListingViewModel.LoadViewModel(bankStore, accountStore, clientsProvider, contractsProvider, navigationViewModel, navigationStore)));

            GetUserContracts = new LoadUserContractsCommand(this, bankStore._bank, contractsProvider, loadContracts);

            OpenContractBlankCommand = new NavigationCommand<ContractBlankViewModel>(new NavigationService<ContractBlankViewModel>(navigationStore,
                () => ContractBlankViewModel.LoadContractCardViewModel(bankStore, accountStore, navigationViewModel, navigationStore, clientsProvider, client)));

            ReturnToClientsViewCommand = new NavigationCommand<ClientsListingViewModel>(new NavigationService<ClientsListingViewModel>(navigationStore, 
                () => ClientsListingViewModel.LoadViewModel(bankStore, accountStore, clientsProvider, contractsProvider, navigationViewModel, navigationStore)));

            DblOpenContractCardCommand = new NavigationCommand<ContractBlankViewModel>(new NavigationService<ContractBlankViewModel>(navigationStore,
                () => ContractBlankViewModel.LoadContractCardViewModel(bankStore, accountStore, navigationViewModel, navigationStore, clientsProvider, client, SelectedContract)));


        }

        public static ClientBlankViewModel LoadClientCardViewModel(BankStore bankStore, AccountStore accountStore, NavigationViewModel navigationViewModel, NavigationStore navigationStore, /*NavigationService<ClientsListingViewModel> navigationService,*/ IClientsProvider clientsProvider, IContractsProvider contractsProvider, Client client = null)
        {
            ClientBlankViewModel clientCardViewModel = new ClientBlankViewModel(bankStore, accountStore, navigationViewModel, navigationStore, clientsProvider, contractsProvider, client);

            clientCardViewModel.GetUserContracts.Execute(clientCardViewModel);


            return clientCardViewModel;
        }

        ~ClientBlankViewModel() { }

    }
}
