using BankWPFCore.Stores;
using System.Threading.Tasks;

namespace BankWPFCore.Services
{
    internal class AuthenicationService : IAuthService
    {

        private readonly AccountStore _accountStore;

        public AuthenicationService(AccountStore accountStore)
        {
            _accountStore = accountStore;
        }

        public async Task<bool> IsAuthenticated(string username, string password)
        {

            // async request to Api

            return (username == "admin" || username == "worker001") && password == "password";
        }

        public async Task GrantingExtendedAccecRights(string username, string password)
        {

            if (username == "admin")
                _accountStore.CurrentAccount.IsAdmin = true;
        }
    }
}
