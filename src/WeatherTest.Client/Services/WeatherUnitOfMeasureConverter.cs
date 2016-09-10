using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTest.Client.Services
{
    public class WeatherUnitOfMeasureConverter : IWeatherUnitOfMeasureConverter
    {
        private const double KmPerMile = 1.60934;
        public double CelciusToFahrenheit(double val)
        {
           return (val * 9) / 5 + 32;
        }

        public double FahrenheitToCelcius(double val)
        {
            return (5.0 / 9.0) * (val - 32);
        }

        public double KmhToMph(double val)
        {
            return val / KmPerMile;
        }

        public double MphToKmh(double val)
        {
            return KmPerMile * val;
        }
    }
}
