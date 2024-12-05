using BankWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.ViewModels
{
    internal class ListingDataViewModel<TModel> : BaseViewModel
    {
        private ObservableCollection<TModel> _data;

        #region Поля модели представления
        public ObservableCollection<TModel> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                OnPropertyChanged("Data");//
            }
        }
        #endregion
    }
}
