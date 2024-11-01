using BankWPF.Classes;
using Newtonsoft.Json;
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
using BankWPF.Models;
using System.Net.Http;
using System.Net;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BankWPF
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
        }

        private async void clients_window_loaded(object sender, RoutedEventArgs e)
        {

            //Btn_click_del btn_Click_Del = clients_window_loaded;

            //асинхронное получение данных от сервера
            var jsonData = await Helper.GetData("http://localhost:8080/get/Clients"/*, this, btn_Click_Del, sender, e*/);

            if (jsonData != null)
            {
                List<Client> parsedData = JsonConvert.DeserializeObject<List<Client>>(jsonData);
                ClientsGrid.ItemsSource = parsedData;
            }
            else
            {
                if (MessageBox.Show("Ошибка подключения к серверу " + ".\nПопробовать попробовать подключиться снова? ", "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                    //btn_Click_Del(sender, e);
                    clients_window_loaded(sender, e);
                }
                else
                    Close();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите добавить нового клиента?", "Добавление клиента", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                return;

            string url = "http://localhost:8080/post/Client";

            Client client1 = new Client()
            {
                client_name = "Test3",
                phone_number = "Test",
            };

            string request = await Helper.PostData(url, client1);

            if (request != null)
                this.clients_window_loaded(sender,e);
               
        }
    }
}
