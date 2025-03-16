using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goals> _goalsList = new List<Goals>();
    public int TotalPoints { get; private set; } = 0; // Expose TotalPoints as a property

    public void CreateGoal()
    {
        Console.WriteLine("\nChoose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal title: ");
        string title = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for completing this goal: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points value. Goal creation failed.");
            return;
        }

        switch (choice)
        {
            case "1":
                _goalsList.Add(new Simple { Title = title, Description = description, Points = points });
                break;

            case "2":
                _goalsList.Add(new Eternal { Title = title, Description = description, Points = points });
                break;

            case "3":
                Console.Write("Enter bonus points: ");
                if (!int.TryParse(Console.ReadLine(), out int bonusPoints))
                {
                    Console.WriteLine("Invalid bonus points. Goal creation failed.");
                    return;
                }

                Console.Write("Enter the required amount to complete this goal: ");
                if (!int.TryParse(Console.ReadLine(), out int desiredAmount))
                {
                    Console.WriteLine("Invalid amount. Goal creation failed.");
                    return;
                }

                _goalsList.Add(new Checklist
                {
                    Title = title,
                    Description = description,
                    Points = points,
                    BonusPoints = bonusPoints,
                    DesiredAmount = desiredAmount,
                    AchievedAmount = 0 // Default to zero at creation
                });
                break;

            default:
                Console.WriteLine("Invalid selection.");
                return;
        }

        Console.WriteLine("Goal successfully created!");
    }

    public void ListGoals()
    {
        if (_goalsList.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        int index = 1;
        foreach (Goals goal in _goalsList)
        {
            string status = goal.IsComplete() ? "[X]" : "[ ]";
            Console.Write($"{index}. {status} {goal.Title} ({goal.Description})");

            if (goal is Checklist checklistGoal)
            {
                Console.WriteLine($" -- Completed: {checklistGoal.AchievedAmount}/{checklistGoal.DesiredAmount}");
            }
            else
            {
                Console.WriteLine();
            }

            index++;
        }
    }

    public void RecordEvent()
    {
        if (_goalsList.Count == 0)
        {
            Console.WriteLine("No goals available to record progress.");
            return;
        }

        Console.WriteLine("\nSelect a goal to record progress:");
        for (int i = 0; i < _goalsList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goalsList[i].Title}");
        }

        Console.Write("Enter the number of the goal: ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goalsList.Count)
        {
            Goals selectedGoal = _goalsList[goalIndex - 1];
            selectedGoal.Record();
            TotalPoints += selectedGoal.Points;
            Console.WriteLine($"Progress recorded! You earned {selectedGoal.Points} points.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goals goal in _goalsList)
            {
                if (goal is Simple simpleGoal)
                {
                    writer.WriteLine($"SimpleGoal:{simpleGoal.Title}|{simpleGoal.Description}|{simpleGoal.Points}|{simpleGoal.Complete}");
                }
                else if (goal is Eternal eternalGoal)
                {
                    writer.WriteLine($"EternalGoal:{eternalGoal.Title}|{eternalGoal.Description}|{eternalGoal.Points}");
                }
                else if (goal is Checklist checklistGoal)
                {
                    writer.WriteLine($"ChecklistGoal:{checklistGoal.Title}|{checklistGoal.Description}|{checklistGoal.Points}|{checklistGoal.BonusPoints}|{checklistGoal.DesiredAmount}|{checklistGoal.AchievedAmount}");
                }
            }
        }

        Console.WriteLine($"Goals saved to {filename} successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }

        _goalsList.Clear(); // Clear existing goals before loading new ones

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string goalType = parts[0].Split(':')[0];
                string title = parts[0].Split(':')[1];
                string description = parts[1];

                if (!int.TryParse(parts[2], out int points))
                {
                    Console.WriteLine($"Error loading goal: {title} (Invalid points value)");
                    continue;
                }

                if (goalType == "SimpleGoal")
                {
                    if (bool.TryParse(parts[3], out bool isComplete))
                    {
                        _goalsList.Add(new Simple
                        {
                            Title = title,
                            Description = description,
                            Points = points,
                            Complete = isComplete
                        });
                    }
                    else
                    {
                        Console.WriteLine($"Error loading SimpleGoal: {title} (Invalid completion status)");
                    }
                }
                else if (goalType == "EternalGoal")
                {
                    _goalsList.Add(new Eternal
                    {
                        Title = title,
                        Description = description,
                        Points = points
                    });
                }
                else if (goalType == "ChecklistGoal")
                {
                    if (parts.Length < 6 ||
                        !int.TryParse(parts[3], out int bonusPoints) ||
                        !int.TryParse(parts[4], out int desiredAmount) ||
                        !int.TryParse(parts[5], out int achievedAmount))
                    {
                        Console.WriteLine($"Error loading ChecklistGoal: {title} (Invalid numeric values)");
                        continue;
                    }

                    _goalsList.Add(new Checklist
                    {
                        Title = title,
                        Description = description,
                        Points = points,
                        BonusPoints = bonusPoints,
                        DesiredAmount = desiredAmount,
                        AchievedAmount = achievedAmount
                    });
                }
            }
        }

        Console.WriteLine($"Goals loaded from {filename} successfully!");
    }
}
