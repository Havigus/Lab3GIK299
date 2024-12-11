using System.Threading.Channels;

namespace Lab3GIK299;

class Program
{
    static void Main(string[] args)
    {
        TemperatureCalculator temperatureCalculator = new TemperatureCalculator();
        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine(@"+------------------------------------------------------------------------------------------+
|            WELCOME TO THE TEMPERATURECALCULATOR v1.0 (https://t.ly/vDr_z)                |
|						      by Viktor and Elvira                 |
+------------------------------------------------------------------------------------------+");
            Console.WriteLine(@"+------------------------------------------------------------------------------------------+
|Please select an option by entering the corresponding number from the list below:         |
|1.I want a list of temperature data for each day in May.                                  |
|2.I want to calculate the average temperature for May.                                    |
|3. I want to find the day with the highest temperature and its value.                     |
|4. I want to find the day with the lowest temperature and its value.                      |
|5. I want to calculate the median temperature for May.                                    |
|6. I want to sort the temperatures in ascending or descending order.                      |
|7. I want to filter and display only the days with temperatures above a certain threshold.|
|8. I want to enter a specific day in May and see its temperature,                         |
|   along with the temperatures from the previous and following days.                      |
|9. I want to identify the most common temperature in May.                                 |
|H. I want help!                                                                           | 
+------------------------------------------------------------------------------------------+");
            string userMenuInput = Console.ReadKey().KeyChar.ToString().ToLower();
            Console.WriteLine();

            switch (userMenuInput)
            {
                case "1":
                    temperatureCalculator.DisplayTempratureForEachDay();
                    break;
                case "2":
                    temperatureCalculator.FindAverageTemperature();
                    break;
                case "3":
                    temperatureCalculator.FindMaxTemperature();
                    break;
                case "4":
                    temperatureCalculator.FindMinTemperature();
                    break;
                case "5":
                    temperatureCalculator.DisplayMedianTemperature();
                    break;
                case "6":
                    bool keepRunning6 = true;
                    while (keepRunning6)
                    {
                        Console.WriteLine("Do you want to sort its temperatures in 1.ascending or 2.descending order?");
                        string userInput = Console.ReadKey().KeyChar.ToString();
                        if (userInput is "1" or "2")
                        {
                            temperatureCalculator.SortTemperature(userInput);
                            keepRunning6 = false;
                        }
                        
                    }
                    break;
                case "7":
                    Console.WriteLine("What threshold do you want to set?");
                    double userThresholdInput = double.Parse(Console.ReadLine() ?? string.Empty);
                    temperatureCalculator.FilterTemperatureThreshold(userThresholdInput);
                    break;
                case "8":
                    Console.WriteLine("Which day of the month do you want to see? Enter a number.");
                    int userDayNumberInput = Convert.ToInt32(Console.ReadLine());
                    temperatureCalculator.FilterTempreratureBySearch(userDayNumberInput);
                    break;
                case "9":
                    temperatureCalculator.FindMostCommonTemperature();
                    break;
                case "h":
                    SuperSecretFunction();
                    break;
                default:
                    Console.WriteLine("!!!Please enter a valid option!!!");
                    Thread.Sleep(2000);
                    break;
                    
                    
                    
            }

            Console.WriteLine();
            Console.WriteLine("Do you want to exit the program? (Y/N) ");
            string userInputContinue = Console.ReadKey().KeyChar.ToString().ToUpper();
            if (userInputContinue == "Y")
            {
                keepRunning = false;
            }
            
            
        }
        
        
        
        
    }

    static void SuperSecretFunction()
    {
        string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley";

        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                { FileName = url, UseShellExecute = true });
        }
        catch (Exception e)
        {
            Console.WriteLine("Sorry, I couldn't help you.");
        }
    }
}