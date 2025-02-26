using System;

class Program
{
    static string userChoice;
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to your Mindfulness Program!");

        do {
            // Display menu and get user input
            Console.WriteLine("Menu Options:\n  1. Start breathing activity\n  2. Start reflecting activity\n  3. Start listing activity\n  4. Quit");
            Console.Write("Select a choice from the menu: ");
            userChoice = Console.ReadLine();

            //Create different cases based on the user's choice
            switch (userChoice){
                // Case 1 = Start breathing activity
                case "1":
                    Console.Clear();
                    Breath breathing = new Breath();
                    breathing.StartActivity();
                    int bduration = breathing.SetDuration();
                    breathing.BreathLoop(bduration);
                    breathing.EndActivity();
                    break;
                // Case 2 = Start reflecting activity
                case "2":
                    Console.Clear();
                    Reflection reflecting = new Reflection();
                    reflecting.StartActivity();
                    int rduration = reflecting.SetDuration();
                    reflecting.ReflectionLoop(rduration);
                    reflecting.EndActivity();
                    break;
                // Case 3 = Start listing activity
                case "3":
                    Console.Clear();
                    Listing listing = new Listing();
                    listing.StartActivity();
                    int lduration = listing.SetDuration();
                    listing.ListingLoop(lduration);
                    listing.EndActivity();
                    break;
            }

        // Input 4 will quit the program
        } while (userChoice != "4");
        
    }
}