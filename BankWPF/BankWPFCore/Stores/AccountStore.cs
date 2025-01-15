using BankWPFCore.Models;
using System;

namespace BankWPFCore.Stores
{
    internal class AccountStore
    {

        private Account _currentAccount;

        public Account CurrentAccount
        {
            get 
            { 
                return _currentAccount; 
            }
            set 
            { 
                _currentAccount = value;
                OnCurrentAccountChanged();
            }
        }

        public AccountStore(Account account)
        {
            _currentAccount = account;
        }


        public event Action CurrentAccountChanged;

        private void OnCurrentAccountChanged()
        {
            CurrentAccountChanged?.Invoke();
        }

    }
}
