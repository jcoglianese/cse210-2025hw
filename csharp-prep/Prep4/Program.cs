using System;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

class Program
{
    static int number;
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();
        Console.WriteLine("Enter a list of numbers type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);
            if (number != 0)
            {
                numberList.Add(number);
            }
        } while (number != 0);

        int numberSum = numberList.Sum();
        double numberAverage = numberList.Average();
        int largeNumber = numberList.Max();
        Console.WriteLine($"The sum is: {numberSum} ");
        Console.WriteLine($"The average is: {numberAverage}");
        Console.WriteLine($"The largest number is: {largeNumber}");

    }
}