using BankWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Services.ApiServices
{
    internal class ApiContractsProvider : IContractsProvider
    {
        readonly IRequestsToApiService _requestsToApiService;

        public ApiContractsProvider(IRequestsToApiService requestsToApiService)
        {
            _requestsToApiService = requestsToApiService;//new RequestsToApiService();
        }


        public async Task<IEnumerable<Contract>> GetAllContracts()
        {
            var jsonData = await _requestsToApiService.GetDataFromApi("http://109.206.241.154:8080/get/Contracts");

            if (jsonData != null)
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Contract>>(jsonData);
            }
            else
            {
                return null;
            }
        }
    }
}
