using System;

class Program
{
    static int response;
    static void Main(string[] args)
    {
        
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,100);
        do
        {
            Console.Write("What is your guess? ");
            string userGuess = Console.ReadLine();
            response = int.Parse(userGuess);
            if (response > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (response < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (response == magicNumber)
            {
                Console.WriteLine("You guessed it!");
            }
        } while (response != magicNumber);

    }
}