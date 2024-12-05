using BankWPF.Models;
using BankWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Commands
{
    internal class BasePostDataCommand<TModel> : BaseAsyncCommand
    {

        protected Bank _bank;

        protected readonly IRequestsToApiService _requestsToApiService;

        //private readonly Client _client;

        protected readonly TModel _dataForPost;

        public BasePostDataCommand(Bank bank, IRequestsToApiService requestsToApiService, TModel dataforPost)
        {
            _bank = bank;
            _requestsToApiService = requestsToApiService;
            _dataForPost = dataforPost;
        }


        public override Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
