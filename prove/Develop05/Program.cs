using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string userChoice;
    static GoalManager goalManager = new GoalManager();

    static void Main(string[] args)
    {
        do
        {
            Console.WriteLine($"\nTotal Points: {goalManager.TotalPoints}");
            Console.WriteLine("\nMenu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit");
            Console.Write("Select a choice from the menu: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    goalManager.CreateGoal();
                    break;
                case "2":
                    goalManager.ListGoals();
                    break;
                case "3":
                    goalManager.SaveGoals();
                    break;
                case "4":
                    goalManager.LoadGoals();
                    break;
                case "5":
                    goalManager.RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        } while (userChoice != "6");
    }
}