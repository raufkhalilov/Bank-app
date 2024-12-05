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
            string url = "http://localhost:8080/post/Client";

            string request = null;

            if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                request = await _requestsToApiService.PostDataToApi(url, client);

                //_bank.AddClient()
            }


            if (request != null)
            {


            }
            else
            {
                if (MessageBox.Show("При добавлении клиента произошла ошибка!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                {
                    // logic ...
                }
            }
        }
    }
}
