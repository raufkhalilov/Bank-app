using BankWPFCore.Models;

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
            }
        }

    }
}
