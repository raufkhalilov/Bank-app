using BankWPF.Exceptions;
using BankWPF.Models;
using BankWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPFCore.Services.ApiServices.Post
{
    internal class ApiContractCreator : IContractCreator
    {
        private IRequestsToApiService _requestsToApiService;

        public ApiContractCreator(IRequestsToApiService requestsToApiService)
        {
            _requestsToApiService = requestsToApiService;//new RequestsToApiService();
        }

        public async Task AddContract(Contract contract)
        {
            string url = "http://localhost:8080/post/Contract";

            string request = null;

            request = await _requestsToApiService.PostDataToApi(url, contract);

            if (request == null)
                throw new ApiConnectionException("api connection error");
        }
    }
}
