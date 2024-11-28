using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Classes
{
    internal class Helper
    {
        //ф-ия принимет строку-URLссылу, указатель на окно из которого произошел вызов, указатель на 
        public static async Task<string> GetData(string requestUrl)
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

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
            //return res;
        }

        public static async Task<string> PostData<T>(string url, T dataForPost)
        {

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dataForPost);

            // Создаем HttpClient
            using (var client = new HttpClient())
            { 
                // Создаем содержимое запроса
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Отправляем POST-запрос
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Проверяем успешность запроса
                    if (response.IsSuccessStatusCode)
                    {
                        // Читаем ответ
                        string responseBody = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine("Response received: " + responseBody);
                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");
                    }


                    return await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Exception caught: {ex.Message}");

                    return null;
                }


            }


        }

    }
}
