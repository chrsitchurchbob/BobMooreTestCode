using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WeatherTest.Client.Services.ApiParsers
{
    /// <summary>
    /// For parsing BBC weather api response
    /// API Call AND Return JSON
    //  http://localhost:60350/weather\[location]
    //  Json { "location":"wewewew","temperatureCelsius":17.0,"windSpeedKph":16.0}
    /// </summary> 
    public class BBCParser : IResultParser
    {
        
        public WeatherResult Parse(string result)
        {
            var localObject = JsonConvert.DeserializeObject<BbcWeatherResult>(result);
            return new WeatherResult(localObject.Location, localObject.TemperatureCelsius,
                TemperatureMeasure.Celcius, localObject.WindSpeedKph, SpeedMeasure.Kph);
        }
        
        [DataContract]
        private class BbcWeatherResult
        {
            [DataMember(Name = "location")]
            public string Location { get; internal set; }

            [DataMember(Name = "temperatureCelsius")]
            public double TemperatureCelsius { get; internal set; }

            [DataMember(Name = "windSpeedKph")]
            public double WindSpeedKph { get; internal set; }
        }
    }
}
