using BankWPFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Providers
{
    internal interface IClientsProvider
    {
        public string Url { get; set; }

        Task<IEnumerable<Client>> GetAllClients();
    }
}
