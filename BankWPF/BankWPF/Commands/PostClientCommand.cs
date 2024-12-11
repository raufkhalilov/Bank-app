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
    internal class PostClientCommand : BaseAsyncCommand
    {
        private BankStore _bankStore;

        private readonly Client _newClient;

        public PostClientCommand(BankStore bankStore, Client newClient)
        {
            _bankStore = bankStore;
            _newClient = newClient;
        }

        public override async Task ExecuteAsync()
        {
            

            if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {

                try
                {
                    await _bankStore.AddNewClient(_newClient);
                    MessageBox.Show("Клиент успешно добавлен!", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При добавлении клиента произошла ошибка!\n"+ex, "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Error);
                }

               
            }
        }
    }
}
