using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTest.Client.Services
{
    public interface IResultParser
    {
        WeatherResult Parse(string result);
    }
}
