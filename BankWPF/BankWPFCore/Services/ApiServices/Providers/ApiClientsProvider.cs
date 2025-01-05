using BankWPFCore.Exceptions;
using BankWPFCore.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Providers
{
    internal class ApiClientsProvider : IClientsProvider
    {

        readonly IRequestsToApiService _requestsToApiService;

        public ApiClientsProvider(IRequestsToApiService requestsToApiService)
        {
            _requestsToApiService = requestsToApiService;//new RequestsToApiService();
        }


        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Clients");

            //var jsonData = await _requestsToApiService.GetDataFromApi("http://109.206.241.154:8080/get/Clients");

            if (jsonData == null)
            {
                throw new ApiConnectionException("api connection error");
            }

            return JsonConvert.DeserializeObject</*ObservableCollection*/IEnumerable<Client>>(jsonData);

        }
    }
}
