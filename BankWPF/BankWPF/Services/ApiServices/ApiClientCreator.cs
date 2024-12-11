using BankWPF.Exceptions;
using BankWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF.Services.ApiServices
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

/*
            if (request != null)
            {


            }
            else
            {
                if (MessageBox.Show("При добавлении клиента произошла ошибка!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                {
                    // logic ...
                }
            }*/
        }
    }
}
