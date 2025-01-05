namespace BankWPFCore.Models
{
    internal class Account : BaseModel
    {
        private int _id;
        private string _userName;
        private string _password;
        private bool _isAdmin;

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

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
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


        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }
    }
}
