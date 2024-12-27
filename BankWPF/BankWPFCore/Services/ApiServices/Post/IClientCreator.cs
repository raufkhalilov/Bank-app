using BankWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Post
{
    internal interface IClientCreator
    {
        Task AddClient(Client client);
    }
}
