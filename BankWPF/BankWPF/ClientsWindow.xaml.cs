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

            Btn_click_del btn_Click_Del = clients_window_loaded;

            //асинхронное получение данных от сервера
            var json2 = await Helper.GetData("http://localhost:8080/get/Clients", this, btn_Click_Del, sender, e);

            var parsedData = JsonConvert.DeserializeObject<List<Client>>(json2);

            ClientsGrid.ItemsSource = parsedData;
        }

       
    }
}
