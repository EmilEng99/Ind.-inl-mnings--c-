using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Statistics1
{

    public static class Statistics
    {
        public static int[] source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"));

        public static dynamic DescriptiveStatistics()
        {
            Dictionary<string, dynamic> StatisticsList = new Dictionary<string, dynamic>()
            {
                { "Maximum", Maximum() },
                { "Minimum", Minimum() },
                { "Medelvärde", Mean() },
                { "Median", Median() },
                { "Typvärde", Mode() },
                { "Variationsbredd", Range() },
                { "Standardavvikelse", StandardDeviation() }

            };

            string output =
                $"Maximum: {StatisticsList["Maximum"]}\n" +
                $"Minimum: {StatisticsList["Minimum"]}\n" +
                $"Medelvärde: {StatisticsList["Medelvärde"]}\n" +
                $"Median: {StatisticsList["Median"]}\n" +
                $"Typvärde: {StatisticsList["Typvärde"]}\n" +
                $"Variationsbredd: {StatisticsList["Variationsbredd"]}\n" +
                $"Standardavvikelse: {StatisticsList["Standardavvikelse"]}";

            return output;
        }

        public static int Maximum()
        {
            Array.Sort(Statistics.source);
            Array.Reverse(source);
            int result = source[0];
            return result;
        }

        public static int Minimum()
        {
            Array.Sort(Statistics.source);
            int result = source[0];
            return result;
        }

        public static double Mean()
        {
            Array.Sort(Statistics.source);
            double total = 0;

            for (int i = 0; i < source.LongLength; i++)
            {
                total += source[i];
            }
            return total / source.LongLength;
        }

        public static double Median()
        {
            Array.Sort(source);
            int size = source.Length;
            int mid = size / 2;
            int dbl = source[mid];
            return dbl;
        }

        public static int Mode()
        {
            Array.Sort(source);

            int currentNum = source[0]; //Startnumret för arrayen
            int currentCount = 1; //För att räkna hur många gånger numret har funnits
            int maxCount = 1; //Hålla reda på det maximala antalet gånger vilket tal som helst har setts till 
            int mode = currentNum; //Lagra numret som förekommer flest gånger

            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] == currentNum) //Jämför numret den kontrollerar just nu med det föregående numret
                {
                    currentCount++; //Om 'true' ökas parametern för hur många gånger numret har funnits
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;//Om currentCount blir större än maxCount uppdateras maxCount
                        mode = currentNum; //Och mode blir det nya currentNum
                    }
                }
                else //Om talet varierar från det föregåendet talet uppdateras inte currentCount 
                {
                    if (currentCount > maxCount)//Men talet kontrolleras ändå mot maxCount och uppdaterar vid behov
                    {
                        maxCount = currentCount;
                        mode = currentNum;
                    }
                    currentNum = source[i]; //Uppdaterar currentNum till det nya talet som förekommer mest
                    currentCount = 1;//Och återställer currentCount till 1 igen
                }

            }

            return mode;
        }

        public static int Range()
        {
            Array.Sort(Statistics.source);
            int min = source[0];
            int max = source[0];

            for (int i = 0; i < source.Length; i++)
                if (source[i] > max)
                    max = source[i];

            int range = max - min;
            return range;
        }

        public static double StandardDeviation()
        {

            double average = source.Average();
            double sumOfSquaresOfDifferences = source.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);

            double round = Math.Round(sd, 1);
            return round;
        }

    }
}
