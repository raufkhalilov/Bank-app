using BankWPF.Commands;
using BankWPF.Models;
using BankWPF.Stores;
using BankWPFCore.Services.ApiServices.Get;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    internal class ContractBlankViewModel : BaseViewModel
    {

        private readonly IClientsProvider _clientsProvider;

        private readonly Contract _contract;

        private readonly Client _client;

        private string _clientName;


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
                OnPropertyChanged(nameof(ClientID));
            }
        }

        public string ClientName
        {
            get
            {
                return _clientName;
            }
            set
            {
                _clientName = value;
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


        public ICommand PostContractCommand { get; }

        public ICommand GetUserData { get; }

        public ICommand OpenContractBlankCommand { get; }

        public ContractBlankViewModel(
            BankStore bankStore, 
            NavigationViewModel navigationViewModel, 
            NavigationStore navigationStore,
            IClientsProvider clientsProvider,
            Client client,
            Contract contract = null)
        {

            if (contract == null)
                _contract = new Contract();
            else
                _contract = contract;


            NavigationViewModel = navigationViewModel;

            _clientsProvider = clientsProvider;

            ClientID = client.ClientId;
            ClientName = client.ClientName;

            PostContractCommand = new PostContractCommand(bankStore, contract);

            //GetUserData = new LoadSelectedContractCommand(this, clientsProvider);


        }

        public static ContractBlankViewModel LoadContractCardViewModel(
            BankStore bank, 
            NavigationViewModel navigationViewModel, 
            NavigationStore navigationStore, 
            IClientsProvider clientsProvider, 
            Client client,
            Contract contract = null)
        {
            ContractBlankViewModel clientCardViewModel = new ContractBlankViewModel(bank, navigationViewModel, navigationStore, clientsProvider,client, contract);

            //clientCardViewModel.GetUserData.Execute(clientCardViewModel);

            return clientCardViewModel;
        }
    }
}
