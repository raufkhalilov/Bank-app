using Newtonsoft.Json;

namespace BankWPFCore.Models
{
    class Contract : BaseModel
    {

        [JsonProperty("client_id")]
        private int client_id;

        [JsonProperty("contract_amount")]
        private float contract_amount;

        [JsonProperty("contract_details")]
        private string contract_details;

        //[JsonProperty("description")]
        //private string description;       

        //[JsonProperty("product_type_id")]
        //private string product_type_id;
        
        [JsonProperty("contract_id")]
        private int contract_id;//

        [JsonProperty("end_date")]
        private string end_date;

        [JsonProperty("start_date")]
        private string start_date;


        [JsonProperty("is_deleted")]
        private bool is_deleted;

        /*
          -- Создание таблицы contracts
                CREATE TABLE contracts (
                    contract_id SERIAL PRIMARY KEY,
                    client_id INT NOT NULL,
                    contract_details TEXT NOT NULL,
                    start_date DATE NOT NULL,
                    end_date DATE NOT NULL,
                    is_deleted BOOLEAN DEFAULT FALSE,
                    FOREIGN KEY (client_id) REFERENCES clients(client_id)
                );
         */

        public int ContractID
        {
            get { return contract_id; }
            set
            {
                contract_id = value;
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
            get { return contract_details; }
            set
            {
                contract_details = value;
                OnPropertyChanged("Description");
            }
        }

       /* public string ProductTypeID
        {
            get { return product_type_id; }
            set
            {
                product_type_id = value;
                OnPropertyChanged("ProductTypeID");
            }
        }*/

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

        public float ContractAmount
        {
            get { return contract_amount; }
            set
            {
                contract_amount = value;
                OnPropertyChanged("ContractAmount");
            }
        }

        public bool IsDeleted
        {
            get { return is_deleted; }
            set
            {
                is_deleted = value;
                OnPropertyChanged(nameof(IsDeleted));
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
