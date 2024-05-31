using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EternalQuest
{
    // Base Goal class
    public abstract class Goal
    {
        public string Name { get; set; }
        public int Points { get; protected set; }
        public bool IsCompleted { get; protected set; }

        public Goal(string name, int points)
        {
            Name = name;
            Points = points;
            IsCompleted = false;
        }

        public abstract int RecordEvent();
        public abstract string DisplayStatus();
    }

    // SimpleGoal class
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name, points) { }

        public override int RecordEvent()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                return Points;
            }
            return 0;
        }

        public override string DisplayStatus()
        {
            return IsCompleted ? $"[X] {Name}" : $"[ ] {Name}";
        }
    }

    // EternalGoal class
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points) { }

        public override int RecordEvent()
        {
            return Points;
        }

        public override string DisplayStatus()
        {
            return $"[∞] {Name}";
        }
    }

    // ChecklistGoal class
    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; }
        public int CurrentCount { get; private set; }
        public int BonusPoints { get; }

        public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) 
            : base(name, points)
        {
            TargetCount = targetCount;
            BonusPoints = bonusPoints;
            CurrentCount = 0;
        }

        public override int RecordEvent()
        {
            if (CurrentCount < TargetCount)
            {
                CurrentCount++;
                if (CurrentCount == TargetCount)
                {
                    IsCompleted = true;
                    return Points + BonusPoints;
                }
                return Points;
            }
            return 0;
        }

        public override string DisplayStatus()
        {
            return IsCompleted ? $"[X] {Name} (Completed {CurrentCount}/{TargetCount})" 
                               : $"[ ] {Name} (Completed {CurrentCount}/{TargetCount})";
        }
    }

    // Main Program class
    class Program
    {
        private static List<Goal> goals = new List<Goal>();
        private static int score = 0;

        static void Main(string[] args)
        {
            LoadGoals();
            while (true)
            {
                Console.Clear();
                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        RecordEvent();
                        break;
                    case "3":
                        DisplayGoals();
                        break;
                    case "4":
                        SaveGoals();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. Save and exit");
            Console.WriteLine($"Your current score is: {score}");
            Console.Write("Enter your choice: ");
        }

        private static void CreateGoal()
        {
            Console.WriteLine("Choose a goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            string choice = Console.ReadLine();
            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter points for the goal: ");
            int points = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, points));
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, points));
                    break;
                case "3":
                    Console.Write("Enter target count for the goal: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points for completing the goal: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal not created.");
                    break;
            }
        }

        private static void RecordEvent()
        {
            DisplayGoals();
            Console.Write("Enter the number of the goal to record an event: ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;

            if (goalIndex >= 0 && goalIndex < goals.Count)
            {
                int points = goals[goalIndex].RecordEvent();
                score += points;
                Console.WriteLine($"Event recorded! You earned {points} points.");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
            Console.ReadLine();
        }

        private static void DisplayGoals()
        {
            Console.WriteLine("Your Goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].DisplayStatus()}");
            }
            Console.ReadLine();
        }

        private static void SaveGoals()
        {
            var saveData = new { Goals = goals, Score = score };
            string json = JsonSerializer.Serialize(saveData);
            File.WriteAllText("goals.json", json);
            Console.WriteLine("Goals saved successfully.");
        }

        private static void LoadGoals()
        {
            if (File.Exists("goals.json"))
            {
                string json = File.ReadAllText("goals.json");
                var loadData = JsonSerializer.Deserialize<SaveData>(json);
                goals = loadData.Goals;
                score = loadData.Score;
            }
        }

        private class SaveData
        {
            public List<Goal> Goals { get; set; }
            public int Score { get; set; }
        }
    }
}
