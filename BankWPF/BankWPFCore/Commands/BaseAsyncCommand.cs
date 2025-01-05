using System.Threading.Tasks;

namespace BankWPFCore.Commands
{
    internal abstract class BaseAsyncCommand : BaseCommand
    {

        private bool _isExecuting;

        protected bool IsExecuting
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
