using BankWPF.Services;
using BankWPF.Stores;
using BankWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Commands
{
    internal class NavigationCommand<TViewModel> : BaseCommand
        where TViewModel : BaseViewModel
    {

        //====

        private bool _isExecuting;

        private bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }

            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        //====


        private readonly NavigationService<TViewModel> _navigationService;

        public NavigationCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
