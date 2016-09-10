using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTest.Client
{
    public class WeatherResult
    {

        public WeatherResult(string location, double temperature,TemperatureMeasure temperatureMeasure,
            double windSpeed,SpeedMeasure speedMeasure) : 
            this(location,new Temperature(temperature, temperatureMeasure), new WindSpeed(windSpeed,speedMeasure)){}
        public WeatherResult(string location, Temperature temp, WindSpeed windSpeed)
        {
            Location = location;
            WindSpeed = windSpeed;
            Temperature = temp;
        }
        public string Location { get; set; }

        public Temperature Temperature { get; set; }

        public WindSpeed WindSpeed { get; set; }

        public bool IsTimeoutOrError { get; set; }

    }
}
