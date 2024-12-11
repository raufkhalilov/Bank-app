using BankWPF.Models;
using BankWPF.Services;
using BankWPF.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Contract = BankWPF.Models.Contract;

namespace BankWPF.Commands
{
    internal class PostDataCommand<TModel> : BaseAsyncCommand//BasePostDataCommand<TModel>
        where TModel : BaseModel
    {
        private BankStore _bankStore;

        private readonly IRequestsToApiService _requestsToApiService;

        //private readonly Client _client;

        private readonly TModel _dataForPost;

        public PostDataCommand(BankStore bankStore, IRequestsToApiService requestsToApiService, TModel dataforPost)
        {
            _bankStore = bankStore;
            _requestsToApiService = requestsToApiService;
            _dataForPost = dataforPost;
        }   

        public override async Task ExecuteAsync()
        {
            string url = "http://localhost:8080/post/Client";

            string request = null;

            if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                
                    request = await _requestsToApiService.PostDataToApi(url, _dataForPost);/*TModel*/
               
            }

            if (request != null)
            {
                MessageBox.Show("Клиент успешно добавлен!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Information);
                
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
