using BankWPF.Classes;
using BankWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {

        //private ClientsWindow _parent;
        //public Client Client { get; private set; }
        public Client client { get; }

        public ClientWindow(Client _client)
        {
            InitializeComponent();
            client = _client;
            DataContext = client;
            //_parent = parent;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                return;

            string url = "http://localhost:8080/post/Client";

            Client client1 = new Client()
            {
                ClientName = this.tbName.Text,
                PhoneNumber = this.tbPhNum.Text,
            };

            string request = await Helper.PostData(url, client1);

            if (request != null)
            {
                //_parent.clients_window_loaded(sender,e);
                this.Close();
            }
            else
                MessageBox.Show("При добавлении нового клиента произошла ошибка", "Ошибка!", MessageBoxButton.OK);
        }
    }
}
