using BankWPFCore.Models;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ConflictValidators.ClientConflictValidators
{
    internal interface IClientConflictValidator
    {
        Task<Client> GetConflictingClient(Client client);
    }
}
