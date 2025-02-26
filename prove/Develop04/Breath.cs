using System;

class Breath : Activities
{

    public Breath(){
        _activityName = "Breathing Activity";
        _description = "This activity will help you relax by walking through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }
    
    public void BreathLoop(int duration){
        for (int i = 0; i < (duration / 10); i++){
            Console.WriteLine("\n");

            Console.Write("Breath in...4");
            Thread.Sleep(1000);
            Console.Write("\b4\b3"); 
            Thread.Sleep(1000);
            Console.Write("\b3\b2");
            Thread.Sleep(1000);
            Console.Write("\b2\b1");
            Thread.Sleep(1000);
            Console.Write("\b1\b ");

            Console.Write("\nNow breath out...6");
            Thread.Sleep(1000);
            Console.Write("\b6\b5"); 
            Thread.Sleep(1000);
            Console.Write("\b5\b4");
            Thread.Sleep(1000);
            Console.Write("\b4\b3");
            Thread.Sleep(1000);
            Console.Write("\b3\b2");
            Thread.Sleep(1000);
            Console.Write("\b2\b1");
            Thread.Sleep(1000);
            Console.Write("\b1\b ");
        }
        Console.WriteLine("\n");
    }
}