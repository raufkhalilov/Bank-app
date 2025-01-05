using BankWPFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices
{
    internal interface IDataListProvider<TModel>
        where TModel : BaseModel
    {
        Task<IEnumerable<TModel>> GetAllData();
    }
}
