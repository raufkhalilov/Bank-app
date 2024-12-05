
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
       
        #region  need for navigation realisation
        private readonly NavigationStore _navigationStore;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public NavigationViewModel NavigationViewModel {  get; }
        #endregion


       
        public StartViewModel(NavigationViewModel navigationViewModel/*, NavigationStore navigationStore*/)
        {
            
            NavigationViewModel = navigationViewModel;

           
        }


    }
}
