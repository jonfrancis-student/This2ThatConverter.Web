using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using This2ThatConverter.Web.Models;
using This2ThatConverter.Models;
using This2ThatConverter.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace This2ThatConverter.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitConversionService _unitConversionService;
        private readonly Dictionary<(string from, string to), Func<double, double>> _conversionMap; // Dictionary for mapping unit conversions (better than if else)

        //Dependency Injection
        public HomeController(IUnitConversionService unitConversionService)
        {
            _unitConversionService = unitConversionService;
            // Mappings for ConvertUnit Action Method
            _conversionMap = new()
            {
                // Metric to Imperial - Weight
                { ("milligrams", "ounces"), unitConversionService.MilligramsToOunces },
                { ("grams", "ounces"), unitConversionService.GramsToOunces },
                { ("kilograms", "ounces"), unitConversionService.KilogramsToOunces },
                { ("metricton", "ounces"), unitConversionService.MetricTonsToOunces },

                { ("milligrams", "pounds"), unitConversionService.MilligramsToPounds },
                { ("grams", "pounds"), unitConversionService.GramsToPounds },
                { ("kilograms", "pounds"), unitConversionService.KilogramsToPounds },
                { ("metricton", "pounds"), unitConversionService.MetricTonsToPounds },

                { ("milligrams", "stones"), unitConversionService.MilligramsToStones },
                { ("grams", "stones"), unitConversionService.GramsToStones },
                { ("kilograms", "stones"), unitConversionService.KilogramsToStones },
                { ("metricton", "stones"), unitConversionService.MetricTonsToStones },

                { ("milligrams", "imperialton"), unitConversionService.MilligramsToImperialTon },
                { ("grams", "imperialton"), unitConversionService.GramsToImperialTon },
                { ("kilograms", "imperialton"), unitConversionService.KilogramsToImperialTon },
                { ("metricton", "imperialton"), unitConversionService.MetricTonsToImperialTon },

                // Imperial to Metric - Weight
                { ("ounces", "milligrams"), unitConversionService.OuncesToMilligrams },
                { ("pounds", "milligrams"), unitConversionService.PoundsToMilligrams },
                { ("stones", "milligrams"), unitConversionService.StonesToMilligrams },
                { ("imperialton", "milligrams"), unitConversionService.ImperialTonToMilligrams },

                { ("ounces", "grams"), unitConversionService.OuncesToGrams },
                { ("pounds", "grams"), unitConversionService.PoundsToGrams },
                { ("stones", "grams"), unitConversionService.StonesToGrams },
                { ("imperialton", "grams"), unitConversionService.ImperialTonToGrams },

                { ("ounces", "kilograms"), unitConversionService.OuncesToKilograms },
                { ("pounds", "kilograms"), unitConversionService.PoundsToKilograms },
                { ("stones", "kilograms"), unitConversionService.StonesToKilograms },
                { ("imperialton", "kilograms"), unitConversionService.ImperialTonToKilograms },

                { ("ounces", "metricton"), unitConversionService.OuncesToMetricTons },
                { ("pounds", "metricton"), unitConversionService.PoundsToMetricTons },
                { ("stones", "metricton"), unitConversionService.StonesToMetricTons },              
                { ("imperialton", "metricton"), unitConversionService.ImperialTonToMetricTon },

                // Metric to Imperial - Length
                { ("millimeters", "inches"), unitConversionService.MillimetersToInches },
                { ("centimeters", "inches"), unitConversionService.CentimetersToInches },
                { ("meters", "inches"), unitConversionService.MetersToInches },
                { ("kilometers", "inches"), unitConversionService.KilometersToInches },

                { ("millimeters", "feet"), unitConversionService.MillimetersToFeet },
                { ("centimeters", "feet"), unitConversionService.CentimetersToFeet },
                { ("meters", "feet"), unitConversionService.MetersToFeet },
                { ("kilometers", "feet"), unitConversionService.KilometersToFeet },

                { ("millimeters", "yards"), unitConversionService.MillimetersToYards },
                { ("centimeters", "yards"), unitConversionService.CentimetersToYards },
                { ("meters", "yards"), unitConversionService.MetersToYards },
                { ("kilometers", "yards"), unitConversionService.KilometersToYards },

                { ("millimeters", "miles"), unitConversionService.MillimetersToMiles },
                { ("centimeters", "miles"), unitConversionService.CentimetersToMiles },
                { ("meters", "miles"), unitConversionService.MetersToMiles },
                { ("kilometers", "miles"), unitConversionService.KilometersToMiles },

                // Imperial to Metric - Length
                { ("inches", "millimeters"), unitConversionService.InchesToMillimeters },
                { ("feet", "millimeters"), unitConversionService.FeetToMillimeters },
                { ("yards", "millimeters"), unitConversionService.YardsToMillimeters },
                { ("miles", "millimeters"), unitConversionService.MilesToMillimeters },

                { ("inches", "centimeters"), unitConversionService.InchesToCentimeters },
                { ("feet", "centimeters"), unitConversionService.FeetToCentimeters },
                { ("yards", "centimeters"), unitConversionService.YardsToCentimeters },
                { ("miles", "centimeters"), unitConversionService.MilesToCentimeters },

                { ("inches", "meters"), unitConversionService.InchesToMeters },
                { ("feet", "meters"), unitConversionService.FeetToMeters },
                { ("yards", "meters"), unitConversionService.YardsToMeters },
                { ("miles", "meters"), unitConversionService.MilesToMeters },

                { ("inches", "kilometers"), unitConversionService.InchesToKilometers },
                { ("feet", "kilometers"), unitConversionService.FeetToKilometers },
                { ("yards", "kilometers"), unitConversionService.YardsToKilometers },
                { ("miles", "kilometers"), unitConversionService.MilesToKilometers },

                // Temperature
                { ("celsius", "fahrenheit"), unitConversionService.CelsiusToFahrenheit },
                { ("fahrenheit", "celsius"), unitConversionService.FahrenheitToCelsius }
            };

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region Unit Conversion Functionality
        [HttpPost]
        public IActionResult ConvertUnit([FromBody] UnitConversionRequest request)
        {
            try
            {
                var key = (request.FromUnit.ToLower(), request.ToUnit.ToLower());

                if (_conversionMap.TryGetValue(key, out var conversionFunc))
                {
                    var result = conversionFunc(request.Value);
                    return Json(new { success = true, result });
                }
                else
                {
                    return Json(new { success = false, message = "Conversion not supported." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }
        #endregion


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
