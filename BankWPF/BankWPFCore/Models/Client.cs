using Newtonsoft.Json;

namespace BankWPFCore.Models
{
    internal class Client : BaseModel
    {
        [JsonProperty("client_id")]
        private int client_id { get; set; }
        [JsonProperty("client_name")]
        private string client_name { get; set; }
        [JsonProperty("phone_number")]
        private string phone_number { get; set; }
        [JsonProperty("is_deleted")]
        private bool is_deleted { get; set; }

        /*
         -- Создание таблицы clients
        CREATE TABLE clients (
            client_id SERIAL PRIMARY KEY,
            client_name VARCHAR(255) NOT NULL,
            phone_number VARCHAR(20) NOT NULL,
            is_deleted BOOLEAN DEFAULT FALSE
        );

       

         */


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
        public bool IsDeleted
        {
            get { return is_deleted; }
            set
            {
                is_deleted = value;
                OnPropertyChanged(nameof(IsDeleted));
            }
        }
    }
}
