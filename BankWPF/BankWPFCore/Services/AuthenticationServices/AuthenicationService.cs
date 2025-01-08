using BankWPFCore.Models;
using BankWPFCore.Stores;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BankWPFCore.Services.AuthenticationServices
{
    internal class AuthenicationService : IAuthService
    {

        private AccountStore _accountStore;

        private readonly string _filePath;

        public AuthenicationService(AccountStore accountStore, string filePath)
        {
            _accountStore = accountStore;
            _filePath = filePath;
        }

        public List<Account> LoadUsers()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Account>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Account>>(json);
        }

        public async Task<bool> IsAuthenticated(string username, string password)
        {

            List<Account> users = this.LoadUsers();
            Account user = users.FirstOrDefault(u => u.Name == username && u.Password == password);

            if (user == null)
            {
                return false;
            }
            else
            {
                _accountStore.CurrentAccount = user;
                return true;
            }
        }

        public async Task GrantingExtendedAccecRights(string username, string password)
        {

            //if (username == "admin")
                //_accountStore.CurrentAccount.Permission = true;
        }
    }
}
