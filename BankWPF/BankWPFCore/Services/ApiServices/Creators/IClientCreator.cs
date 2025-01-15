using BankWPFCore.Models;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Creators
{
    internal interface IClientCreator
    {
        public string Url { get; set; }

        Task AddClient(Client client);
    }
}
