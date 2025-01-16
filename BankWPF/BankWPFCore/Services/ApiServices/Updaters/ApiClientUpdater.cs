using BankWPFCore.Exceptions;
using BankWPFCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Updaters
{
    internal class ApiClientUpdater : IClientUpdater
    {
        readonly IRequestsToApiService _requestsToApiService;
        string _url;



        public string Url
        {
            get => _url;
            set => _url = value;
        }

        public ApiClientUpdater(IRequestsToApiService requestsToApiService, string url)
        {
            _requestsToApiService = requestsToApiService;//new RequestsToApiService();
            _url = url;
        }


        public async Task UpdateClient(Client updatedData)
        {
           
            string request = null;

            request = await _requestsToApiService.UpdateDataFromApi(_url, updatedData);

            if (request == null)
                throw new ApiConnectionException("api connection error");
        }

        
    }
}
