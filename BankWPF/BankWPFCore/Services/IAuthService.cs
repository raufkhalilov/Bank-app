using BankWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Services
{
    internal interface IAuthService
    {
        Task<bool> IsAuthenticated(string username, string password);
    }
}
