using BankWPF.Models;
using BankWPF.Services;
using BankWPF.Services.ApiServices;
using BankWPF.Stores;
using BankWPF.ViewModels;
using BankWPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Bank _bank;
        private readonly BankStore _bankStore;
        private readonly ClientsBook _clientsBook;
        private readonly ContractsBook _contractsBook;

        private readonly IClientCreator _clientCreator;
        private readonly IContractCreator _contractCreator;
        private readonly IClientsProvider _clientsProvider;
        private readonly IContractsProvider _contractsProvider;

        private readonly IRequestsToApiService _requestsToApiService;
        private readonly IAuthService _authService;

        private readonly NavigationStore _navigationStore;
        private readonly NavigationViewModel _navigationViewModel;


        public App()
        {
           
            _requestsToApiService = new RequestsToApiService();

            _authService = new AuthenicationService(/*_requestsToApiService*/); // soon

            _clientsProvider = new ApiClientsProvider(_requestsToApiService);
            _clientCreator = new ApiClientCreator(_requestsToApiService);
            _contractCreator = new ApiContractCreator(_requestsToApiService);
            _contractsProvider = new ApiContractsProvider(_requestsToApiService);

            _clientsBook = new ClientsBook(_clientsProvider, _clientCreator);
            _contractsBook = new ContractsBook(_contractCreator, _contractsProvider);
            _bank = new Bank("BGRT", _clientsBook, _contractsBook);
            _bankStore = new BankStore(_bank);

            _navigationStore = new NavigationStore(); //!
            _navigationViewModel = new NavigationViewModel(
                CreateStartNavigationService(),
                CreateClientsNavigationService(),
                CreateContractsNavigationService(),
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
                () => ClientsListingViewModel.LoadViewModel(_bankStore, _clientsProvider, _contractsProvider, _navigationViewModel, _navigationStore));
        }

        private NavigationService<ContractsListingViewModel> CreateContractsNavigationService()
        {
            return new NavigationService<ContractsListingViewModel>(_navigationStore, 
                () => ContractsListingViewModel.LoadViewModel(_navigationViewModel,_bankStore,_navigationStore,_clientsProvider));
        }
/*
        private NavigationService<ClientBlankViewModel> CreateClientCardNavigationService()
        {
            return new NavigationService<ClientBlankViewModel>(_navigationStore, 
                () => new ClientBlankViewModel(_bank,_navigationViewModel, _navigationStore));
                
        }*/
       
    }
}

