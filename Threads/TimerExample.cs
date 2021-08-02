using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class TimerExample
    {

        public static void UpdateAndShowWeather(object obj)
        {
            WeatherService service = new();
            service.UpdateWeather();
            Console.WriteLine($"Temperature in {service.CityName}: {service.Temperature} °C, feels like {service.FeelsLike}");
        }

        public static void Main(string[] args)
        {
            TimerCallback timerCallback = new TimerCallback(UpdateAndShowWeather);
            Timer timer = new Timer(timerCallback, null, 0, 1000);
            Console.ReadLine();
        }
    }
}
