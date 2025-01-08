using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFCore.Services.AuthenticationServices
{
    internal class LocalAuthenticationService : IAuthService
    {
        public Task<bool> IsAuthenticated(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
