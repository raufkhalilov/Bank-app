using System.Threading.Tasks;

namespace BankWPFCore.Services.AuthenticationServices
{
    internal interface IAuthService
    {
        Task<bool> IsAuthenticated(string username, string password);
    }
}
