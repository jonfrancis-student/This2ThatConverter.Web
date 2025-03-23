using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace This2ThatConverter.Services.Interfaces
{
    public interface IUnitConversionService
    {
        // Metric to Imperial Weight Conversion Methods
        double MilligramsToOunces(double milligrams);
        double GramsToOunces(double grams);
        double KilogramsToOunces(double kilograms);
        double MetricTonsToOunces(double metricTons);

        double MilligramsToPounds(double milligrams);
        double GramsToPounds(double grams);
        double KilogramsToPounds(double kilograms);
        double MetricTonsToPounds(double metricTons);

        double MilligramsToStones(double milligrams);
        double GramsToStones(double grams);
        double KilogramsToStones(double kilograms);
        double MetricTonsToStones(double metricTons);

        double MilligramsToImperialTon(double milligrams);
        double GramsToImperialTon(double grams);
        double KilogramsToImperialTon(double kilograms);
        double MetricTonsToImperialTon(double metricTons);

        // Imperial to Metric Weight Conversion Methods
        double OuncesToMilligrams(double ounces);
        double PoundsToMilligrams(double pounds);
        double KilogramsToMilligrams(double kilograms);
        double ImperialTonToMilligrams(double imperialTon);

        double OuncesToGrams(double ounces);
        double PoundsToGrams(double pounds);
        double KilogramsToGrams(double kilograms);
        double ImperialTonToGrams(double imperialTon);

        double OuncesToKilograms(double ounces);
        double PoundsToKilograms(double pounds);
        double ImperialTonToKilograms(double imperialTon);
        double ImperialTonToMetricTon(double imperialTon);

        // Metric to Imperial Length Conversion Methods
        double MillimetersToInches(double millimeters);
        double CentimetersToInches(double centimeters);
        double MetersToInches(double meters);
        double KilometersToInches(double kilometers);

        double MillimetersToFeet(double millimeters);
        double CentimetersToFeet(double centimeters);
        double MetersToFeet(double meters);
        double KilometersToFeet(double kilometers);

        double MillimetersToYards(double millimeters);
        double CentimetersToYards(double centimeters);
        double MetersToYards(double meters);
        double KilometersToYards(double kilometers);

        double MillimetersToMiles(double millimeters);
        double CentimetersToMiles(double centimeters);
        double MetersToMiles(double meters);
        double KilometersToMiles(double kilometers);

        // Imperial to Metric Length Conversion Methods
        double InchesToMillimeters(double inches);
        double FeetToMillimeters(double feet);
        double YardsToMillimeters(double yards);
        double MilesToMillimeters(double miles);

        double InchesToCentimeters(double inches);
        double FeetToCentimeters(double feet);
        double YardsToCentimeters(double yards);
        double MilesToCentimeters(double miles);

        double InchesToMeters(double inches);
        double FeetToMeters(double feet);
        double YardsToMeters(double yards);
        double MilesToMeters(double miles);

        double InchesToKilometers(double inches);
        double FeetToKilometers(double feet);
        double YardsToKilometers(double yards);
        double MilesToKilometers(double miles);

        // Temperature Conversion Methods
        double CelsiusToFahrenheit(double celsius);
        double FahrenheitToCelsius(double fahrenheit);
    }
}
