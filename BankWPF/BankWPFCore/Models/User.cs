using Newtonsoft.Json;

namespace BankWPFCore.Models
{
    internal class User
    {
        [JsonProperty("id")]
        private int _id { get; set; }
        [JsonProperty("username")]
        private string _username { get; set; }
        [JsonProperty("password")]
        private string _password { get; set; }


        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
    }
}
