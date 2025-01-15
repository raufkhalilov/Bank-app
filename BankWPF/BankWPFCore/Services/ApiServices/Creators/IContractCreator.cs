using BankWPFCore.Models;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Creators
{
    internal interface IContractCreator
    {
        public string Url { get; set; }

        Task AddContract(Contract client);
    }
}
