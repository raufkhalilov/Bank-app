using BankWPFCore.Exceptions;
using BankWPFCore.Models;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices.Creators
{
    internal class ApiClientCreator : IClientCreator
    {

        private IRequestsToApiService _requestsToApiService;

        private string _url;

        public string Url
        {
            get => _url;
            set => _url = value;
        }

        public ApiClientCreator(IRequestsToApiService requestsToApiService, string url)
        {
            _requestsToApiService = requestsToApiService;//new RequestsToApiService();
            _url = url;
        }

        public async Task AddClient(Client client)
        {
            //string url = "http://109.206.241.154:8080/post/Client";

            //string url = "http://localhost:8080/post/Client";

            string request = null;


            try
            {
                request = await _requestsToApiService.PostDataToApi(_url, client);
            }
            catch (ApiConnectionException) { 
                throw;
            }


            if (request == null)
                throw new ApiConnectionException("api connection error");

        }
    }
}
