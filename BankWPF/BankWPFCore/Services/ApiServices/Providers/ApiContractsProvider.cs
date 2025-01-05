using BankWPFCore.Exceptions;
using BankWPFCore.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Providers
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
            //var jsonData = await _requestsToApiService.GetDataFromApi("http://109.206.241.154:8080/get/Contracts");

            var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Contracts");

            /*if (jsonData != null)
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Contract>>(jsonData);
            }
            else
            {
                return null;
            }*/


            if (jsonData == null)
            {
                throw new ApiConnectionException("api connection error");
            }

            return JsonConvert.DeserializeObject</*ObservableCollection*/IEnumerable<Contract>>(jsonData);
        }
    }
}
