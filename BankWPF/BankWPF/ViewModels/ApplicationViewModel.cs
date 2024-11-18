using BankWPF.Classes;
using BankWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    internal class ApplicationViewModel : BaseViewModel
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


        private readonly IDialogService _dialogService;

        public ICommand OpenDialogCommand { get; }
        public ICommand ContractsDialogCommand { get; }

        public ApplicationViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            OpenDialogCommand = new RelayCommand(OpenDialog);
            ContractsDialogCommand = new RelayCommand(OpenContractDialog);
        }

        private void OpenDialog(object parameter)
        {
            _dialogService.ShowClientsDialog();
        }

        private void OpenContractDialog(object parameter)
        {
            _dialogService.ShowContractsDialog();
        }


    }
}
