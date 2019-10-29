using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStatisticApp
{
    class RandomWeather
    {
        public static List<List<Weather>> GetRandomWeather(string city, int year)
        {
            List<List<Weather>> yearStatistic = new List<List<Weather>>();

            int[] daysCount = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            Random rand = new Random();
            
            for (int i = 0; i < 12; i++)
            {
                List<Weather> mounthStatistic = new List<Weather>();

                for (int j = 0; j < daysCount[i]; j++)
                {
                    int clouds = rand.Next(101);
                    int precipitationValue = rand.Next(300);
                    int humidity = rand.Next(101);
                    double windPower = rand.NextDouble() * 40;
                    double windDirection = rand.NextDouble() * 360;
                   
                    int minTemperature = rand.Next(-20, 45);
                    int maxTemperature = minTemperature + rand.Next(3, 10);

                    Weather weather = new Weather(city, minTemperature, maxTemperature, clouds, precipitationValue, humidity, windPower, windDirection, new DateTime(year, i + 1, j + 1));
                    mounthStatistic.Add(weather);
                }

                yearStatistic.Add(mounthStatistic);
                
            }

            return yearStatistic;
        }
    }
}
