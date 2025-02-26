using System;

class Program
{
    static string userChoice;
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to your Mindfulness Program!");

        do {
            Console.WriteLine("Menu Options:\n  1. Start breathing activity\n  2. Start reflecting activity\n  3. Start listing activity\n  4. Quit");
            Console.Write("Select a choice from the menu: ");
            userChoice = Console.ReadLine();
            switch (userChoice){
                case "1":
                    Console.Clear();
                    Breath breathing = new Breath();
                    breathing.StartActivity();
                    int bduration = breathing.SetDuration();
                    breathing.BreathLoop(bduration);
                    breathing.EndActivity();
                    break;
                case "2":
                    Console.Clear();
                    Reflection reflecting = new Reflection();
                    reflecting.StartActivity();
                    int rduration = reflecting.SetDuration();
                    reflecting.ReflectionLoop(rduration);
                    reflecting.EndActivity();
                    break;
                case "3":
                    Console.Clear();
                    Listing listing = new Listing();
                    listing.StartActivity();
                    int lduration = listing.SetDuration();
                    listing.ListingLoop(lduration);
                    listing.EndActivity();
                    break;
            }

        } while (userChoice != "4");
        
    }
}