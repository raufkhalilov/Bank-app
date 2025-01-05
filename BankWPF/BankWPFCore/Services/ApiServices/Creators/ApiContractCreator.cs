using BankWPFCore.Exceptions;
using BankWPFCore.Models;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Creators
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
            //string url = "http://109.206.241.154:8080/post/Contract";

            string url = "http://localhost:8080/post/Contract";

            string request = null;

            request = await _requestsToApiService.PostDataToApi(url, contract);

            if (request == null)
                throw new ApiConnectionException("api connection error");
        }
    }
}
