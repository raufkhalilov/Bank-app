using BankWPFCore.Models;
using BankWPFCore.Services.ApiServices.Providers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ConflictValidators.ClientConflictValidators
{
    internal class ApiClientConflictValidator : IClientConflictValidator
    {
        IClientsProvider _clientsProvider;

        public ApiClientConflictValidator(IClientsProvider clientsProvider)
        {
            _clientsProvider = clientsProvider;
        }

        public async Task<Client> GetConflictingClient(Client client)
        {


            // client`s fields checking logic ...


            var conf = new ObservableCollection<Client>(await _clientsProvider.GetAllClients()).
                Where(c => c.PhoneNumber == client.PhoneNumber);


            Client confClient = conf.FirstOrDefault();

            return confClient;
        }
    }
}
