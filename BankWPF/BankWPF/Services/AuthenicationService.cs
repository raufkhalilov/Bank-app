using BankWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BankWPF.Services
{
    internal class AuthenicationService : IAuthService
    {
        public async Task<bool> IsAuthenticated(string username, string password)
        {

            // async request to Api

             return username == "admin" && password == "password";
        }
    }
}
