using BankWPFCore.Commands;
using BankWPFCore.Services;
using BankWPFCore.Stores;
using System.Windows.Input;

namespace BankWPFCore.ViewModels
{
    internal class NavigationViewModel : BaseViewModel
    {
        //private readonly BankStore _bankStore;

        public ICommand NavigateStartViewCommand { get; }
        public ICommand NavigateClientsViewCommand { get; }
        public ICommand NavigateContractsViewCommand { get; }
        //public ICommand NavigateClientBlankViewCommand { get; }
        //public ICommand NavigateContractBlankViewCommand { get; }

        public ICommand ConnectToApiCommand { get; } //


        public NavigationViewModel(NavigationService<StartViewModel> startNavigationService,
            NavigationService<ClientsListingViewModel> clientsNavigationService,
            NavigationService<ContractsListingViewModel> contractNavigateService,
            /*NavigationService<ClientBlankViewModel> clientBlankViewModel,*/
            /*NavigationService<ContractBlankViewModel> contractBlankViewModel,*/
            BankStore bankStore,
            NavigationStore navigationStore)
        {
            NavigateStartViewCommand = new NavigationCommand<StartViewModel>(startNavigationService);
            NavigateClientsViewCommand = new NavigationCommand<ClientsListingViewModel>(clientsNavigationService);
            NavigateContractsViewCommand = new NavigationCommand<ContractsListingViewModel>(contractNavigateService);

            //====

            //NavigateClientBlankViewCommand = new NavigationCommand<ClientBlankViewModel>(clientBlankViewModel);
            //NavigateContractBlankViewCommand = new NavigationCommand<ContractBlankViewModel>(contractBlankViewModel);

            //===

            ConnectToApiCommand = new ConnectionCommand(bankStore, this, navigationStore);
        }
    }
}