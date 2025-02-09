using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AgroSarmer.Models;

namespace AgroSarmer.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "api.meteomatics.com/2025-01-24T00:00:00Z/t_2m:C/52.520551,13.461804/html"; // Ваш ключ Meteomatics

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherInfo> GetWeatherAsync(double latitude, double longitude)
        {
            // Формируем запрос к API Meteomatics
            var url = $"https://api.meteomatics.com/{_apiKey}/forecast?latitude={latitude}&longitude={longitude}&start=2025-01-24T00:00:00Z&parameters=t_2m:C&format=json";

            // Отправка запроса и получение ответа
            var response = await _httpClient.GetStringAsync(url);

            // Обработка полученного JSON
            dynamic data = JsonConvert.DeserializeObject(response);

            // Извлечение данных из ответа
            return new WeatherInfo
            {
                City = "Berlin", // Вы можете добавить название города, если необходимо
                Temperature = $"{data.data[0].values[0]} °C", // Пример доступа к данным, уточните путь
                Description = "Погода на основе API Meteomatics", // Описание по умолчанию
                Icon = "https://example.com/weather-icon.png" // Используйте реальную картинку, если есть
            };
        }
    }
}

