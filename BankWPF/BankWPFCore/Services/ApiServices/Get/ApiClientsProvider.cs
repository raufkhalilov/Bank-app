using BankWPF.Models;
using BankWPF.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Get
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
            //var jsonData = await _requestsToApiService.GetDataFromApi("http://localhost:8080/get/Clients");

            var jsonData = await _requestsToApiService.GetDataFromApi("http://109.206.241.154:8080/get/Clients");

            if (jsonData != null)
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Client>>(jsonData);

            }
            else
            {
                return null;
            }
        }
    }
}
