using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStatisticApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherStatistic statistic = new WeatherStatistic(RandomWeather.GetRandomWeather("Odessa", 2019));

            
            Console.WriteLine(statistic + "\n\n");

            Weather weather = new Weather("Odessa", 1000, 1550, 12, 0, 78, 4, 152.2, new DateTime(2019, 11, 21));
            statistic.AddDay(21, 11, weather);

            Console.WriteLine(statistic);

            Console.WriteLine(weather);

        }
    }
}
