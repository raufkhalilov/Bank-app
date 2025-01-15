using BankWPFCore.Commands;
using BankWPFCore.Services;
using BankWPFCore.Stores;
using System.Windows.Input;

namespace BankWPFCore.ViewModels
{
    internal class NavigationViewModel : BaseViewModel
    {
        //private readonly BankStore _bankStore;
        private readonly AccountStore _accountStore;

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


        public ICommand NavigateStartViewCommand { get; }
        public ICommand NavigateClientsViewCommand { get; }
        public ICommand NavigateContractsViewCommand { get; }
        public ICommand NavigateSettingsViewCommand { get; }
        //public ICommand NavigateClientBlankViewCommand { get; }
        //public ICommand NavigateContractBlankViewCommand { get; }

        public ICommand ConnectToApiCommand { get; } //


        public NavigationViewModel(NavigationService<StartViewModel> startNavigationService,
            NavigationService<ClientsListingViewModel> clientsNavigationService,
            NavigationService<ContractsListingViewModel> contractNavigateService,
            NavigationService<SettingsViewModel> settingsNavigationService,
            /*NavigationService<ClientBlankViewModel> clientBlankViewModel,*/
            /*NavigationService<ContractBlankViewModel> contractBlankViewModel,*/
            BankStore bankStore,
            AccountStore accountStore,
            NavigationStore navigationStore)
        {
            NavigateStartViewCommand = new NavigationCommand<StartViewModel>(startNavigationService);
            NavigateClientsViewCommand = new NavigationCommand<ClientsListingViewModel>(clientsNavigationService);
            NavigateContractsViewCommand = new NavigationCommand<ContractsListingViewModel>(contractNavigateService);
            NavigateSettingsViewCommand = new NavigationCommand<SettingsViewModel>(settingsNavigationService);
            //====

            //NavigateClientBlankViewCommand = new NavigationCommand<ClientBlankViewModel>(clientBlankViewModel);
            //NavigateContractBlankViewCommand = new NavigationCommand<ContractBlankViewModel>(contractBlankViewModel);

            //===

            ConnectToApiCommand = new ConnectionCommand(bankStore, this, navigationStore);
            _accountStore = accountStore;
            accountStore.CurrentAccountChanged += CurrentAccountChanged;
        }

        private void CurrentAccountChanged()
        {
            CanChange = _accountStore.CurrentAccount.Permission;
        }
    }
}