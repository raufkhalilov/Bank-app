using BankWPF.Classes;
using BankWPF.Models;
using BankWPF.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics.Contracts;
using Contract = BankWPF.Models.Contract;
using BankWPF.Commands;

namespace BankWPF.ViewModels
{
    internal class ContractsViewModel : BaseViewModel
    {

        private ObservableCollection<Contract> contracts;

        #region Поля модели представления
        public ObservableCollection<Contract> Contracts
        {
            get
            {
                return contracts;
            }
            set
            {
                contracts = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public NavigationViewModel NavigationViewModel { get; }

        //private readonly IRequestsToApiService _requestsToApiService;

        //public ICommand GetDataCommand { get; }
        public ICommand LoadContractsCommand { get; }

        public ContractsViewModel(NavigationViewModel navigationViewModel, IRequestsToApiService requestsToApiService)
        {

            NavigationViewModel = navigationViewModel;

            Contracts = new ObservableCollection<Contract>();

            //_requestsToApiService = requestsToApiService;
            //GetDataCommand = new RelayCommand(LoadData);

            LoadContractsCommand = new LoadContractsCommand(this, requestsToApiService);
        }

        //=============================================


        public static ContractsViewModel LoadViewModel(NavigationViewModel navigationViewModel, IRequestsToApiService requestsToApiService)
        {
            ContractsViewModel viewModel = new ContractsViewModel(navigationViewModel, requestsToApiService/*, navigationStore*/);

            viewModel.LoadContractsCommand.Execute(viewModel);

            return viewModel;
        }

        //=============================================

    }
}
