using BankWPFCore.Exceptions;
using BankWPFCore.Models;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Creators
{
    internal class ApiContractCreator : IContractCreator
    {
        private IRequestsToApiService _requestsToApiService;

        private string _url;

        public string Url
        {
            get => _url;
            set => _url = value;
        }

        public ApiContractCreator(IRequestsToApiService requestsToApiService, string url)
        {
            _requestsToApiService = requestsToApiService;//new RequestsToApiService();
            _url = url;
        }

        public async Task AddContract(Contract contract)
        {
            //string url = "http://109.206.241.154:8080/post/Contract";

            //string url = "http://localhost:8080/post/Contract";

            string request = null;

            request = await _requestsToApiService.PostDataToApi(_url, contract);

            if (request == null)
                throw new ApiConnectionException("api connection error");
        }
    }
}
