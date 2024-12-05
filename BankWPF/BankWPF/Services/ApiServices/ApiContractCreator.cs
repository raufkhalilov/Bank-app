using BankWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF.Services.ApiServices
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

            if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                request = await _requestsToApiService.PostDataToApi(url, contract);

                //_bank.AddClient()
            }
        }
    }
}
