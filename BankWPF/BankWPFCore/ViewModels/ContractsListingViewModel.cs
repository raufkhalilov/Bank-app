using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BankWPFCore.Stores;
using BankWPFCore.Models;
using BankWPFCore.Services.ApiServices.Providers;
using BankWPFCore.Commands;
using BankWPFCore.Services;
using System.Linq;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace BankWPFCore.ViewModels
{
    internal class ContractsListingViewModel : BaseViewModel
    {

        private readonly BankStore _bankStore;



        private Contract _selectedContract;

        public Contract SelectedContract
        {
            get
            {
                return _selectedContract;
            }
            set
            {
                _selectedContract = value;
                OnPropertyChanged(nameof(SelectedContract));
            }
        }


        private ObservableCollection<Contract> _contracts;
       
        public ObservableCollection<Contract> Contracts
        {
            get
            {
                return _contracts;
            }
            set
            {
                _contracts = value;
                //OnPropertyChanged(nameof(Contracts));
                //ApplyFilter();
            }
        }

        //===================================

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                ApplyFilter();
            }
        }

        private ObservableCollection<Contract> _filteredData;

        public ObservableCollection<Contract> FilteredData 
        {
            get
            {
                return _filteredData;
            }
            set
            {
                _filteredData = value;
                OnPropertyChanged(nameof(FilteredData));
                //ApplyFilter();
            }
        }

        private void ApplyFilter()
        {
            // Implement logic to filter Data based on SearchText
            var bufContracts = new List<Contract>(Contracts);
            FilteredData = new ObservableCollection<Contract>(bufContracts.Where(item => item.Description.Contains(SearchText) || (item.ContractID.ToString()).Contains(SearchText) || item.ClientID.ToString().Contains(SearchText)));
        }

        //===================================

        #region Вспомогательные поля

        private bool _isLoading;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(_errorMessage);

        #endregion

        public NavigationViewModel NavigationViewModel { get; }

        //private readonly IRequestsToApiService _requestsToApiService;

        //public ICommand GetDataCommand { get; }
        public ICommand LoadContractsCommand { get; }

        public ICommand DblOpenContractCardCommand { get; }

        public ContractsListingViewModel(NavigationViewModel navigationViewModel, BankStore bankStore, AccountStore accountStore, NavigationStore navigationStore, /*IRequestsToApiService requestsToApiService,*/ IClientsProvider clientsProvider)
        {
            _bankStore = bankStore;

            NavigationViewModel = navigationViewModel;

            Contracts = new ObservableCollection<Contract>();

            //_requestsToApiService = requestsToApiService;
            //GetDataCommand = new RelayCommand(LoadData);

            LoadContractsCommand = new LoadContractsCommand(this, bankStore/*, requestsToApiService*/);

            //Contract contract = new Contract();
            //contract = SelectedContract;

            DblOpenContractCardCommand = new NavigationCommand<ContractBlankViewModel>(new NavigationService<ContractBlankViewModel>(navigationStore,
                () => ContractBlankViewModel.LoadContractCardViewModel(bankStore, accountStore, navigationViewModel, navigationStore, clientsProvider, null, (Contract)SelectedContract.Clone())));

            _bankStore.ContractAdded += OnContractMode;
        }

        //=============================================


        public static ContractsListingViewModel LoadViewModel(NavigationViewModel navigationViewModel, BankStore bankStore, AccountStore accountStore, NavigationStore navigationStore, /*IRequestsToApiService requestsToApiService,*/ IClientsProvider clientsProvider)
        {
            ContractsListingViewModel viewModel = new ContractsListingViewModel(navigationViewModel, bankStore, accountStore, navigationStore, /*requestsToApiService,*/ clientsProvider);

            viewModel.LoadContractsCommand.Execute(viewModel);

            viewModel.FilteredData = viewModel.Contracts;

            return viewModel;
        }

        //=============================================

        private void OnContractMode(Contract contract)
        {
            //Client client = new Client();
            _contracts.Add(contract);
        }

        public override void Dispose()
        {
            _bankStore.ContractAdded -= OnContractMode;
            base.Dispose();
        }

        //=============================================

        public void UpdateContractsList(IEnumerable<Contract> contracts)
        {
            _contracts.Clear();

            foreach (var contract in contracts)
            {
                _contracts.Add(contract);
            }
        }

        //=============================================
        //=============================================
        //=============================================

        

        

        

    }
}
