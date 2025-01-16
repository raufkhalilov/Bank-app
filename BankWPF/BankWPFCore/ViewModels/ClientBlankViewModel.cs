using System.Collections.ObjectModel;
using System.Windows.Input;
using BankWPFCore.Stores;
using BankWPFCore.Models;
using BankWPFCore.Services.ApiServices.Providers;
using BankWPFCore.Commands;
using BankWPFCore.Services;
using System.Linq.Expressions;
using System.ComponentModel;
using System;
using System.Collections;

namespace BankWPFCore.ViewModels
{
    internal class ClientBlankViewModel : BaseViewModel, INotifyDataErrorInfo
    {

        //private readonly IRequestsToApiService _requestsToApiService;

        private readonly Client _client;
        private ObservableCollection<Contract> _clientsActiveContracts;

        private int _clientAge;
        private string _passportData;

        private readonly ErrorViewModel _errorViewModel;


        public NavigationViewModel NavigationViewModel { get; }

        public int ClientID
        {
            get { return _client.ClientId; }
            set
            {
                _client.ClientId = value;
                OnPropertyChanged("ClientID");
            }
        }

        public string ClientName
        {
            get { return _client.ClientName; }
            set
            {
                _client.ClientName = value;
                OnPropertyChanged(nameof(ClientName));

                _errorViewModel.ClearErrors(nameof(ClientName));

                if ((ClientName != string.Empty && ClientName?[0] == ' ') || ClientName.Length == 0)
                {
                    _errorViewModel.AddError(nameof(ClientName), "Значение не может быть отрицательным!");
                }
            }
        }

        public string PhoneNumber
        {
            get { return _client.PhoneNumber; }
            set
            {
                _client.PhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));

                _errorViewModel.ClearErrors(nameof(PhoneNumber));

                if (PhoneNumber.Contains('_'))
                {
                    _errorViewModel.AddError(nameof(PhoneNumber), "Значение не может быть отрицательным!");
                }
            }
        }

        public int ClientAge
        {
            get { return _clientAge; }
            set
            {
                _clientAge = value;
                OnPropertyChanged(nameof(ClientAge));

                _errorViewModel.ClearErrors(nameof(ClientAge));

                if (ClientAge <= 18 || ClientAge >= 120)
                {
                    _errorViewModel.AddError(nameof(ClientAge), "Некорректный возраст!");
                }
            }
        }

        public string PassportData
        {
            get { return _passportData; }
            set
            {
                _passportData = value;
                OnPropertyChanged(nameof(PassportData));

                _errorViewModel.ClearErrors(nameof(PassportData));

                if (PassportData.Contains('_'))
                {
                    _errorViewModel.AddError(nameof(PassportData), "Значение не может быть отрицательным!");
                }
            }
        }

        public ObservableCollection<Contract> ClientsActiveContracts
        {
            get
            {
                return _clientsActiveContracts;
            }
            set
            {
                _clientsActiveContracts = value;
                OnPropertyChanged(nameof(ClientsActiveContracts));
            }
        }

        private Contract _selectedContract;

        public Contract SelectedContract
        {
            get { return _selectedContract; }
            set
            {
                _selectedContract = value;
                OnPropertyChanged("SelectedContract");
            }
        }

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



        #region Контроль ввода

        public bool HasErrors => _errorViewModel.HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool CanUse => !HasErrors;


        public IEnumerable GetErrors(string propertyName)
        {
            return _errorViewModel.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanUse));
        }

        #endregion


        public ICommand PostDataCommand { get; }

        public ICommand GetUserContracts { get; }

        public ICommand OpenContractBlankCommand { get; }

        public ICommand ReturnToClientsViewCommand { get; }

        public ICommand DblOpenContractCardCommand { get; }

        public ClientBlankViewModel(
            BankStore bankStore,
            AccountStore accountStore,
            NavigationViewModel navigationViewModel,
            NavigationStore navigationStore,
            
            IClientsProvider clientsProvider,
            IContractsProvider contractsProvider,
            Client client = null)
        {

            bool loadContracts = false;

            _errorViewModel = new ErrorViewModel();
            _errorViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            _canChange = accountStore.CurrentAccount.Permission;

            if (client == null)
            {
                _client = new Client();
                ClientName=string.Empty;
                ClientAge = 0;
                PhoneNumber += "_";
                PassportData += "_";
            }
            else
            {
                _client = client;
                loadContracts = true;
            }

            NavigationViewModel = navigationViewModel;

            //_requestsToApiService = new RequestsToApiService();

            //PostDataCommand = new PostDataCommand<Client>(bankStore, _requestsToApiService, _client);

            PostDataCommand = new PostClientCommand(bankStore, _client, navigationViewModel,  
                new NavigationService<ClientsListingViewModel>(navigationStore, 
                () => ClientsListingViewModel.LoadViewModel(bankStore, accountStore, clientsProvider, contractsProvider, navigationViewModel, navigationStore)));

            GetUserContracts = new LoadUserContractsCommand(this, bankStore._bank, contractsProvider, loadContracts);

            OpenContractBlankCommand = new NavigationCommand<ContractBlankViewModel>(new NavigationService<ContractBlankViewModel>(navigationStore,
                () => ContractBlankViewModel.LoadContractCardViewModel(bankStore, accountStore, navigationViewModel, navigationStore, clientsProvider, client)));

            ReturnToClientsViewCommand = new NavigationCommand<ClientsListingViewModel>(new NavigationService<ClientsListingViewModel>(navigationStore, 
                () => ClientsListingViewModel.LoadViewModel(bankStore, accountStore, clientsProvider, contractsProvider, navigationViewModel, navigationStore)));

            DblOpenContractCardCommand = new NavigationCommand<ContractBlankViewModel>(new NavigationService<ContractBlankViewModel>(navigationStore,
                () => ContractBlankViewModel.LoadContractCardViewModel(bankStore, accountStore, navigationViewModel, navigationStore, clientsProvider, client, SelectedContract)));


            
        }

        public static ClientBlankViewModel LoadClientCardViewModel(BankStore bankStore, AccountStore accountStore, NavigationViewModel navigationViewModel, NavigationStore navigationStore, /*NavigationService<ClientsListingViewModel> navigationService,*/ IClientsProvider clientsProvider, IContractsProvider contractsProvider, Client client = null)
        {
            ClientBlankViewModel clientCardViewModel = new ClientBlankViewModel(bankStore, accountStore, navigationViewModel, navigationStore, clientsProvider, contractsProvider, client);

            clientCardViewModel.GetUserContracts.Execute(clientCardViewModel);


            return clientCardViewModel;
        }

        ~ClientBlankViewModel() { }

    }
}
