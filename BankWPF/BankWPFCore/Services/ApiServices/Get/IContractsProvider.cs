using BankWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Get
{
    internal interface IContractsProvider
    {
        Task<IEnumerable<Contract>> GetAllContracts();
    }
}
