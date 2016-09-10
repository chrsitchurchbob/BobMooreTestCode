using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherTest.Client.Services;

namespace WeatherTest.Client
{
    public class Temperature
    {
        private IWeatherUnitOfMeasureConverter Converter { get; set; }
        public Temperature(double value,TemperatureMeasure measure,IWeatherUnitOfMeasureConverter converter = null)
        {
            Converter = converter ?? new WeatherUnitOfMeasureConverter(); 
            if (measure == TemperatureMeasure.Celcius)
            {
                Celcius = value;
                Fahrenheit = Converter.CelciusToFahrenheit(value);
            } else if (measure == TemperatureMeasure.Fh)
            {
                Fahrenheit = value;
                Celcius = Converter.FahrenheitToCelcius(value);
            }
        }

        public double Celcius { get; internal set; }
        

        public double Fahrenheit { get; internal set; }
    }
}
