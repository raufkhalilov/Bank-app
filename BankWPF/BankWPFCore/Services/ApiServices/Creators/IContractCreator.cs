using BankWPFCore.Models;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Creators
{
    internal interface IContractCreator
    {
        Task AddContract(Contract client);
    }
}
