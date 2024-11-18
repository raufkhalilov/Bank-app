using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Models
{
    class Contract : BaseModel
    {
        [JsonProperty("id")]
        private int id;
        [JsonProperty("client_id")]
        private int client_id;
        [JsonProperty("description")]
        private string description;
        [JsonProperty("product_type_id")]
        private string product_type_id;
        [JsonProperty("start_date")]
        private string start_date;
        [JsonProperty("end_date")]
        private string end_date;
        [JsonProperty("contract_amount")]
        private string contract_amount;

        public int ContractID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ContractID");
            }
        }

        public int ClientID
        {
            get { return client_id; }
            set
            {
                client_id = value;
                OnPropertyChanged("ClientID");
            }
        }

        public string Description
        {
            get { return description; }
            set { 
                description = value; 
                OnPropertyChanged("Description"); 
            }
        }

        public string ProductTypeID
        {
            get { return product_type_id; }
            set
            {
                product_type_id = value;
                OnPropertyChanged("ProductTypeID");
            }
        }

        public string StartDate
        {
            get { return start_date; }
            set
            {
                start_date = value;
                OnPropertyChanged("StartDate");
            }
        }

        public string EndDate
        {
            get { return end_date; }
            set
            {
                end_date = value;
                OnPropertyChanged("EndDate");
            }
        }

        public string ContractAmount
        {
            get { return contract_amount; }
            set
            {
                contract_amount = value;
                OnPropertyChanged("ContractAmount");
            }
        }
    }
}
