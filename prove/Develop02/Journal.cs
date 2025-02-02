using System;
using System.Collections.Generic;
using System.IO;
public class Journal

{
    static int _birds;
    private List<Entry> entryList = new List<Entry>();
    

    public void WriteNewEntry()
    {
        string randomPrompt = Entry.GetRandomPrompt(); // Get a random prompt from Entry class
        Console.WriteLine($"\n{randomPrompt}");
        Console.Write("Your response: ");
        string entryText = Console.ReadLine();
        Console.Write("Number of birds you saw today: ");
        string number = Console.ReadLine();
        if (int.TryParse(number, out int birdCount))
        {
            AddEntry(randomPrompt, entryText, birdCount);
        }
        else
        {
            Console.WriteLine("Invalid number. Entry not added.");
        }
        
    }
    public int GetTotalBirds()
    {
        int totalBirds = 0;
        foreach (Entry entry in entryList)
        {
            totalBirds += entry._birds;
        }
        return totalBirds;
    }

    public void AddEntry(string prompt, string text, int birds)
    {
        entryList.Add(new Entry(prompt, text, birds));
        Console.WriteLine("Entry added!\n");
    }

    public void DisplayJournal()
    {
        if (entryList.Count == 0)
        {
            Console.WriteLine("No journal entries found.\n");
            return;
        }

        Console.WriteLine("\nYour Journal Entries:");
        foreach (Entry entry in entryList)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        if (entryList.Count == 0)
        {
            Console.WriteLine("No entries to save.\n");
            return;
        }
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Entry entry in entryList)
                {
                    writer.WriteLine($"Date: {entry._Date}|{entry._Prompt}|{entry._Text}|{entry._birds}");
                }
            }
            Console.WriteLine($"Journal saved to {fileName}!\n");
        }
        catch (Exception)
        {
            Console.WriteLine("Error saving journal: ");
        }
    }

     public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("The specified file does not exist.\n");
            return;
        }

        try
        {
            Console.WriteLine("Loading Journal...");

            entryList.Clear();
            foreach (string line in File.ReadAllLines(fileName))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4 && int.TryParse(parts[3], out int birdsCount))
                {
                    entryList.Add(new Entry(parts[1], parts[2], birdsCount) { _Date = parts[0] });
                }
                else
                {
                    Console.WriteLine("Skipped invalid entry: " + line);
                }
                    
                
            }

            Console.WriteLine($"Loaded {entryList.Count} entries from {fileName}.\n");
        }
        catch
        {
            Console.WriteLine("An error occurred while loading the journal.");
        }
    }
}