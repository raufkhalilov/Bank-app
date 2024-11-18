﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Services
{
    interface IRequestsToApiService
    {
        Task<string> GetDataFromApi(string url);

        Task<string> PostDataToApi<T>(string url, T dataForPost);
    }

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
                return null;
            }
        }

        public async Task<string> PostDataToApi<T>(string url, T dataForPost)
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
