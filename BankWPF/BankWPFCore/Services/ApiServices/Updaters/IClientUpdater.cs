using BankWPFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Updaters
{
    internal interface IClientUpdater
    {
        Task UpdateClient(Client updatedData);
    }
}
