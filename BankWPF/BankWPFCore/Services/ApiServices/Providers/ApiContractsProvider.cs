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
        string _url;

        public string Url
        {
            get => _url;
            set => _url = value;
        }

        public ApiContractsProvider(IRequestsToApiService requestsToApiService, string url)
        {
            _requestsToApiService = requestsToApiService;//new RequestsToApiService();
            _url = url;
        }


        public async Task<IEnumerable<Contract>> GetAllContracts()
        {
            //var jsonData = await _requestsToApiService.GetDataFromApi("http://109.206.241.154:8080/get/Contracts");

            //var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Contracts");

            var jsonData = await _requestsToApiService.GetDataFromApi(_url);

           


            if (jsonData == null)
            {
                throw new ApiConnectionException("api connection error");
            }

            try
            {
                return JsonConvert.DeserializeObject</*ObservableCollection*/IEnumerable<Contract>>(jsonData);
            }
            catch
            {
                throw new ApiConnectionException("api connection error");
            }

        }
    }
}
