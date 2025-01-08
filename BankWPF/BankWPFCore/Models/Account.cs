namespace BankWPFCore.Models
{
    internal class Account : BaseModel
    {
        private int _id;
        private string _name;
        private string _password;
        private bool _permission;

        public int Id 
        { 
            get 
            { 
                return _id; 
            } 
            set 
            { 
                _id = value; 
                OnPropertyChanged(nameof(Id));
            } 
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
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
                OnPropertyChanged(nameof(Password));
            }
        }


        public bool Permission
        {
            get
            {
                return _permission;
            }
            set
            {
                _permission = value;
                OnPropertyChanged(nameof(Permission));
            }
        }
    }
}
