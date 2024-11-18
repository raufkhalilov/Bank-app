using BankWPF.Models;
using BankWPF.ViewModels;
using BankWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF.Services
{
    public interface IDialogService
    {
        void ShowDialog(Window window);    

        void ShowClientsDialog();
        void ShowContractsDialog();
        void ShowAddClientDialog();
    }

    internal class DialogService : IDialogService
    {
        public void ShowClientsDialog()
        {
            var dialogService = new DialogService();
            var requestToApiServise = new RequestsToApiService();
            var clientsViewModel = new ClientsViewModel(requestToApiServise, dialogService);


            var window = new ClientsWindow() {DataContext = clientsViewModel }; // Замените на ваше окно
            window.Show();
        }

        public void ShowContractsDialog() {


            //logic...

            var requestToApiServise = new RequestsToApiService();
            var clientsViewModel = new ContractsViewModel(requestToApiServise);

            var window = new ProductsWindow();
            window.Show();
        }

        public void ShowAddClientDialog()
        {
            /*Client client = new Client();*/

            var requestToApiServise = new RequestsToApiService();
            var clientAddingViewModel = new ClientAddingViewModel(/*client,*/ requestToApiServise);


            var window = new AddClientWindow() { DataContext = clientAddingViewModel }; // Замените на ваше окно
            window.ShowDialog();
            /*window.Close();*/
        }

        //
        public void ShowDialog(Window window)
        {
            var requestToApiServise = new RequestsToApiService();
            window.ShowDialog();
            //var viewModel = reguestToApiServise;

        }
    }

    
}
