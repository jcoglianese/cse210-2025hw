class Goals
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool Complete { get; set; }

    public virtual void Display()
    {
        Console.Write("What is the name of your goal? ");
        Title = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        Description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        
        int points;
        while (!int.TryParse(Console.ReadLine(), out points))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }

        Points = points; 
    }

    public virtual bool IsComplete() => Complete;
    public virtual void Record() { }

    public virtual string ToFileString() => $"Goals:{Title}|{Description}|{Points}|{Complete}";

    public static Goals FromFileString(string data)
    {
        string[] parts = data.Split('|');
        string[] goalInfo = parts[0].Split(':');
        string goalType = goalInfo[0];
        string title = goalInfo[1];
        string description = parts[1];
        int points = int.Parse(parts[2]);

        return goalType switch
        {
            "Simple" => new Simple { Title = title, Description = description, Points = points, Complete = bool.Parse(parts[3]) },
            "Eternal" => new Eternal { Title = title, Description = description, Points = points },
            "Checklist" => new Checklist { Title = title, Description = description, Points = points, BonusPoints = int.Parse(parts[3]), DesiredAmount = int.Parse(parts[4]), AchievedAmount = int.Parse(parts[5]) },
            _ => null
        };
    }
}

