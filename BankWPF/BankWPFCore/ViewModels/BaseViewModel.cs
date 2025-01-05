using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BankWPFCore.ViewModels
{
    internal class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public virtual void Dispose() { }

    }

}

