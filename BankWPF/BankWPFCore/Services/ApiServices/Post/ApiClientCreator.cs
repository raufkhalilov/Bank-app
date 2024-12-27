using BankWPF.Exceptions;
using BankWPF.Models;
using BankWPF.Services;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Post
{
    internal class ApiClientCreator : IClientCreator
    {

        private IRequestsToApiService _requestsToApiService;

        public ApiClientCreator(IRequestsToApiService requestsToApiService)
        {
            _requestsToApiService = requestsToApiService;//new RequestsToApiService();
        }

        public async Task AddClient(Client client)
        {
            string url = "http://109.206.241.154:8080/post/Client";

            string request = null;

            request = await _requestsToApiService.PostDataToApi(url, client);

            if (request == null)
                throw new ApiConnectionException("api connection error");

        }
    }
}
