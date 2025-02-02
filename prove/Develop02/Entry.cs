public class Entry
{
    public string _Date {get; set;}
    public string _Prompt{get; set;}
    public string _Text {get; set;}
    public int _birds {get; set;}


    private static readonly string[] prompts = 
    {
        "What was the best part of your day?",
        "Describe a moment that made you smile today.",
        "What is something you're grateful for today?",
        "What is one thing you learned today?",
        "What is a goal you're working on?",
        "What is a funny story from today?"
    };

    public Entry(string prompt, string text, int birds)
    {
        _Date = DateTime.Now.ToShortDateString();
        _Prompt = prompt;
        _Text = text;
        _birds = birds;

    }

    public override string ToString()
    {
        return $"{_Date}: Prompt: {_Prompt}\nResponse: {_Text}\nBird Count: {_birds}\n";
    }

    public static string GetRandomPrompt()
    {
        Random rand = new Random();
        return prompts[rand.Next(prompts.Length)];
    }

}

