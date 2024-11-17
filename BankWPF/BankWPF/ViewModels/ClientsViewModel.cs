using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using BankWPF.Classes;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using BankWPF.Classes.Commands;
using BankWPF.Views;
using BankWPF.Models;

namespace BankWPF.ViewModels
{
    internal class ClientsViewModel : INotifyPropertyChanged 
    {
        //private Client selectedClient;
        RelayCommand addCommand;
        public ObservableCollection<Client> Clients { get; set; }
       /* public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedPhone");
            }
        }*/

        public ClientsViewModel()
        {
            Clients = new ObservableCollection<Client>();
            //Task.Run(async () => await LoadClientsAsync());
            LoadClientsAsync();
        }

        private async Task LoadClientsAsync()
        {
            var jsonData = await Helper.GetData("http://localhost:8080/get/Clients");

            var people = JsonConvert.DeserializeObject<List<Client>>(jsonData);

            foreach (var person in people)
            {
                Clients.Add(person);
            }
        }

        #region Комманды

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      Client newClient = new Client();
                      //ClientViewModel viewModel = new ClientViewModel(newClient);
                      ClientWindow userWindow = new ClientWindow(newClient);
                      userWindow.Show();
                      if (userWindow.ShowDialog() == true)
                      {
                          Client user = userWindow.client;
                          //db.Users.Add(user);
                          //db.SaveChanges();
                      }
                  }));
            }
        }

        #endregion



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
