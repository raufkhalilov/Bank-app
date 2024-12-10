using BankWPF.Commands;
using BankWPF.Models;
using BankWPF.Services;
using BankWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    internal class NavigationViewModel : BaseViewModel
    {
        //private readonly BankStore _bankStore;

        public ICommand NavigateStartViewCommand { get; }
        public ICommand NavigateClientsViewCommand { get; }
        public ICommand NavigateContractsViewCommand { get; }

        public ICommand ConnectToApiCommand { get; } //


        public NavigationViewModel(NavigationService<StartViewModel> startNavigationService,
            NavigationService<ClientsListingViewModel> clientsNavigationService,
            NavigationService<ContractsListingViewModel> contractNavigateService,
            BankStore bankStore)
        {
            NavigateStartViewCommand = new NavigationCommand<StartViewModel>(startNavigationService);
            NavigateClientsViewCommand = new NavigationCommand<ClientsListingViewModel>(clientsNavigationService);
            NavigateContractsViewCommand = new NavigationCommand<ContractsListingViewModel>(contractNavigateService);

            //====

            ConnectToApiCommand = new HelperPostDataCommand(bankStore, this);
        }
    }
}