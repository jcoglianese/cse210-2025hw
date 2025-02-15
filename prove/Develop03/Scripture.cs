using System;
using System.Collections.Generic;
using System.IO;

public class Scripture{
   bool _hiddenAll;

   public Reference _Reference {get; set;}
   public string Text{get; set;}
   public List<string> wordList;
   private static string filePath = "scripturelist.txt";
   public Scripture(Reference reference, string text){
        _Reference = reference;
        Text = text;
   }

    public override string ToString(){
        return $"{_Reference} \"{Text}\"";
    }

    public static Scripture FromString(string line){
        if (string.IsNullOrWhiteSpace(line))
            throw new ArgumentException("Scripture line cannot be empty.");
        string[] parts = line.Split('|');
        if (parts.Length < 2)
            throw new FormatException("Invalid scripture format. Expected format: 'Reference|Text'");
        Reference reference = Reference.FromString(parts[0]);
        return new Scripture(reference, parts[1]);
    }

    public static void SaveScriptures(List<Scripture> scriptures){
        using(StreamWriter writer = new StreamWriter(filePath)){
            foreach (Scripture scripture in scriptures){
                writer.WriteLine($"{scripture._Reference}|{scripture.Text}");
            }
        }
        Console.WriteLine("Scripture saved!\n");
    }

    public static List<Scripture> LoadScriptures(){
        List<Scripture> scriptures = new List<Scripture>();
        if (File.Exists(filePath)){
            Console.WriteLine("Attempting to load scriptures...");
            Console.WriteLine($"File Path: {filePath}");

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines){
                try{
                    scriptures.Add(Scripture.FromString(line));
                }
                catch (Exception ex){
                    Console.WriteLine($"Skipping invalid line: {line}. Error: {ex.Message}");
                }
            }
            Console.WriteLine($"Loaded {scriptures.Count} scriptures from file.");
        }
        else
        {
            Console.WriteLine("No saved scriptures found.");
        }
        return scriptures;
    }

    public void Display(){

   }

   public string HideWords(){
        Console.WriteLine("Memorize this scripture:");
        if (wordList == null || wordList.Count == 0){
            wordList = Word.SplitText(Text);
        }
        Random rand = new Random();
        int wordsToHide = 3;
        int hiddenCount = 0;
        while(hiddenCount < wordsToHide){
            int randomIndex = rand.Next(wordList.Count);

            if (wordList[randomIndex] != new string('_', wordList[randomIndex].Length)){
                wordList[randomIndex] = Word.HideWord(wordList[randomIndex]);
                hiddenCount++;
            }
            if (wordList.All(w => w == new string('_', w.Length))){
                _hiddenAll = true;
                break;
            }
        }
        
        return $"{_Reference} \"{string.Join(" ", wordList)}\"";
   }

    public bool AllWordsHidden(){
        return wordList != null && wordList.All(w => w == new string('_', w.Length));
    }

    public void Reset(){
        wordList = Word.SplitText(Text);
        _hiddenAll = false;
    }


}