﻿using BankWPFCore.Exceptions;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices
{


    internal class RequestsToApiService : IRequestsToApiService
    {


        public async Task<string> GetDataFromApi(string requestUrl)
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

                throw new ApiConnectionException(ex.Message); //TODO!!!
                //return null;
            }
        }

        public async Task<string> PostDataToApi/*<T>*/(string url, object dataForPost)
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
                    }
                    else
                    {
                        //
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
