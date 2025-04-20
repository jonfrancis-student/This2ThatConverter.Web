using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using This2ThatConverter.Services;
using This2ThatConverter.Services.Interfaces;

namespace This2ThatConverter.Services
{
    public class UnitConversionService : IUnitConversionService
    {
        #region Metric to Imperial Weight Conversion Methods
        public double MilligramsToOunces(double milligrams) => milligrams / 28349.5;
        public double GramsToOunces(double grams) => grams / 28.3495;
        public double KilogramsToOunces(double kilograms) => kilograms * 35.274;
        public double MetricTonsToOunces(double metricTons) => metricTons * 35274;

        public double MilligramsToPounds(double milligrams) => milligrams / 453592;
        public double GramsToPounds(double grams) => grams / 453.592;
        public double KilogramsToPounds(double kilograms) => kilograms * 2.20462;
        public double MetricTonsToPounds(double metricTons) => metricTons * 2204.62;

        public double MilligramsToStones(double milligrams) => milligrams / 6350293.18;
        public double GramsToStones(double grams) => grams / 6350.29318;
        public double KilogramsToStones(double kilograms) => kilograms * 0.157473;
        public double MetricTonsToStones(double metricTons) => metricTons * 157.473;

        public double MilligramsToImperialTon(double milligrams) => milligrams / 1016047000;
        public double GramsToImperialTon(double grams) => grams / 1016047;
        public double KilogramsToImperialTon(double kilograms) => kilograms / 1016.047;
        public double MetricTonsToImperialTon(double metricTons) => metricTons * 0.984207;
        #endregion

        #region Imperial to Metric Weight Conversion Methods
        public double OuncesToMilligrams(double ounces) => ounces * 28349.5;
        public double PoundsToMilligrams(double pounds) => pounds * 453592;
        public double StonesToMilligrams(double stones) => stones * 6350293.18; 
        public double ImperialTonToMilligrams(double imperialTon) => imperialTon * 1016047000;

        public double OuncesToGrams(double ounces) => ounces * 28.3495;
        public double PoundsToGrams(double pounds) => pounds * 453.592;
        public double StonesToGrams(double stones) => stones * 6350.29318;
        public double ImperialTonToGrams(double imperialTon) => imperialTon * 1016047;

        public double OuncesToKilograms(double ounces) => ounces / 35.274;
        public double PoundsToKilograms(double pounds) => pounds / 2.20462;
        public double StonesToKilograms(double stones) => stones / 0.157473;
        public double ImperialTonToKilograms(double imperialTon) => imperialTon * 1016.047;

        public double OuncesToMetricTons(double ounces) => ounces / 35274;
        public double PoundsToMetricTons(double pounds) => pounds / 2204.62;
        public double StonesToMetricTons(double stones) => stones / 157.473;
        public double ImperialTonToMetricTon(double imperialTon) => imperialTon * 1.016047;
        #endregion

        #region Metric to Imperial Length Conversion Methods
        public double MillimetersToInches(double millimeters) => millimeters / 25.4;
        public double CentimetersToInches(double centimeters) => centimeters / 2.54;
        public double MetersToInches(double meters) => meters * 39.3701;
        public double KilometersToInches(double kilometers) => kilometers * 39370.1;

        public double MillimetersToFeet(double millimeters) => millimeters / 304.8;
        public double CentimetersToFeet(double centimeters) => centimeters / 30.48;
        public double MetersToFeet(double meters) => meters * 3.28084;
        public double KilometersToFeet(double kilometers) => kilometers * 3280.84;

        public double MillimetersToYards(double millimeters) => millimeters / 914.4;
        public double CentimetersToYards(double centimeters) => centimeters / 91.44;
        public double MetersToYards(double meters) => meters * 1.09361;
        public double KilometersToYards(double kilometers) => kilometers * 1093.61;

        public double MillimetersToMiles(double millimeters) => millimeters / 1609344;
        public double CentimetersToMiles(double centimeters) => centimeters / 160934;
        public double MetersToMiles(double meters) => meters / 1609.344;
        public double KilometersToMiles(double kilometers) => kilometers / 1.609344;
        #endregion

        #region Imperial to Metric Length Conversion Methods
        public double InchesToMillimeters(double inches) => inches * 25.4;
        public double FeetToMillimeters(double feet) => feet * 304.8;
        public double YardsToMillimeters(double yards) => yards * 914.4;
        public double MilesToMillimeters(double miles) => miles * 1609344;

        public double InchesToCentimeters(double inches) => inches * 2.54;
        public double FeetToCentimeters(double feet) => feet * 30.48;
        public double YardsToCentimeters(double yards) => yards * 91.44;
        public double MilesToCentimeters(double miles) => miles * 160934;

        public double InchesToMeters(double inches) => inches * 0.0254;
        public double FeetToMeters(double feet) => feet * 0.3048;
        public double YardsToMeters(double yards) => yards * 0.9144;
        public double MilesToMeters(double miles) => miles * 1609.344;

        public double InchesToKilometers(double inches) => inches / 39370.1;
        public double FeetToKilometers(double feet) => feet / 3280.84;
        public double YardsToKilometers(double yards) => yards / 1093.61;
        public double MilesToKilometers(double miles) => miles * 1.609344;
        #endregion

        #region Temperature Conversion Methods
        public double CelsiusToFahrenheit(double celsius) => (celsius * 9 / 5) + 32;
        public double FahrenheitToCelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;
        #endregion
    }
}







