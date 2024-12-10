using BankWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Services
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
