using System;
using System.Collections.Generic;
using System.Threading;

class Reflection : Activities
{
    private Dictionary<string, Queue<string>> _themedQuestions;

    public Reflection()
    {
        _activityName = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _prompts = new List<string>
        {
            "Think of a time when you overcame a challenge.",
            "Reflect on a moment when you helped someone in need.",
            "Recall a time when you set a goal and achieved it.",
            "Think about a difficult decision you made.",
            "Remember a time when you felt truly happy."
        };

        _themedQuestions = new Dictionary<string, Queue<string>>();
        _random = new Random();

        InitializeQuestions();
    }

    private void InitializeQuestions()
    {
        Dictionary<string, List<string>> questionsList = new Dictionary<string, List<string>>
        {
            { "Think of a time when you overcame a challenge.", 
                new List<string> { "What obstacles did you face?", "How did you persevere?", "What strengths did you rely on?", 
                                   "Who supported you during this time?", "How did overcoming this challenge change you?" }
            },
            { "Reflect on a moment when you helped someone in need.", 
                new List<string> { "How did your actions impact the person?", "What motivated you to help?", "How did you feel afterward?",
                                   "Would you do anything differently?", "How did this experience shape your values?" }
            },
            { "Recall a time when you set a goal and achieved it.", 
                new List<string> { "What steps did you take?", "What challenges did you encounter?", "How did achieving this goal change you?",
                                   "How did you stay motivated?", "What advice would you give to someone pursuing a similar goal?" }
            },
            { "Think about a difficult decision you made.",
                new List<string> { "What made the decision difficult?", "What were the possible outcomes?", "What did you learn from the decision?",
                                   "Did you seek advice before deciding?", "Would you make the same decision again?" }
            },
            { "Remember a time when you felt truly happy.",
                new List<string> { "What made that moment special?", "Who was with you?", "How can you create similar experiences in the future?",
                                   "What emotions did you feel in that moment?", "What factors contributed to your happiness?" }
            }
        };

        foreach (var entry in questionsList)
        {
            _themedQuestions[entry.Key] = ShuffleQueue(entry.Value);
        }
    }

    public void ReflectionLoop(int duration)
    {
        Console.WriteLine("\nConsider the following prompt:\n");
        string prompt = ChoosePrompt();
        Console.WriteLine($"----- {prompt} -----");
        Console.Write("\nWhen you have something in mind, press Enter to continue: ");
        Console.ReadLine();

        Console.WriteLine("\nNow, reflect on the following questions:\n");

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string question = ChooseQuestion(prompt);
            Console.WriteLine($"\n-> {question}");
            for (int elapsedTime = 0; elapsedTime < duration; elapsedTime += 20){
                PauseAnimation();
            }
             
        }

        Console.WriteLine("\nGreat job reflecting! Take a moment to appreciate your thoughts.\n");
    }

    private string ChooseQuestion(string prompt)
    {
        if (!_themedQuestions.ContainsKey(prompt) || _themedQuestions[prompt].Count == 0)
        {
            Console.WriteLine("\nYou've gone through all the questions! Refreshing with a new set...");
            _themedQuestions[prompt] = ShuffleQueue(GetQuestionList(prompt));
        }
        return _themedQuestions[prompt].Dequeue();
    }

    private Queue<string> ShuffleQueue(List<string> questions)
    {
        List<string> shuffledList = new List<string>(questions);
        int count = shuffledList.Count;
        while (count > 1)
        {
            count--;
            int k = _random.Next(count + 1);
            (shuffledList[k], shuffledList[count]) = (shuffledList[count], shuffledList[k]);
        }
        return new Queue<string>(shuffledList);
    }

    private List<string> GetQuestionList(string prompt)
    {
        return _themedQuestions.ContainsKey(prompt) 
            ? new List<string>(_themedQuestions[prompt]) 
            : new List<string>();
    }

}
