using BankWPF.Models;
using BankWPF.Services;
using BankWPF.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF.Stores
{
    internal class BankStore
    {
        public Bank _bank;

        private readonly List<Client> _clients;
        private readonly List<Contract> _contracts;

        public List<Client> Clients => _clients;
        public List<Contract> Contracts => _contracts;


        private readonly Lazy<Task> _initLazyClients;
        private readonly Lazy<Task> _initLazyContracts;

        public Action<Client> ClientAdded;
        public Action<Contract> ContractAdded;


        public BankStore(Bank bank) 
        { 
            _bank = bank;

            _initLazyClients = new Lazy<Task>(InitializeClients);
            _initLazyContracts = new Lazy<Task>(InitializeContracts);

            _clients = new List<Client>();
            _contracts = new List<Contract>();
        }

        //=================================

        public async Task LoadClients()
        {
            //данные обновятся только при внесении изменений
            await _initLazyClients.Value;
        }

        private async Task InitializeClients()
        {
            IEnumerable<Client> clients = await _bank.GetAllClients();
            //IEnumerable<Contract> contracts = await _bank.GetAllContracts();

            _clients.Clear();
            _clients.AddRange(clients);
        }

        public async Task AddNewClient(Client newClient)
        {
            await _bank.AddNewClient(newClient);

            _clients.Add(newClient);

            OnClientAdded(newClient);
        }

        private void OnClientAdded(Client newClient)
        {
            ClientAdded?.Invoke(newClient);
        }

        //=================================

        public async Task LoadContracts()
        {
            //данные обновятся только при внесении изменений
            await _initLazyContracts.Value;
        }

        private async Task InitializeContracts()
        {
            IEnumerable<Contract> contracts = await _bank.GetAllContracts();
            //IEnumerable<Contract> contracts = await _bank.GetAllContracts();

            _contracts.Clear();
            _contracts.AddRange(contracts);
        }

        public async Task AddNewContract(Contract newContract)
        {
         
            await _bank.AddNewContract(newContract);

            _contracts.Add(newContract);

            OnContractAdded(newContract);
        }

        private void OnContractAdded(Contract newContract)
        {
            ContractAdded?.Invoke(newContract);
        }
    }
}
