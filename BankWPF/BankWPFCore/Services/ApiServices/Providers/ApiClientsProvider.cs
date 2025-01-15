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
        string _url;

        

        public string Url 
        { 
            get => _url; 
            set => _url = value; 
        }

        public ApiClientsProvider(IRequestsToApiService requestsToApiService, string url)
        {
            _requestsToApiService = requestsToApiService;//new RequestsToApiService();
            _url = url;
        }


        public async Task<IEnumerable<Client>> GetAllClients()
        {
            //var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Clients");

            //var jsonData = await _requestsToApiService.GetDataFromApi("http://109.206.241.154:8080/get/Clients");

            var jsonData = await _requestsToApiService.GetDataFromApi(_url);

            if (jsonData == null)
            {
                throw new ApiConnectionException("api connection error");
            }

            try
            {
                return JsonConvert.DeserializeObject</*ObservableCollection*/IEnumerable<Client>>(jsonData);
            }
            catch
            {
                throw new ApiConnectionException("api connection error");
            }
        }
    }
}
