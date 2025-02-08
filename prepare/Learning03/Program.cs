using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Hello Learning03 World!");
        Fraction f1 = new Fraction(); // 1/1
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(3,4);
        Console.WriteLine($"{f1.GetFractionString()}");
        Console.WriteLine($"{f1.GetDecimalValue()}");
        Console.WriteLine($"{f2.GetFractionString()}");
        Console.WriteLine($"{f2.GetDecimalValue()}");
        Console.WriteLine($"{f3.GetFractionString()}");
        Console.WriteLine($"{f3.GetDecimalValue()}");
        f3.SetTop(1);
        f3.SetBottom(3);
        Console.WriteLine($"{f3.GetFractionString()}");
        Console.WriteLine($"{f3.GetDecimalValue()}");

    }

}