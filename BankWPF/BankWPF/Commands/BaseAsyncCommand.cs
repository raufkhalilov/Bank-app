using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Commands
{
    internal abstract class BaseAsyncCommand : BaseCommand
    {

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

        public override async void Execute(object parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync();
            }
            finally
            {
                IsExecuting = false;
            }
          
        }

        public abstract Task ExecuteAsync();
    }
}
