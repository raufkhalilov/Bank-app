using BankWPF.Commands;
using BankWPF.Models;
using BankWPF.Services;
using BankWPF.Stores;
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


        private readonly IRequestsToApiService _requestsToApiService;

        private readonly Contract _contract;


        public NavigationViewModel NavigationViewModel { get; }

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


        public ICommand PostDataCommand { get; }

        public ICommand GetUserContracts { get; }

        public ICommand OpenContractBlankCommand { get; }

        public ContractBlankViewModel(BankStore bankStore, NavigationViewModel navigationViewModel, NavigationStore navigationStore, Contract contract = null)
        {

            if (contract == null)
                _contract = new Contract();
            else
                _contract = contract;


            NavigationViewModel = navigationViewModel;

            _requestsToApiService = new RequestsToApiService();

            //PostDataCommand = new RelayCommand(PostClientData);

            PostDataCommand = new PostDataCommand<Contract>(bankStore, _requestsToApiService, _contract);

            //GetUserContracts = new LoadUserContractsCommand(this, _requestsToApiService);

            OpenContractBlankCommand = new NavigationCommand<ContractBlankViewModel>(new NavigationService<ContractBlankViewModel>(navigationStore,
                () => ContractBlankViewModel.LoadContractCardViewModel(bankStore, navigationViewModel, navigationStore)));

        }

        public static ContractBlankViewModel LoadContractCardViewModel(BankStore bank, NavigationViewModel navigationViewModel, NavigationStore navigationStore, Contract contract = null)
        {
            ContractBlankViewModel clientCardViewModel = new ContractBlankViewModel(bank, navigationViewModel, navigationStore, contract);

            //clientCardViewModel.GetUserContracts.Execute(clientCardViewModel);


            return clientCardViewModel;
        }
    }
}
