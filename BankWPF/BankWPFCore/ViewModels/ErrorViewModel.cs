﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFCore.ViewModels
{
    internal class ErrorViewModel : INotifyDataErrorInfo
    {

        /* private readonly Dictionary<string, List<string>> _propertyNameToErrorDictionary = new Dictionary<string, List<string>>();

         public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

         public bool HasErrors => _propertyNameToErrorDictionary.Any();

         public IEnumerable GetErrors(string propertyName)
         {
             return _propertyNameToErrorDictionary
                 .GetValueOrDefault(propertyName, new List<string>());
         }

         public void AddError(string errorMessage, string propertyName)
         {
             if (!_propertyNameToErrorDictionary.ContainsKey(propertyName))
             {
                 _propertyNameToErrorDictionary.Add(propertyName, new List<string>());
             }

             _propertyNameToErrorDictionary[propertyName].Add(errorMessage);

             OnErrorsChanged(propertyName);
         }

         public void ClearErrors(string propertyName)
         {

             if (_propertyNameToErrorDictionary.Remove(propertyName))
             {
                 OnErrorsChanged(propertyName);
             }
         }

         private void OnErrorsChanged(string propertyName)
         {
             ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
             //OnPropertyChanged(nameof(CanUse));
         }*/

        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

        public bool HasErrors => _propertyErrors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }

            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        public void ClearErrors(string propertyName)
        {
            if (_propertyErrors.Remove(propertyName))
            {
                OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    

        ~ErrorViewModel() { }
    }
}
