using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

class Activities
{
    protected string _description;
    private int _duration;
    protected string _activityName;

    protected List<string> _prompts;
    protected Random _random;

    // Start Activity will show standard welcome message for each activity
    public void StartActivity(){
        Console.WriteLine($"Welcome to the {_activityName}.\n\n{_description}\n");
    }

    // Set duration will have the user input how long they want to do the activity
    public int SetDuration(){
        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out _duration) && _duration > 0)
        {
        Console.Clear();
        // Write get read. Did it here so it wouldn't do it everytime the pause animation was run
        
        Console.WriteLine("Get ready...");
        PauseAnimation();
        return _duration;
        }
        else
        {
        Console.WriteLine("Invalid input. Please enter a positive number.");
        return SetDuration(); // Ask again if the input is invalid
        }
    }

    // Pause animation runs a little animation while the user waits
    public void PauseAnimation(){
        for (int i = 0; i < 3; i++){
            Console.Write("|");
            Thread.Sleep(500);
            Console.Write("\b \b"); 
            Console.Write("/");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(500);
            Console.Write("\b \b");
        }

    }

    // Choose prompt will choose a prompt for the reflection and listing class but not the breath class
    protected string ChoosePrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    // End Activity will display a standardized message for each activity
    public void EndActivity(){
        Console.WriteLine("Well Done!!");
        PauseAnimation();
        Console.WriteLine("\n");
        Console.WriteLine($"You have completed another {_duration} seconds of the {_activityName}");
        PauseAnimation();
        Console.Clear();

    }
}