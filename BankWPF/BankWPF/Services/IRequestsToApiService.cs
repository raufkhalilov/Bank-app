using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Services
{
    interface IRequestsToApiService
    {
        Task<string> GetDataFromApi(string url);

        Task<string> PostDataToApi/*<T>*/(string url, object dataForPost);
    }
}
