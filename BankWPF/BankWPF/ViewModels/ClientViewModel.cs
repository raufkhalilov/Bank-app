using BankWPF.Classes;
using BankWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.ViewModels
{
    internal class ClientViewModel : INotifyPropertyChanged
    {
        private Client client;

        public ClientViewModel(Client _client)
        {
            client = _client;
        }

        public int ClientID
        {
            get
            {
                return client.ClientId;
            }
            set
            {
                client.ClientId = value;
                OnPropertyChanged();
            }
        }

        public string ClientName
        {
            get
            {
                return client.ClientName;
            }
            set
            {
                client.ClientName = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get
            {
                return client.PhoneNumber;
            }
            set
            {
                client.PhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
