using BankWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Stores
{
    internal class NavigationStore
    {
        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { 
                return currentViewModel;
            }
            set { 
                currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

       
        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
