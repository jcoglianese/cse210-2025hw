using System;

class Program
{
    static int favoriteNumber;
    static string name;
    static int squared;
    static void Main(string[] args)
    {
        DisplayWelcome();
        PromptUserName();
        PromptUserNumber();
        SquareNumber(favoriteNumber);
        DisplayResult(name, squared);

    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        name = Console.ReadLine();
        return name;

    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string userInput = Console.ReadLine();
        favoriteNumber = int.Parse(userInput);
        return favoriteNumber;


    }

    static int SquareNumber(int favoriteNumber)
    {
           squared = favoriteNumber * favoriteNumber;
           return squared;
    }
    static void DisplayResult(string name, int favoriteNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squared}");      
    }
}