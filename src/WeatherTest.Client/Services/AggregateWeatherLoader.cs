using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTest.Client.Services
{
    public class AggregateWeatherLoader : IAggregateWeatherLoader
    {
        //List of Api resources to load
        public List<IWeatherResourceLoader> Resources { get; private set; }
        

        public AggregateWeatherLoader()
        {
            this.Resources = new List<IWeatherResourceLoader>();
        }
        // to build a list of resources and set up task ti run all weather APIs before doing anything
        public async Task<AggregateWeatherResult> LoadAggregateWeatherAsync(string location)
        {   
             
            var ret = new AggregateWeatherResult();
            //Create a list of tasks that will download each result
            var tasks = this.Resources.Select(r => r.GetWeatherAsync(location));
            //await completion of all tasks, remember a task can timeout or error
            var results = await Task.WhenAll(tasks);

            // Is TimeoutOrError is to filter out results that have null for temp or windspeed
            ret.Location = location;
            ret.AvgTemperature = new Temperature(results.Where(r=> !r.IsTimeoutOrError).Average(r => r.Temperature.Celcius), TemperatureMeasure.Celcius);
            ret.AvgWindSpeed = new WindSpeed(results.Where(r => !r.IsTimeoutOrError).Average(r => r.WindSpeed.Mph), SpeedMeasure.Mph);
            ret.Results = results;
            return ret;
        }

       
    }
}
