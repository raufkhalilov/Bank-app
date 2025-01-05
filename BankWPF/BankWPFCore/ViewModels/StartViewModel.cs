using BankWPFCore.Stores;

namespace BankWPFCore.ViewModels
{
    internal class StartViewModel : BaseViewModel
    {

        #region  need for navigation realisation
        private readonly NavigationStore _navigationStore;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public NavigationViewModel NavigationViewModel { get; }
        #endregion



        public StartViewModel(NavigationViewModel navigationViewModel/*, NavigationStore navigationStore*/)
        {

            NavigationViewModel = navigationViewModel;


        }


    }
}
