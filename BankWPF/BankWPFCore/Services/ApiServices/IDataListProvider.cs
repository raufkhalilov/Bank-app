using BankWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Services.ApiServices
{
    internal interface IDataListProvider<TModel> 
        where TModel : BaseModel
    {
        Task<IEnumerable<TModel>> GetAllData();
    }
}
