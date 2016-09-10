using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTest.Client.Services
{
    public interface IAggregateWeatherLoader
    {
        Task<AggregateWeatherResult> LoadAggregateWeatherAsync(string location);

    }
}
