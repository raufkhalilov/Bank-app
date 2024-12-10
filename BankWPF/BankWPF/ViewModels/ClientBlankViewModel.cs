
using BankWPF.Commands;
using BankWPF.Models;
using BankWPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BankWPF.Stores;

namespace BankWPF.ViewModels
{
    internal class ClientBlankViewModel : BaseViewModel
    {

        private readonly IRequestsToApiService _requestsToApiService;
        
        private readonly Client _client;
        private ObservableCollection<Contract> _clientsActiveContracts;


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
                OnPropertyChanged("ClientName");
            }
        }

        public string PhoneNumber
        {
            get { return _client.PhoneNumber; }
            set
            {
                _client.PhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
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

        public ICommand PostDataCommand { get; }

        public ICommand GetUserContracts { get; }

        public ICommand OpenContractBlankCommand { get; }

        public ClientBlankViewModel(BankStore bankStore, NavigationViewModel navigationViewModel, NavigationStore navigationStore, Client client = null)
        {

            if (client == null)
                _client = new Client();
            else
                _client = client;
            

            NavigationViewModel = navigationViewModel;

            _requestsToApiService = new RequestsToApiService();

            //PostDataCommand = new PostDataCommand<Client>(bankStore, _requestsToApiService, _client);

            PostDataCommand = new PostClientCommand(bankStore, _requestsToApiService, _client);

            GetUserContracts = new LoadUserContractsCommand(this, _requestsToApiService);

            OpenContractBlankCommand = new NavigationCommand<ContractBlankViewModel>(new NavigationService<ContractBlankViewModel>(navigationStore,
                () => ContractBlankViewModel.LoadContractCardViewModel(bankStore, navigationViewModel, navigationStore)));

        }

        public static ClientBlankViewModel LoadClientCardViewModel(BankStore bankStore, NavigationViewModel navigationViewModel, NavigationStore navigationStore, Client client = null)
        {
            ClientBlankViewModel clientCardViewModel = new ClientBlankViewModel(bankStore, navigationViewModel, navigationStore, client);

            clientCardViewModel.GetUserContracts.Execute(clientCardViewModel);

            
            return clientCardViewModel;
        }

    }
}
