using BankWPF.Classes;
using BankWPF.Views;
using BankWPF.ViewModels;
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

            DataContext = new ClientsViewModel();
        }

        public async void clients_window_loaded(object sender, RoutedEventArgs e)
        {

            //Btn_click_del btn_Click_Del = clients_window_loaded;

            //асинхронное получение данных от сервера
            /*var jsonData = await Helper.GetData("http://localhost:8080/get/Clients"*//*, this, btn_Click_Del, sender, e*//*);

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
            }*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //ClientWindow clientWindow = new ClientWindow(this);
            //clientWindow.Show();

            //this.clients_window_loaded(sender,e);
        }
    }
}
