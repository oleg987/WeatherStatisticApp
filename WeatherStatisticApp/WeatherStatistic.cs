using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStatisticApp
{
    class WeatherStatistic
    {
        List<List<Weather>> yearStatistic;
        double deltaTemperature;
        double deltaSunDays;
        int daysWithPersiptation;
        int daysWithWeakWind;
        int daysWithTemperatureUpperDelta;
        int daysWithTemperatureLowerDelta;
        int monthWithMaxPersiptation;
        int monthWithMaxWeakWindDays;

        public double DeltaTemperature { get => deltaTemperature; }
        public double DeltaSunDays { get => deltaSunDays; }
        public int DaysWithPersiptation { get => daysWithPersiptation; }
        public int DaysWithWeakWind { get => daysWithWeakWind; }
        public int DaysWithTemperatureUpperDelta { get => daysWithTemperatureUpperDelta; }
        public int DaysWithTemperatureLowerDelta { get => daysWithTemperatureLowerDelta; }
        public int MonthWithMaxPersiptation { get => monthWithMaxPersiptation; }
        public int MonthWithMaxWeakWindDays { get => monthWithMaxWeakWindDays; }


        public WeatherStatistic(List<List<Weather>> yearStatistic)
        {
            this.yearStatistic = yearStatistic;
            DeltaValues();
            TotalValues();
        }
        private void DeltaValues()
        {
            double sumTemperature = 0;
            int days = 0;
            int sunDays = 0;

            foreach (List<Weather> month in yearStatistic)
            {
                days += month.Count;
                foreach (Weather day in month)
                {
                    sumTemperature += day.DeltaTemperature;

                    if (day.Clouds <= 15)
                    {
                        sunDays++;
                    }
                }
            }            

            deltaTemperature =  sumTemperature / days;
            deltaSunDays = (double)sunDays / yearStatistic.Count; 
        }

        private void TotalValues()
        {
            daysWithPersiptation = 0;
            daysWithWeakWind = 0;
            daysWithTemperatureUpperDelta = 0;
            daysWithTemperatureLowerDelta = 0;

            int[] persiptation = new int[yearStatistic.Count];
            int[] weakWind = new int[yearStatistic.Count];

            int monthNum = 0;
            foreach (List<Weather> month in yearStatistic)
            {
                int weakWindCounter = 0;
                int persiptationSum = 0;
                foreach (Weather day in month)
                {
                    if (day.PrecipitationValue != 0)
                    {
                        daysWithPersiptation++;
                    }

                    if (day.WindPower <= 5)
                    {
                        daysWithWeakWind++;
                        weakWindCounter++;
                    }

                    if (day.DeltaTemperature > deltaTemperature)
                    {
                        daysWithTemperatureUpperDelta++;
                    }
                    else
                    {
                        daysWithTemperatureLowerDelta++;
                    }

                    persiptationSum += day.PrecipitationValue;
                }

                persiptation[monthNum] = persiptationSum;
                weakWind[monthNum] = weakWindCounter;
                monthNum++;
            }

            int maxPersiptation = 0;
            int maxWeakWind = 0;

            for (int i = 0; i < yearStatistic.Count; i++)
            {
                if (persiptation[i] > maxPersiptation)
                {
                    maxPersiptation = persiptation[i];
                    monthWithMaxPersiptation = i + 1;
                }

                if (weakWind[i] > maxWeakWind)
                {
                    maxWeakWind = weakWind[i];
                    monthWithMaxWeakWindDays = i + 1;
                }
            }
        }

        public void AddDay(int day, int month, Weather weather)
        {
            if (weather != null && month >= 1 && month <= 12 && day >= 1 && day <= 31)
            {
                yearStatistic[month - 1][day - 1] = weather;
                DeltaValues();
                TotalValues();
            }
        }

        public override string ToString()
        {
            return
                $"Среднегодовая температура: {Math.Round(deltaTemperature, 2)}\n" +
                $"Среднее количество солнечных дней в месяц: {Math.Round(deltaSunDays, 1)}\n" +
                $"Общее количество дней с осадками: {daysWithPersiptation}\n" +
                $"Общее количество дней в году со слабым ветром: {daysWithWeakWind}\n" +
                $"Общее количество дней с температурой выше среднегодовой температуры: {daysWithTemperatureUpperDelta}\n" +
                $"Общее количество дней с температурой ниже среднегодовой температуры: {daysWithTemperatureLowerDelta}\n" +
                $"Месяц с самым большим количеством осадков: {(Dictionary.Month)monthWithMaxPersiptation}\n" +
                $"Самый безветренный месяц: {(Dictionary.Month)monthWithMaxWeakWindDays}\n";
        }
    }
}
