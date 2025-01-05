using BankWPFCore.Models;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Creators
{
    internal interface IClientCreator
    {
        Task AddClient(Client client);
    }
}
