using BankWPF.Services;
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
        private readonly RequestsToApiService _requestsToApiService;
        private readonly NavigationStore _navigationStore;
        private readonly NavigationViewModel _navigationViewModel;

        public App()
        {
            _requestsToApiService = new RequestsToApiService();
            _navigationStore = new NavigationStore();
            _navigationViewModel = new NavigationViewModel(
                CreateStartNavigationService(),
                CreateClientsNavigationService(),
                CreateContractsNavigationService());
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            //var dialogService = new DialogService();
            //var reqToApi = new RequestsToApiService();

            

            //_navigationStore.CurrentViewModel = new StartViewModel(_navigationStore);

            NavigationService<StartViewModel> startNavigationService = CreateStartNavigationService();
            startNavigationService.Navigate();

            //var dialogService = new DialogService();
            //var mainViewModel = new StartViewModel(dialogService);

            //startWindow = new StartWindow { DataContext = mainViewModel };
            var startWindow = new MainWindow
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            startWindow.Show();

            base.OnStartup(e);
        }

        private NavigationService<StartViewModel> CreateStartNavigationService()
        {
            return new NavigationService<StartViewModel>(_navigationStore, 
                ()=>new StartViewModel(_navigationViewModel/*,_navigationStore*/));
        }

        private NavigationService<ClientsViewModel> CreateClientsNavigationService()
        {
            return new NavigationService<ClientsViewModel>(_navigationStore, 
                () => ClientsViewModel.LoadViewModel(_requestsToApiService, _navigationViewModel/*, _navigationStore*/));
        }

        private NavigationService<ContractsViewModel> CreateContractsNavigationService()
        {
            return new NavigationService<ContractsViewModel>(_navigationStore, 
                () => ContractsViewModel.LoadViewModel(_navigationViewModel, _requestsToApiService/*, _navigationStore*/));
        }
        /*
                private StartViewModel CreateStartViewModel()
                {
                    //return new StartViewModel(new NavigationService(_navigationStore, CreateClientsViewModel));
                }

                private ClientsViewModel CreateClientsViewModel()
                {
                    var dialogService = new DialogService();
                    var reqToApi = new RequestsToApiService();

                    //return new ClientsViewModel(reqToApi, dialogService);
                }*/
    }
}

