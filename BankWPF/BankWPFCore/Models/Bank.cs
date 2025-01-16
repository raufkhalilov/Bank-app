using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankWPFCore.Models
{
    internal class Bank
    {


        public string Name { get; }

        private readonly ClientsBook _clientsBook;

        private readonly ContractsBook _contractsBook;

        //===================================================

        public Bank(string name, ClientsBook clientsBook, ContractsBook contractsBook)
        {
            Name = name;

            _clientsBook = clientsBook;

            _contractsBook = contractsBook;
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _clientsBook.GetAllClients();
        }

        public async Task<IEnumerable<Contract>> GetAllContracts()
        {
            return await _contractsBook.GetAllContracts();
        }

        public async Task AddNewClient(Client client)
        {
            //...
            await _clientsBook.AddClient(client);
        }

        public async Task AddNewContract(Contract contract)
        {
            //...
            await _contractsBook.AddContract(contract);
        }

        public async Task UpdateClient(Client client)
        {
            //_clientsBook.
            await _clientsBook.UpdateClient(client);
        }

        public async Task UpdateContract(Contract contract)
        {
            //_contractsBook
        }

    }
}
