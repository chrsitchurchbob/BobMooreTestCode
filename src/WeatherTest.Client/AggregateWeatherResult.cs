using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTest.Client
{
    public class AggregateWeatherResult
    {
        public string Location { get; internal set; }
        public IReadOnlyCollection<WeatherResult> Results { get; internal set; }

        public WindSpeed AvgWindSpeed { get; internal set; }

        public Temperature AvgTemperature { get; internal set; }
    }
}
