﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BankWPFCore.Services.ConflictValidators.ClientConflictValidators;
using BankWPFCore.Exceptions;
using BankWPFCore.Services.ApiServices.Providers;
using BankWPFCore.Services.ApiServices.Creators;

namespace BankWPFCore.Models
{
    internal class ClientsBook
    {

        IClientConflictValidator _clientConflictValidator;
        IClientsProvider _clientsProvider;
        IClientCreator _clientCreator;

        //private readonly List<Client> _clients;

        public ClientsBook(IClientsProvider clientsProvider, IClientCreator clientCreator, IClientConflictValidator clientConflictValidator)
        {
            //_clients = new List<Client>();
            _clientCreator = clientCreator;
            _clientsProvider = clientsProvider;
            _clientConflictValidator = clientConflictValidator;
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            IEnumerable<Client> clients = await _clientsProvider.GetAllClients();
            /*
                        if (clients == null)
                        {
                            throw new ApiConnectionException("");
                        }*/

            return clients;
        }

        public async Task AddClient(Client client)
        {
            //checking logic ...
            Client confClient = await _clientConflictValidator.GetConflictingClient(client);

            if (confClient != null)
            {
                throw new ClientConflictException(confClient, client);
            }

            await _clientCreator.AddClient(client);
            //_clients.Add(client);
        }
    }
}