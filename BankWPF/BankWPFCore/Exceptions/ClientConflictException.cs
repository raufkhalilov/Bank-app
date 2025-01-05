using BankWPFCore.Models;
using System;

namespace BankWPFCore.Exceptions
{
    internal class ClientConflictException : Exception
    {
        public Client ExistingClient { get; }
        public Client IncomingClient { get; }

        public ClientConflictException(Client existingClient, Client incomingClient)
        {
            ExistingClient = existingClient;
            IncomingClient = incomingClient;
        }

        public ClientConflictException(string message, Client existingClient, Client incomingClient) : base(message)
        {
            ExistingClient = existingClient;
            IncomingClient = incomingClient;
        }
    }
}
