using BankWPFCore.Exceptions;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BankWPFCore.Services.ApiServices
{


    internal class RequestsToApiService : IRequestsToApiService
    {


        public async Task<string> GetDataFromApi(string requestUrl)
        {
            string res = string.Empty;
            int statusCode = 0;

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);//var
                    statusCode = (int)response.StatusCode;
                    response.EnsureSuccessStatusCode(); // Проверяет, был ли ответ успешным
                    res = await response.Content.ReadAsStringAsync();
                    //response.StatusCode

                }

                return res;
            }
            catch (HttpRequestException httpEx)
            {
                statusCode = (int)httpEx.StatusCode.GetValueOrDefault();
                throw new ApiConnectionException(httpEx, statusCode, "Ошибка подключения."); //TODO!!!
            }
            catch (Exception ex)
            {

                throw new ApiConnectionException(ex, statusCode, "Ошибка подключения."); //TODO!!!
                //return null;
            }
        }

        public async Task<string> PostDataToApi/*<T>*/(string url, object dataForPost)
        {

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dataForPost);

            // Создаем HttpClient
            using (var client = new HttpClient())
            {

                int statusCode = 0;
                // Создаем содержимое запроса
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Отправляем POST-запрос
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode(); // Проверяет, был ли ответ успешным
                    // Проверяем успешность запроса
                    if (response.IsSuccessStatusCode)
                    {
                        // Читаем ответ
                        string responseBody = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        //
                    }

                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException httpEx)
                {
                    statusCode = (int)httpEx.StatusCode.GetValueOrDefault();
                    throw new ApiConnectionException(httpEx, statusCode, "Ошибка подключения."); //TODO!!!
                }
                catch (Exception ex)
                {
                    
                    throw new ApiConnectionException(ex, statusCode, "Ошибка подключения."); //TODO!!!
                    //Console.WriteLine($"Exception caught: {ex.Message}");
                    //return null;
                }
            }
        }

    }
}
