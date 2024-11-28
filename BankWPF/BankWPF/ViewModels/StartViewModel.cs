using BankWPF.Classes;
using BankWPF.Commands;
using BankWPF.Services;
using BankWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    internal class StartViewModel : BaseViewModel
    {
        // команда добавления нового объекта
        /* private RelayCommand openClientWindowCommand;

         //private DialogService

         public RelayCommand OpenClientWindowCommand
         {
             get
             {
                 return openClientWindowCommand ??
                   (openClientWindowCommand = new RelayCommand(obj =>
                   {
                       //OpenDialog();
                   }));
             }
         }*/
        #region  need for navigation realisation
        private readonly NavigationStore _navigationStore;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public NavigationViewModel NavigationViewModel {  get; }
        #endregion


        //private readonly IDialogService _dialogService;
/*
        public ICommand OpenDialogCommand { get; }
        public ICommand ContractsDialogCommand { get; }

        public ICommand OpenClientsViewCommand { get; }
        public ICommand OpenContractsViewCommand { get; }
*/
        public StartViewModel(/*IDialogService dialogService,*/NavigationViewModel navigationViewModel/*, NavigationStore navigationStore*/)
        {
            //_dialogService = dialogService;
            //OpenDialogCommand = new RelayCommand(OpenDialog);
            //OpenDialogCommand = new LoadDataCommand();
            //ContractsDialogCommand = new RelayCommand(OpenContractDialog);
            NavigationViewModel = navigationViewModel;

            //OpenClientsViewCommand = new NavigationCommand<ClientsViewModel>(new NavigationService<ClientsViewModel>(navigationStore,
            //    ()=> new ClientsViewModel(new RequestsToApiService(),navigationViewModel, navigationStore)));

            //OpenContractsViewCommand = new NavigationCommand<ContractsViewModel>(new NavigationService<ContractsViewModel>(navigationStore,
             //   ()=> new ContractsViewModel( new RequestsToApiService())));

            //_navigationStore = navigationStore;
        }
/*
        private void OpenDialog(object parameter)
        {
            _dialogService.ShowClientsDialog();
        }

        private void OpenContractDialog(object parameter)
        {
            _dialogService.ShowContractsDialog();
        }
*/

    }
}
