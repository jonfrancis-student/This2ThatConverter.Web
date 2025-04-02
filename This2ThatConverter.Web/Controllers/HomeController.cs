using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using This2ThatConverter.Web.Models;
using This2ThatConverter.Services.Interfaces;

namespace This2ThatConverter.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitConversionService _unitConversionService;

        //Dependency Injection
        public HomeController(IUnitConversionService unitConversionService)
        {
            _unitConversionService = unitConversionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MetricToImperial(double inputValue)
        {
            //_unitConversionService.FahrenheitToCelsius(inputValue);
            return View();
        }

        [HttpPost]
        public IActionResult ImperialToMetric()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
