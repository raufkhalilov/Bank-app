using BankWPF.Exceptions;
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

        private readonly Contract _newContract;

        public PostContractCommand(BankStore bankStore, Contract newContract)
        {
            _bankStore = bankStore;
            _newContract = newContract;
        }

        public override async Task ExecuteAsync()
        {
        
            if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {

               
                try
                {
                    await _bankStore.AddNewContract(_newContract);
                    MessageBox.Show("Клиент успешно добавлен!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (ApiConnectionException ex)
                {
                    MessageBox.Show("При добавлении клиента произошла ошибка!\n" + ex.Message, "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
