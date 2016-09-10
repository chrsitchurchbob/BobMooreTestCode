using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherTest.Client.Services;

namespace WeatherTest.Client
{
    public class WindSpeed
    {
        private IWeatherUnitOfMeasureConverter Converter { get; set; }
        public WindSpeed(double value, SpeedMeasure measure, IWeatherUnitOfMeasureConverter converter = null)
        {
            Converter = converter ?? new WeatherUnitOfMeasureConverter();
            if (measure == SpeedMeasure.Kph)
            {
                Kph = value;
                Mph = Converter.KmhToMph(value);
            }
            else if (measure == SpeedMeasure.Mph)
            {
                Mph = value;
                Kph = Converter.MphToKmh(value);
            }
        }
        public double Mph { get; internal set; }


        public double Kph { get; internal set; }
    }
}
