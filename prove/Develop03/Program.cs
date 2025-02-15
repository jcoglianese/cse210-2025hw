using System;
using System.Runtime.InteropServices;

class Program
{
    static string userChoice;
    static List<Scripture> scriptureList = new List<Scripture>();
    //static string filePath = "scripturelist.txt";

    static void Main(string[] args)
    {
        scriptureList = Scripture.LoadScriptures();
        
        
        Console.WriteLine("\nWelcome to the Scripture Memorizer");

        do {
            Console.WriteLine("1). Memorize Scripture\n2). Add Scripture to list\n3). Remove Scripture\n4). See List\n5). Quit");
            Console.Write("Please enter an option: ");
            userChoice = Console.ReadLine();

            switch (userChoice){
                case "1":
                    if (scriptureList.Count > 0){
                        Random rand = new Random();
                        int index = rand.Next(scriptureList.Count);
                        Scripture selectedScripture = scriptureList[index];
                        Console.Clear();
                        Console.WriteLine($"Memorize this scripture:\n{scriptureList[index]}");
                        while (true){
                            Console.Write("\nPress ENTER to hide words or type 'quit' to exit: ");
                            string input = Console.ReadLine();
                            if (input.ToLower() == "quit"){
                                break;
                            }
                            Console.Clear();
                            string hiddenText = selectedScripture.HideWords();
                            Console.WriteLine(hiddenText);

                            if (selectedScripture.AllWordsHidden()){
                                Console.WriteLine("\nAll words have been hidden. Returning to main menu...");
                                selectedScripture.Reset();
                                break;
                            }
                        }
                        
                    }
                    else{
                        Console.WriteLine("No scriptures in the list to memorize.\n");
                    }
                    break;

                case "2": // Add a scripture to the list
                    Console.Write("Enter the book name: ");
                    string book = Console.ReadLine();
                    Console.Write("Enter the chapter number: ");
                    int chapter = int.Parse(Console.ReadLine());
                    Console.Write("Enter the starting verse: ");
                    int verseStart = int.Parse(Console.ReadLine());
                    Console.Write("Enter the ending verse (or press 'Enter' if it's a single verse): ");
                    string verseEndInput = Console.ReadLine();
                    int? verseEnd = string.IsNullOrWhiteSpace(verseEndInput) ? (int?)null : int.Parse(verseEndInput);
                    Console.Write("Enter the scripture text: ");
                    string text = Console.ReadLine();

                    Scripture newScripture = new Scripture(new Reference(book, chapter, verseStart, verseEnd), text);
                    scriptureList.Add(newScripture);
                    Console.WriteLine("Scripture added successfully!\n");
                break;

                case "3": // Remove a scripture from the list
                    Console.Write("Enter the book and chapter to remove (e.g., John 3:16): ");
                    string removeInput = Console.ReadLine();
                    Scripture toRemove = scriptureList.Find(s => s._Reference.ToString().StartsWith(removeInput));

                    if (toRemove != null)
                    {
                        scriptureList.Remove(toRemove);
                        Console.WriteLine("Scripture removed successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("Scripture not found.\n");
                    }
                break;

                case "4": // Show a list of scriptures
                    if (scriptureList.Count == 0){
                        Console.WriteLine("No scriptures added yet.\n");
                    }
                    else{
                        Console.WriteLine("\nList of Scriptures:\n");
                        foreach (Scripture script in scriptureList)
                        {
                            Console.WriteLine($"- {script}\n");
                        }
                    }
                break;

                case "5": // End the program and save list
                    Scripture.SaveScriptures(scriptureList);
                    Console.WriteLine("Goodbye");
                    return;

                default: // Let the user know they entered an invalid response
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 5.");
                    break;

            }

        } while (userChoice != "5");
    }
}