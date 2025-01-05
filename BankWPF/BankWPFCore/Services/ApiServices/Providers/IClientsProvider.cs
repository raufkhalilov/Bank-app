using BankWPFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Providers
{
    internal interface IClientsProvider
    {
        Task<IEnumerable<Client>> GetAllClients();
    }
}
