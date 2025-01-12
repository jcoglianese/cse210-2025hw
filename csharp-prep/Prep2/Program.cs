using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        if (grade >= 90)
        {
            Console.WriteLine("Your grade is A");
        }
        else if (grade >= 80)
        {
            Console.WriteLine("Your grade is B");
        }
        else if (grade >= 70)
        {
            Console.WriteLine("Your grade is C");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("Your grade is D");
        }
        else if (grade < 60)
        {
            Console.WriteLine("Your grade is F");
        }
        else
        {
            Console.WriteLine("Invaild Response");
        }
    }
}