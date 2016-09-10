using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WeatherTest.Client.Services.ApiParsers
{
    /// <summary> 
    /// For parsing Accu weather api response
    /// </summary>
    public class AccuParser : IResultParser
    {
        /// <summary>
        /// /// For parsing Accu Weather api response
        //  API Call AND Return JSON
        //   http://localhost:60368/[location]
        // JSON { "temperatureFahrenheit":62.0,"where":"wwewwe","windSpeedMph":19.0}
        /// </summary>
        public WeatherResult Parse(string result)
        {
            var localObject = JsonConvert.DeserializeObject<AccWeatherResult>(result);
            return new WeatherResult(localObject.Where, localObject.TemperatureFahrenheit, 
                TemperatureMeasure.Fh, localObject.WindSpeedMph, SpeedMeasure.Mph);
        }

        [DataContract]
        private class AccWeatherResult
        {
            [DataMember(Name = "temperatureFahrenheit")]
            public double TemperatureFahrenheit { get; internal set; }

            [DataMember(Name = "where")]
            public string Where { get; internal set; }

            [DataMember(Name = "windSpeedMph")]
            public double WindSpeedMph { get; internal set; }
        }
    }
}
