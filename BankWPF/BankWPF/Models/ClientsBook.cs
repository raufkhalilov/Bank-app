using BankWPF.Services.ApiServices;
using BankWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Models
{
    internal class ClientsBook
    {

        IClientsProvider _clientsProvider;
        IClientCreator _clientCreator;

        //private readonly List<Client> _clients;

        public ClientsBook(IClientsProvider clientsProvider, IClientCreator clientCreator)
        {
            //_clients = new List<Client>();
            _clientCreator = clientCreator;
            _clientsProvider = clientsProvider;
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _clientsProvider.GetAllClients();
        }

        public async Task AddClient(Client client) 
        {
            //checking logic ...

            await _clientCreator.AddClient(client);
            //_clients.Add(client);
        }
    }
}
