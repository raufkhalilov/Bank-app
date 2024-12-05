using BankWPF.Models;
using BankWPF.Services;
using BankWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF.Commands
{
    internal class PostContractCommand : BaseAsyncCommand
    {
        private BankStore _bankStore;

        private readonly IRequestsToApiService _requestsToApiService;

        //private readonly Client _client;

        private readonly Contract _newContract;

        public PostContractCommand(BankStore bankStore, IRequestsToApiService requestsToApiService, Contract newContract)
        {
            _bankStore = bankStore;
            _requestsToApiService = requestsToApiService;
            _newContract = newContract;
        }

        public override async Task ExecuteAsync()
        {
            //string url = "http://localhost:8080/post/Client";

            //string request = null;

            if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {

                //request = await _requestsToApiService.PostDataToApi(url, _newClient);/*TModel*/
                //_bank.AddNewClient((Client)_dataForPost);// AddClient(_dataForPost);
                try
                {
                    await _bankStore.AddNewContract(_newContract);
                    MessageBox.Show("Клиент успешно добавлен!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При добавлении клиента произошла ошибка!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Error);
                }



                //request = await _requestsToApiService.PostDataToApi(url, _dataForPost);/*TModel*/
                //_bank.((Contract)_dataForPost);
            }

            /*  if (request != null)
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
