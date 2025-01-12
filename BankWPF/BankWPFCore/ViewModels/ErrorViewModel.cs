using System;
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

        private readonly Dictionary<string, List<string>> _propertyNameToErrorDictionary = new Dictionary<string, List<string>>();

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

            OnErrorChanged(propertyName);
        }

        public void ClearErrors(string propertyName)
        {

            if (_propertyNameToErrorDictionary.Remove(propertyName))
                OnErrorChanged(propertyName);

        }

        private void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(propertyName, new DataErrorsChangedEventArgs(nameof(propertyName)));
            //OnPropertyChanged(nameof(CanUse));
        }

        ~ErrorViewModel() { }
    }
}
