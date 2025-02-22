using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment assignment1 = new MathAssignment("Samuel Bennett", "Multiplicaton", "7.3", "8-19");
        Console.WriteLine($"\n{assignment1.GetSummary()}");
        Console.WriteLine($"{assignment1.GetHomeworkList()}\n");

        WritingAssignment assignment2 = new WritingAssignment("Mary Walters", "European History", "The Cause of World War II");
        Console.WriteLine($"{assignment2.GetSummary()}");
        Console.WriteLine($"{assignment2.GetWritingInformation()}\n");
    }
}