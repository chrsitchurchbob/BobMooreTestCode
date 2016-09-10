using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherTest.Client.Services;
using WeatherTest.Client.Services.ApiParsers;

namespace ConsoleApp1
{
    public class Program
    {

        private static AggregateWeatherLoader WeatherLoader = new AggregateWeatherLoader();
        public static void Main(string[] args)
        {
            //We could load this in from a config file or database but just hard code for this example
            WeatherLoader.Resources.Add(new ApiWeatherResourceLoader(new Uri("http://localhost:60368"), new AccuParser()));
            WeatherLoader.Resources.Add(new ApiWeatherResourceLoader(new Uri("http://localhost:60350/weather"), new BBCParser()));


            Console.WriteLine("Please enter your location");

            var location = Console.ReadLine();

            if (!String.IsNullOrEmpty(location))
            {
                Console.WriteLine("Please enter kph or mph (default is kph)");

                var speedUnit = Console.ReadLine();

                Console.WriteLine("Please enter cs or fh (default is cs)");

                var tempUnit = Console.ReadLine();

                //Make sure we set default so we can display it
                if (tempUnit != "cs" && tempUnit != "fh") tempUnit = "cs";
                if (speedUnit != "kph" && speedUnit != "mph") speedUnit = "kph";

                try
                {
                    //Cant use await & async in main
                    var results = WeatherLoader.LoadAggregateWeatherAsync(location).Result;

                    var wasError = results.Results.Any(r => r.IsTimeoutOrError);
                    if (wasError)
                    {
                        Console.WriteLine("One or more sources for your weather did not response in time..");
                    }
                    Console.WriteLine("Average Temperature is {0:0.##} {1}", tempUnit == "cs" ? results.AvgTemperature.Celcius : results.AvgTemperature.Fahrenheit, tempUnit);
                    Console.WriteLine("Average Wind speed is {0:0.##} {1}", speedUnit == "kph" ? results.AvgWindSpeed.Kph : results.AvgWindSpeed.Mph, speedUnit);
                }
                catch (Exception)                {
                    Console.WriteLine("One or more sources for your weather did not response in time..");                    
                }
            }
            else
            {
                Console.WriteLine("You must enter your location!");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
