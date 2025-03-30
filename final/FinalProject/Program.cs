using System;

class Program
{
    static void Main(string[] args)
    {
        Area yourArea = new Area();
        Console.Write("Which area would you like advice about?");
        yourArea.SetLocation(Console.ReadLine());
        Console.Write("How many acres do you have? ");
        yourArea.SetAcres(Console.ReadLine());
        Console.Write("What crop do you have (corn, potatos, or wheat)? ");
        yourArea.SetCrop(Console.ReadLine());
        
    }
}