using BankWPFCore.Models;
using BankWPFCore.Services;
using BankWPFCore.Services.ApiServices;
using BankWPFCore.Services.ApiServices.Creators;
using BankWPFCore.Services.ApiServices.Providers;
using BankWPFCore.Services.AuthenticationServices;
using BankWPFCore.Services.ConflictValidators.ClientConflictValidators;
using BankWPFCore.Stores;
using BankWPFCore.ViewModels;
using BankWPFCore.Views;
using System.Windows;

namespace BankWPFCore
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Bank _bank;
        private readonly BankStore _bankStore;
        private readonly Account _account;
        private readonly AccountStore _accountStore;
        private readonly ClientsBook _clientsBook;
        private readonly ContractsBook _contractsBook;

        //private readonly 

        private readonly IClientCreator _clientCreator;
        private readonly IContractCreator _contractCreator;
        private readonly IClientsProvider _clientsProvider;
        private readonly IContractsProvider _contractsProvider;

        private readonly IClientConflictValidator _clientConflictValidator;

        private readonly IRequestsToApiService _requestsToApiService;
        private readonly IAuthService _authService;

        private readonly NavigationStore _navigationStore;
        private readonly NavigationViewModel _navigationViewModel;


        public App()
        {
           
            _requestsToApiService = new RequestsToApiService();

            _account = new Account();
            _accountStore = new AccountStore(_account);

            _authService = new AuthenicationService(/*_requestsToApiService*/_accountStore,"./config.json"); // soon

            _clientsProvider = new ApiClientsProvider(_requestsToApiService);
            _clientCreator = new ApiClientCreator(_requestsToApiService);
            _contractCreator = new ApiContractCreator(_requestsToApiService);
            _contractsProvider = new ApiContractsProvider(_requestsToApiService);

            _clientConflictValidator = new ApiClientConflictValidator(_clientsProvider);

            _clientsBook = new ClientsBook(_clientsProvider, _clientCreator, _clientConflictValidator);
            _contractsBook = new ContractsBook(_contractCreator, _contractsProvider);
            _bank = new Bank("BGRT", _clientsBook, _contractsBook);
            _bankStore = new BankStore(_bank);

            _navigationStore = new NavigationStore(); //!
            _navigationViewModel = new NavigationViewModel(
                CreateStartNavigationService(),
                CreateClientsNavigationService(),
                CreateContractsNavigationService(),
                /*CreateClientCardNavigationService(),*/
                _bankStore, _navigationStore);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
    
            //NavigationService<StartViewModel> startNavigationService = CreateStartNavigationService();
            //startNavigationService.Navigate();

            NavigationService<LoginViewModel> loginNavigationService = CreateLoginViewModel();
            loginNavigationService.Navigate();

            var startWindow = new MainWindow
            {
                DataContext = new MainViewModel(_navigationStore) //!
            };

            startWindow.Show();

            base.OnStartup(e);
        }

        private NavigationService<LoginViewModel> CreateLoginViewModel()
        {
            return new NavigationService<LoginViewModel>(_navigationStore, 
                () => new LoginViewModel(_navigationStore, _navigationViewModel, _authService));
        }

        private NavigationService<StartViewModel> CreateStartNavigationService()
        {
            return new NavigationService<StartViewModel>(_navigationStore, 
                ()=>new StartViewModel(_navigationViewModel));
        }

        private NavigationService<ClientsListingViewModel> CreateClientsNavigationService()
        {
            return new NavigationService<ClientsListingViewModel>(_navigationStore, 
                () => ClientsListingViewModel.LoadViewModel(_bankStore, _accountStore, _clientsProvider, _contractsProvider, _navigationViewModel, _navigationStore));
        }

        private NavigationService<ContractsListingViewModel> CreateContractsNavigationService()
        {
            return new NavigationService<ContractsListingViewModel>(_navigationStore, 
                () => ContractsListingViewModel.LoadViewModel(_navigationViewModel,_bankStore, _accountStore, _navigationStore,_clientsProvider));
        }

        /*private NavigationService<ClientBlankViewModel> CreateClientCardNavigationService()
        {
            return new NavigationService<ClientBlankViewModel>(_navigationStore, 
                () => new ClientBlankViewModel(_bankStore,_navigationViewModel, _navigationStore, _clientsProvider, _contractsProvider));
                
        }*/

       /* private NavigationService<ContractBlankViewModel> CreateontracttCardNavigationService()
        {
            return new NavigationService<ContractBlankViewModel>(_navigationStore,
                () => new ContractBlankViewModel(_bankStore, _navigationViewModel, _navigationStore, _clientsProvider));

        }*/

    }
}

