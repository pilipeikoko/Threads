using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class WeatherService
    {
        WeatherResponse weatherResponse;

        public string CityName
        {
            get
            {
                return weatherResponse.Name;
            }
        }

        public float Temperature
        {
            get
            {
                return weatherResponse.Main.Temp;
            }
        }

        public float FeelsLike
        {
            get
            {
                return weatherResponse.Main.Feels_like;
            }
        }

        private class WeatherResponse
        {
            public TemperatureInfo Main { get; set; }

            public string Name { get; set; }
        }
        private class TemperatureInfo
        {
            public float Temp { get; set; }
            public float Feels_like { get; set; }
        }

        public void UpdateWeather()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Minsk&units=metric&appid=b705ba6086774e62bc337bb9e3fdc166";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
        }


    }
}
