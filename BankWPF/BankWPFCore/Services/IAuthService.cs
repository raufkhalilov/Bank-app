using System.Threading.Tasks;

namespace BankWPFCore.Services
{
    internal interface IAuthService
    {
        Task<bool> IsAuthenticated(string username, string password);
    }
}
