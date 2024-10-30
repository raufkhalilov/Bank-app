using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF.Classes
{
    internal class Helper
    {

        public static async Task<string> GetData(string requestUrl, Window window, Btn_click_del btn_Click_Del, object sender, RoutedEventArgs e)
        {
            string res = string.Empty;

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(requestUrl);
                    response.EnsureSuccessStatusCode(); // Проверяет, был ли ответ успешным
                    res = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Ошибка подключения к серверу.\nПопробовать попробовать подключиться снова? ", "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
  
                    btn_Click_Del(sender, e);
                }
                else
                    window.Close();
                    //sender.;
                    //this.Close();
            }
            
            return res;
        }
    }
}
