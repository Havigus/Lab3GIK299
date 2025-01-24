namespace Lab3GIK299;

public class TemperatureCalculator
{
    // A Random instance to generate random temperatures.
    private readonly Random _random = new Random();   

    // Array to hold temperatures.
    private readonly double[] _temperatures; 
    
    // Constructor initializes the array with random temperatures between 8.0 and 20.0.
    public TemperatureCalculator()
    {
        _temperatures = new double[31];
        for (int i = 0; i < _temperatures.Length; i++)
        {
            _temperatures[i] = 8.0 + _random.NextDouble() * (20.0 - 8.0);
        }
    }

    // Method to display temperatures for each day of May.
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
        }
    }

    // Method to calculate and display the average temperature of May.
    public void FindAverageTemperature()
    {
        double average = _temperatures.Average();
        Console.WriteLine("+------------------------------------------+");
        Console.WriteLine($"|The average temperature in May was {average:F1} \u00B0C|");
        Console.WriteLine("+------------------------------------------+");
    }

    // Method to find and display the highest temperature of May.
    public void FindMaxTemperature()
    {
        double max = _temperatures.Max();
        int maxIndex = Array.IndexOf(_temperatures, max);
        Console.WriteLine("The highest temperature in May was: ");
        Console.WriteLine($"May {maxIndex + 1} and the temperature was {max:F1} \u00B0C");
    }

    // Method to find and display the lowest temperature of May.
    public void FindMinTemperature()
    {
        double min = _temperatures.Min();
        int minIndex = Array.IndexOf(_temperatures, min);
        Console.WriteLine("The lowest temperature in May was: ");
        Console.WriteLine($"May {minIndex + 1} and the temperature was {min:F1} \u00B0C");
    }

    // Method to display the median temperature of May.
    public void DisplayMedianTemperature()
    {
        //NEW! copy and sort the array to get the right median by temp
        double[] copyArray = new double[_temperatures.Length];
        Array.Copy(_temperatures, copyArray, _temperatures.Length);
        Array.Sort(copyArray);
        int length = _temperatures.Length;
        if (length % 2 != 0)
        {
            // Odd number of elements: median is the middle value.
            int medianIndex = length / 2;
            Console.WriteLine($"The median temperature in May was {copyArray[medianIndex]:F1} \u00B0C");
        }
        else
        {
            // Even number of elements: median is the average of the two middle values.
            int medianIndex1 = length / 2 - 1;
            int medianIndex2 = length / 2;
            double averageMedian = (copyArray[medianIndex1] + copyArray[medianIndex2]) / 2;
            Console.WriteLine($"The median temperature in May was {averageMedian:F1} \u00B0C");
        }
    }

    // Method to sort and display the temperatures in ascending or descending order.
    public void SortTemperature(string arg)
    {
        double[] copyArray = new double[_temperatures.Length];
        Array.Copy(_temperatures, copyArray, _temperatures.Length);
        Array.Sort(copyArray);

        if (arg == "1")
        {
            Console.WriteLine("The temperatures in May in ascending order are:");
            for (int i = 0; i < copyArray.Length; i++)
            {
                Console.WriteLine($"{copyArray[i]:F1} \u00B0C");
            }
        }
        else
        {
            Array.Reverse(copyArray);
            Console.WriteLine("The temperatures in May in descending order are:");
            for (int i = 0; i < copyArray.Length; i++)
            {
                Console.WriteLine($"{copyArray[i]:F1} \u00B0C");
            }
        }
    }

    // Method to filter and display days with temperatures above a certain threshold.
    public void FilterTemperatureThreshold(double arg)
    {
        Console.WriteLine($"Days where the temperature in May was above {arg} were: ");
        for (int i = 0; i < _temperatures.Length; i++)
        {
            if (_temperatures[i] > arg)
            {
                Console.WriteLine($"May {i + 1} with a temperature of {_temperatures[i]:F1} \u00B0C");
            }
        }
    }

    // Method to search and display the temperature of a specific day and adjacent days.
    public void FilterTempreratureBySearch(int arg)
    {
        Console.WriteLine($"The temperature on May {arg} was {_temperatures[arg - 1]:F1} \u00B0C");
        if (arg > 1)
        {
            Console.WriteLine($"The day before, the temperature was {_temperatures[arg - 2]:F1} \u00B0C");
        }

        if (arg < _temperatures.Length)
        {
            Console.WriteLine($"The day after, the temperature was {_temperatures[arg]:F1} \u00B0C");
        }
    }

    
    //NEW! method to find the most common temperature in May
    //https://www.reddit.com/r/godot/comments/18anaxc/how_to_check_an_array_for_the_most_common_element/
    public void FindMostCommonTemperature()
    {
        //copys the array in to an new array
        double[] copyArray = new double[_temperatures.Length];
        Array.Copy(_temperatures, copyArray, _temperatures.Length);

        //loops through the array and rounds each element to 1 decimal for it to work
        for (int i = 0; i < _temperatures.Length; i++)
        {
            copyArray[i] = Math.Round(_temperatures[i], 1);
        }
        
        //create a new dict to keep track of counts where temp is key and count is value
        var counts = new Dictionary<double, int>();
        foreach (var temp in copyArray)
        {
            //if temp not in dict add it to dict 
            if(!counts.ContainsKey(temp))
                counts[temp] = 0;
            //else add to the count
            counts[temp]++;
        }
        
        //gets the highest count from the dict value
        var maxCount = counts.Values.Max();
        
        //filters the dict to only keys with the value is maxCount
        //then select the keys, order them and adds the to the list 
        var mostCommon = counts
            .Where(x => x.Value == maxCount)
            .Select(x => x.Key)
            .OrderBy(x => x)
            .ToList();
        
        //if only one temp is most common
        if (mostCommon.Count == 1)
        {
            Console.WriteLine($"The most common temperature in May was {mostCommon[0]:F1} \u00B0C. And occurred {maxCount} times.");
        }
        //if there are several temps 
        else
        {
            Console.WriteLine("The most common temperature in May were:");
            //loops through the list and prints them out
            foreach (var temp in mostCommon)
            {
                Console.WriteLine($" {temp:F1} \u00B0C");
            }

            Console.WriteLine($"And they occurred {maxCount} times each.");
        }
    }
    
    //OLD METHOD
    //Method to find the most common temperature. 
   /* public void FindMostCommonTemperature()
    {
        double[] copyArray = new double[_temperatures.Length];
        Array.Copy(_temperatures, copyArray, _temperatures.Length);
        //Inspired from StackOverflow, using LINQ to group the array by its values
        //then order the groups by the count of occurrences
        //then gets the first group, which will be the group with most occurrences
        double mode = copyArray
            .GroupBy(v => v)
            .OrderByDescending(g => g.Count())
            .First()
            .Key;
        Console.WriteLine($"The most common temperature in May was {mode:F1} \u00B0C");
    }*/
}

    

