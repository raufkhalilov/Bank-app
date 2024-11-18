using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Models
{
    internal class Client : BaseModel
    {
        [JsonProperty("client_id")]
        private int client_id { get; set; }
        [JsonProperty("client_name")]
        private string client_name { get; set; }
        [JsonProperty("phone_number")]
        private string phone_number { get; set; }


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
                OnPropertyChanged("ClientName");
            }
        }
        public string PhoneNumber
        {
            get { return phone_number; }
            set
            {
                phone_number = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
    }
}
