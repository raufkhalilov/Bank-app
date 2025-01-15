using BankWPFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Providers
{
    internal interface IContractsProvider
    {
        public string Url { get; set; }

        Task<IEnumerable<Contract>> GetAllContracts();
    }
}
