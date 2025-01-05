
using BankWPFCore.Stores;
using BankWPFCore.ViewModels;
using System.Threading.Tasks;

namespace BankWPFCore.Commands
{
    internal class ConnectionCommand : BaseAsyncCommand
    {

        private BankStore _bankStore;
        private NavigationViewModel _navigationViewModel;
        private NavigationStore _navigationStore;


        public ConnectionCommand(BankStore bankStore, NavigationViewModel navigationViewModel, NavigationStore navigationStore)
        {
            _bankStore = bankStore;
            _navigationViewModel = navigationViewModel;
            _navigationStore = navigationStore;
        }

        public override async Task ExecuteAsync()
        {

            _bankStore.ReLoadBank();


            if (_navigationStore.CurrentViewModel.GetType() == typeof(ClientsListingViewModel))
            {
                _navigationViewModel.NavigateClientsViewCommand.Execute(_bankStore);
            }
            else if (_navigationStore.CurrentViewModel.GetType() == typeof(ContractsListingViewModel))
            {
                _navigationViewModel.NavigateContractsViewCommand.Execute(_bankStore);
            }
        }
    }
}
