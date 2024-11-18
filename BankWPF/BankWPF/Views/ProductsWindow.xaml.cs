using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using BankWPF.Classes;
using BankWPF.Models;

namespace BankWPF
{

    delegate void Btn_click_del(object sender, RoutedEventArgs e);
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {

        public ProductsWindow()
        {
            InitializeComponent();

        }

        private async void products_window_loaded(object sender, RoutedEventArgs e)
        {

            //Btn_click_del btn_Click_Del = products_window_loaded;

            //асинхронное получение данных от сервера
            var jsonData = await Helper.GetData("http://localhost:8080/get/Contracts"/*, this, btn_Click_Del, sender, e*/);

            if (jsonData != null)
            {
                List<Contract> parsedData = JsonConvert.DeserializeObject<List<Contract>>(jsonData);
                ProductsGrid.ItemsSource = parsedData;
            }
            else
            {
                if (MessageBox.Show("Ошибка подключения к серверу " + ".\nПопробовать попробовать подключиться снова? ", "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                    //btn_Click_Del(sender, e);
                    products_window_loaded(sender, e);
                }
                else
                    Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

