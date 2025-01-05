using BankWPFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Providers
{
    internal interface IContractsProvider
    {
        Task<IEnumerable<Contract>> GetAllContracts();
    }
}
