using BankWPFCore.Commands;
using BankWPFCore.Models;
using BankWPFCore.Services.ApiServices.Providers;
using BankWPFCore.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace BankWPFCore.ViewModels
{
    internal class ContractBlankViewModel : BaseViewModel , INotifyDataErrorInfo
    {

        private readonly IClientsProvider _clientsProvider;

        private readonly ErrorViewModel _errorViewModel;

        private Contract _contract;

        private Client _client;

        //private string _clientName;

        public ICommand PostContractCommand { get; }

        public ICommand GetUserData { get; }

        public ICommand OpenContractBlankCommand { get; }


        public Client Client
        {
            get
            {

                return _client;//_contract.ClientID;
            }
            set
            {
                //_contract.ClientID = value;
                _client = value;
                //ClientID = _client.ClientId;
                //ClientName = _client.ClientName;
                OnPropertyChanged(nameof(Client));
                OnPropertyChanged(nameof(ClientName));
            }
        }

        public Contract Contract
        {
            get
            {

                return _contract;//_contract.ClientID;
            }
            set
            {
                //_contract.ClientID = value;
                _contract = value;
                //ClientID = _client.ClientId;
                //ClientName = _client.ClientName;
                OnPropertyChanged(nameof(Contract));
            }
        }


        #region Поля представления

        public NavigationViewModel NavigationViewModel { get; }

        public int ClientID
        {
            get
            {

                return _contract.ClientID;
            }
            set
            {
                _contract.ClientID = value;
                //_client.ClientId = value;
                OnPropertyChanged(nameof(ClientID));
            }
        }

        public string ClientName
        {
            get
            {
                //return _clientName;
                return _client.ClientName;
            }
            set
            {
                //_clientName = value;
                _client.ClientName = value;
                OnPropertyChanged(nameof(ClientName));
            }
        }

        public int ContractID
        {
            get
            {
                return _contract.ContractID;
            }
            set
            {
                _contract.ContractID = value;
                OnPropertyChanged(nameof(ContractID));
            }
        }

        public string Description
        {
            get { return _contract.Description; }
            set
            {
                _contract.Description = value;
                OnPropertyChanged(nameof(Description));

                _errorViewModel.ClearErrors(nameof(Description));

                if (Description.Length == 0 || Description.Contains(' '))
                {
                    _errorViewModel.AddError(nameof(Description), "Заполните поле!");
                }

                
                
            }
        }


        public /*string*/ float ContractAmount
        {
            get { return _contract.ContractAmount; }
            set
            {
                _contract.ContractAmount = value;
                OnPropertyChanged(nameof(ContractAmount));

                _errorViewModel.ClearErrors(nameof(ContractAmount));

                if (ContractAmount <= 0)
                {
                    _errorViewModel.AddError(nameof(ContractAmount), "Значение не может быть отрицательным!");
                }
            }
        }

        public /*string*/DateTime StartDate
        {
            get { return _contract.StartDate; }
            set
            {
                _contract.StartDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public /*string*/DateTime EndDate
        {
            get { return _contract.EndDate; }
            set
            {
                _contract.EndDate = value;
                OnPropertyChanged(nameof(EndDate));

                
            }
        }

        #endregion

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

        public ContractBlankViewModel(
            BankStore bankStore,
            AccountStore accountStore,
            NavigationViewModel navigationViewModel,
            Client client,
            Contract contract = null)
        {

            NavigationViewModel = navigationViewModel;

            _errorViewModel = new ErrorViewModel();
            _errorViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            _canChange = accountStore.CurrentAccount.Permission;

            
            if (contract == null)
            {
                Contract = new Contract();
                Description = string.Empty;
                ContractAmount = 0;//string.Empty;
            }
            else
                Contract = contract;



            if (client != null)
            {
                Client = client;
                this.ClientID = Client.ClientId;
            }
            else
                Client = new Client();

            PostContractCommand = new PostContractCommand(bankStore, _contract);

            if(Client.ClientId == 0)
                GetUserData = new LoadSelectedContractCommand(this, bankStore);

        }

        

        public static ContractBlankViewModel LoadContractCardViewModel(
            BankStore bank,
            AccountStore accountStore,
            NavigationViewModel navigationViewModel,
            NavigationStore navigationStore,
            IClientsProvider clientsProvider,
            Client client,
            Contract contract = null)
        {
            ContractBlankViewModel clientCardViewModel = new ContractBlankViewModel(bank,accountStore, navigationViewModel, /*navigationStore,*/ /*clientsProvider,*/ client, contract);

           
            clientCardViewModel.GetUserData?.Execute(clientCardViewModel);

            return clientCardViewModel;
        }

        ~ContractBlankViewModel() { }
    }
}
