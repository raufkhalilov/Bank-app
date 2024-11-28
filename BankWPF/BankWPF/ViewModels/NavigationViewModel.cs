using BankWPF.Commands;
using BankWPF.Services;
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
        public ICommand NavigateStartViewCommand {  get; }
        public ICommand NavigateClientsViewCommand { get; }
        public ICommand NavigateContractsViewCommand { get; }
        

        public NavigationViewModel(NavigationService<StartViewModel> startNavigationService,
            NavigationService<ClientsViewModel> clientsNavigationService,
            NavigationService<ContractsViewModel> contractNavigateService) 
        {
            NavigateStartViewCommand = new NavigationCommand<StartViewModel>(startNavigationService);
            NavigateClientsViewCommand = new NavigationCommand<ClientsViewModel>(clientsNavigationService);
            NavigateContractsViewCommand = new NavigationCommand<ContractsViewModel>(contractNavigateService);
        }
    }

}
