namespace Lab3GIK299;

public class TemperatureCalculator
{
    
    private readonly Random _random = new Random();   
    private readonly double[] _temperatures; 
    
    public TemperatureCalculator()
    {
        _temperatures = new double[31];
        for (int i = 0; i < _temperatures.Length; i++)
        {
            _temperatures[i] = 8.0 + _random.NextDouble() * (20.0 - 8.0);
        }
    }

    public void DisplayTempratureForEachDay()
    {
        Console.WriteLine("The temperature each day in May was:");
        Console.WriteLine("+----------------------+");
        Console.WriteLine("|Date    | Temperature |");
        Console.WriteLine("+----------------------+");
        for (int i = 0; i < _temperatures.Length; i++)
        {
            Console.WriteLine($"|May {i +1,2}  | {_temperatures[i],5:F1} \u00B0C    |");
            Console.WriteLine("+----------------------+");
            //Console.WriteLine($"The temprature for May {i +1} was {_temperatures[i]:F1} \u00B0C");
        }
    }

    public void FindAverageTemperature()
    {
        double average = _temperatures.Average();
        Console.WriteLine("+------------------------------------------+");
        Console.WriteLine($"|The average temperature in May was {average:F1} \u00B0C|");
        Console.WriteLine("+------------------------------------------+");
    }

    public void FindMaxTemperature()
    {
        double max = _temperatures.Max();
        int maxIndex = Array.IndexOf(_temperatures, max);
        Console.WriteLine($"The highest temperature in May was: ");
        Console.WriteLine($"May {maxIndex} and the temperature was {max:F1} \u00B0C");
    }

    public void FindMinTemperature()
    {
        double min = _temperatures.Min();
        int minIndex = Array.IndexOf(_temperatures, min);
        Console.WriteLine($"The lowest temperature in May was: ");
        Console.WriteLine($"May {minIndex} and the temperature was {min:F1} \u00B0C");
    }

    public void DisplayMedianTemperature()
    {
        int length = _temperatures.Length;
        if (length % 2 != 0)
        {
            int medianIndex = length / 2;
            Console.WriteLine($"The median temperature in May was {_temperatures[medianIndex]:F1} \u00B0C");
        }
        else
        {
            int medianIndex1 = length / 2 - 1;
            int medianIndex2 = length / 2;
            int averageMedian = Convert.ToInt32(_temperatures[medianIndex1] + _temperatures[medianIndex2] / 2);
            Console.WriteLine($"The median temperature in May was {_temperatures[averageMedian]:F1} \u00B0C");
        }
    }

    public void SortTemperature(string arg)
    {
        double[] copyArray = new double[_temperatures.Length];
        Array.Copy(_temperatures, copyArray, _temperatures.Length);
        Array.Sort(copyArray);
        if (arg == "1")
        {
            Console.WriteLine("The the tempratures in May in ascending order is:");
            for (int i = 0; i < copyArray.Length; i++)
            {
                Console.WriteLine($"{copyArray[i]:F1} \u00B0C");
            }
        }
        else
        {
            Array.Reverse(copyArray);
            Console.WriteLine("The the tempratures in May in decending order is:");
            for (int i = 0; i < copyArray.Length; i++)
            {
                Console.WriteLine($"{copyArray[i]:F1} \u00B0C");
            }
        }
    }

    public void FilterTemperatureThreshold(double arg)
    {
        Console.WriteLine($"Day´s where the temperature in May was above {arg} was: ");
        for (int i = 0; i < _temperatures.Length; i++)
        {
            if (arg <= _temperatures[i])
            {
                Console.WriteLine($"May {i +1} with an temperature of {_temperatures[i]:F1} \u00B0C");
            }
        }
    }

    public void FilterTempreratureBySearch(int arg)
    {
        Console.WriteLine($"The temperature May {arg} was {_temperatures[arg -1]:F1}");
        Console.WriteLine($"The day befor the temperature was {_temperatures[arg -2]:F1} \u00B0C");
        Console.WriteLine($"The day after the temperature was {_temperatures[arg]:F1} \u00B0C");
    }

    public void FindMostCommonTemperature()
    {
        double[] copyArray = new double[_temperatures.Length];
        Array.Copy(_temperatures, copyArray, _temperatures.Length);
        //Inspired from StackOverflow, using LINQ to group the array by its values
        //then order the groups by the count of occurrences
        //then gets the first group, which will be the group with most occurrences
        double mode = copyArray.GroupBy(v => v)
            .OrderByDescending(g => g.Count())
            .First()
            .Key;
        Console.WriteLine($"The most common temperature in May was {mode:F1} \u00B0C");
    }
}