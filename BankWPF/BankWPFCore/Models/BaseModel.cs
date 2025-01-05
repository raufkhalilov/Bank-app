using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BankWPFCore.Models
{
    internal class BaseModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
