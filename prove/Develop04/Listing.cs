using System;

class Listing : Activities
{
    

    public Listing(){
        _activityName = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _prompts = new List<string>
        {
            "When have you felt the Holy Ghost this month?",
            "What are you grateful for?",
            "How have you seen God's hand in your life?",
            "What is going well in your life?",
            "What has made you happy this month?",
            "What are some tender mercies this month?"
        };
        _random = new Random();
    }

    public void ListingLoop(int duration){
    Console.WriteLine("\nList as many responses you can to the following prompt: ");
    string prompt = ChoosePrompt();
    Console.WriteLine($"----- {prompt} -----");
    Console.WriteLine("You may begin in:");
    
    // Countdown
    for (int i = 5; i > 0; i--) {
        Console.Write($"\r>{i} ");  // \r moves cursor to beginning, overwriting previous output
        Thread.Sleep(1000);
    }
    Console.Write("\r     \r"); // Clears countdown before first input
    
    DateTime endTime = DateTime.Now.AddSeconds(duration);
    int inputCount = 0;
    while (DateTime.Now < endTime){
        Console.Write("> ");  // Keep prompt consistent
        Console.ReadLine();
        inputCount += 1;
    }
    Console.WriteLine($"You listed {inputCount} items!");
}

}