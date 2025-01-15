using BankWPFCore.Models.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankWPFCore.Services
{
    internal class SettingsManager
    {
        private readonly string _filePath;

        public SettingsManager(string filePath)
        {
            _filePath = filePath;
        }

        public ApiConfiguration LoadSettings()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                ApiConfiguration cs = new ApiConfiguration();
                    cs = JsonSerializer.Deserialize<ApiConfiguration>(json);
                return cs;
            }
            else
            {
                return new ApiConfiguration(); // Возвращаем пустые настройки, если файл не существует
            }
        }

        public void SaveSettings(ApiConfiguration settings)
        {
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
