using BankWPFCore.Stores;

namespace BankWPFCore.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;


        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(/**/NavigationStore navigationStore)
        {

            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += CurrentViewModelChanged;

        }

        private void CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
