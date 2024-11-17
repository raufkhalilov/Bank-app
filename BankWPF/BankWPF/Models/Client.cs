using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Models
{
    public class Client : INotifyPropertyChanged
    {
        [JsonProperty("client_id")]
        private int client_id;
        [JsonProperty("client_name")]
        private string client_name;
        [JsonProperty("phone_number")]
        private string phone_number;

        public int ClientId
        {
            get { return client_id; }
            set
            {
                client_id = value;
                OnPropertyChanged("ClientId");
            }
        }

        public string ClientName
        {
            get { return client_name; }
            set
            {
                client_name = value;
                OnPropertyChanged("ClientId");
            }
        }

        public string PhoneNumber
        {
            get { return phone_number; }
            set
            {
                phone_number = value;
                OnPropertyChanged("ClientId");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
