using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStatisticApp
{
    class Weather : Object
    {
        string city;
        DateTime date;
        int minTemperature;
        int maxTemperature;
        double deltaTemperature;
        int clouds;
        int precipitationValue;
        int humidity;
        double windPower;
        double windDirection;

        public string City { get => city; set => city = value; }
        public int MinTemperature { get => minTemperature; set => minTemperature = value; }
        public int MaxTemperature { get => maxTemperature; set => maxTemperature = value; }
        public int Clouds { get => clouds; set => clouds = value; }
        public int PrecipitationValue { get => precipitationValue; set => precipitationValue = value; }
        public int Humidity { get => humidity; set => humidity = value; }
        public double WindPower { get => windPower; set => windPower = value; }
        public double WindDirection { get => windDirection; set => windDirection = value; }
        public double DeltaTemperature { get => deltaTemperature;}
        public DateTime Date { get => date; set => date = value; }

        public Weather(
            string city, 
            int minTemperature, 
            int maxTemperature, 
            int clouds, 
            int precipitationValue, 
            int humidity, 
            double windPower, 
            double windDirection,
            DateTime date) : base()
        {
            City = city;
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
            Clouds = clouds;
            PrecipitationValue = precipitationValue;
            Humidity = humidity;
            WindPower = windPower;
            WindDirection = windDirection;
            Date = date;
            deltaTemperature = (double)(minTemperature + maxTemperature) / 2;
        }

       
    }
}
