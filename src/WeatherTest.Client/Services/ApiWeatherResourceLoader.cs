using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherTest.Client.Services
{
    public class ApiWeatherResourceLoader : IWeatherResourceLoader
    {
        private Uri SourceUri { get; set; }
        private IResultParser Parser { get; set; }

        private const int Timeout = 3000;
        public ApiWeatherResourceLoader(Uri source,IResultParser parser)
        {
            SourceUri = source;
            Parser = parser;
        }

        public async Task<WeatherResult> GetWeatherAsync(string location)
        {
            //http://localhost:60368/[location]
            // JSON { "temperatureFahrenheit":62.0,"where":"wwewwe","windSpeedMph":19.0}
            //http://localhost:60350/weather\[location]
            //Json { "location":"wewewew","temperatureCelsius":17.0,"windSpeedKph":16.0}

            using (var client = new HttpClient())
            {
                var url = BuildRequestUrl(location);

                var delayTask = Task.Delay(Timeout);
                var callTask = client.GetStringAsync(url);
                //await the first task to finish, if its the delay then we know that our task has
                //taken longer than the delay and we are disregarding it and marking the response as an error
                //If an error happens on the download task then it will faill but the delay will be the one to trigger
                var resultTask = await Task.WhenAny(delayTask, callTask);
                
                if (resultTask == delayTask)
                {
                    return new WeatherResult(location, null, null) { IsTimeoutOrError = true };
                }
                else
                {
                    return Parser.Parse(callTask.Result);
                }
            }
        }

        private string BuildRequestUrl(string location)
        {
            return Path.Combine(SourceUri.AbsoluteUri, location);
        }
    }
}
