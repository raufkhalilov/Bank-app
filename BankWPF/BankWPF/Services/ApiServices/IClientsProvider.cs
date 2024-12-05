using BankWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Services
{
    internal interface IClientsProvider
    {
        Task<IEnumerable<Client>> GetAllClients();
    }
}
