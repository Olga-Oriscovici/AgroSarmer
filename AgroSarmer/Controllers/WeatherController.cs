using AgroSarmer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgroSarmer.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index()
        {
            // Пример координат для Берлина
            double latitude = 52.520551;
            double longitude = 13.461804;

            var weather = await _weatherService.GetWeatherAsync(latitude, longitude);
            return View(weather);
        }
    }
}
