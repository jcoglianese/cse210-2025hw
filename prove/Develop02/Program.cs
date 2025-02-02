using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static string option;
    static Journal myJournal = new Journal();
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to Your Journal!");
        // Display menu options
        do{
            Console.WriteLine("\n1). Write a new entry\n2). Display the Journal\n3). Save the journal\n4). Load journal\n5). Quit");
            
            // Prompt user to pick option
            Console.Write("Please enter an option: ");
            string option = Console.ReadLine();
            
            
            // Use switch statement to know which option was picked and then call the class or function needed
            switch (option) // Write a new entry
            {
                case "1":
                    myJournal.WriteNewEntry();
                    break;
        
            
                case "2": // Display the Journal
                    myJournal.DisplayJournal();
                    Console.WriteLine($"Total Bird count: {myJournal.GetTotalBirds()}\n");
                    break;
            
                case "3": // Save the journal
                    Console.Write("Enter the file name to save your journal: ");
                    string saveFileName = Console.ReadLine();
                    myJournal.SaveToFile(saveFileName);
                    break;
                
            
                case "4": // Load journal
                    Console.Write("Enter the file name to load your journal: ");
                    string loadFileName = Console.ReadLine();
                    myJournal.LoadFromFile(loadFileName);
                    break;
            
            
                case "5":
                    Console.WriteLine("Goodbye");
                    return;
                    

                default:
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 5.");
                    break;

            }
        } while (option != "5");
    
    }
}