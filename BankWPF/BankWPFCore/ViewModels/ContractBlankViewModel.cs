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
    internal class ContractBlankViewModel : BaseViewModel
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

                if (Description.Length == 0)
                {
                    _errorViewModel.AddError("Заполните поле!", nameof(Description));
                }    
            }
        }


        public string ContractAmount
        {
            get { return _contract.ContractAmount; }
            set
            {
                _contract.ContractAmount = value;
                OnPropertyChanged(nameof(ContractAmount));
            }
        }

        public string StartDate
        {
            get { return _contract.StartDate; }
            set
            {
                _contract.StartDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public string EndDate
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

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool CanUse => !_errorViewModel.HasErrors; //Поле отвечает за возможность добавить новый договор в зависимости от наличия ошибок

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanUse));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorViewModel.GetErrors(propertyName);
             
                /*_propertyNameToErrorDictionary
                .GetValueOrDefault(propertyName, new List<string>());*/
        }

        #endregion

        public ContractBlankViewModel(
            BankStore bankStore,
            AccountStore accountStore,
            NavigationViewModel navigationViewModel,
           /* NavigationStore navigationStore,*/
            /*IClientsProvider clientsProvider,*/
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
            }
            else
                Contract = contract;


            if (client != null)
                Client = client;
            else
                Client = new Client();

            PostContractCommand = new PostContractCommand(bankStore, contract);

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
