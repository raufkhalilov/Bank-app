using BankWPFCore.Models.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFCore.Services
{
    internal class ApiSettingsService
    {
        IConfigurationBuilder builder;
        IConfiguration configuration;
        List<Dictionary<string, Urls>> _apiConfigs;

        public ApiSettingsService(string apiFileSettingsPath)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(apiFileSettingsPath, optional: false, reloadOnChange: true);

            configuration = builder.Build();

            // Получение массива Api из конфигурации
            _apiConfigs = configuration.GetSection("Api").Get<List<Dictionary<string, Urls>>>();

            var availableKeys = new List<string>();
            foreach (var item in _apiConfigs)
            {
                foreach (var keyValuePair in item)
                {
                    availableKeys.Add(keyValuePair.Key);
                }
            }
        }

        public Urls findApi(string apiKey)
        {
            //string userInput = Console.ReadLine();
            Urls urls = new Urls();
            // Поиск и вывод выбранного набора URL
            //bool found = false;
            foreach (var item in _apiConfigs)
            {
                if (item.ContainsKey(apiKey))
                {
                    //found = true;
                    urls = item[apiKey];

/*                    Console.WriteLine($"Ключ: {apiKey}");
                    Console.WriteLine($"URL1: {urls.url1}");
                    Console.WriteLine($"URL2: {urls.url2}");
                    Console.WriteLine($"URL3: {urls.url3}");*/
                    break;
                }
            }

            return urls;
        }
        
        public void SetupApi()
        {
            string CurrentApiKey = configuration.GetSection("CurrentKey").Get<string>();
        }

    }

}
