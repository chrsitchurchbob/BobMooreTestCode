using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTest.Client.Services
{
    public interface IWeatherUnitOfMeasureConverter
    {
        double CelciusToFahrenheit(double val);
        double FahrenheitToCelcius(double val);

        double KmhToMph(double val);
        double MphToKmh(double val);
    }
}
