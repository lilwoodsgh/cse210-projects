using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, MindfulnessActivity> activities = new Dictionary<string, MindfulnessActivity>
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectionActivity() },
            { "3", new ListingActivity() },
            { "4", new GratitudeActivity() },
            { "5", new VisualizationActivity() }
        };

        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Visualization Activity");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine();

            if (choice == "6")
            {
                break;
            }

            if (activities.ContainsKey(choice))
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                if (int.TryParse(Console.ReadLine(), out int duration))
                {
                    activities[choice].StartActivity(duration);
                }
                else
                {
                    Console.WriteLine("Invalid duration. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose a valid activity.");
            }
        }
    }
}

abstract class MindfulnessActivity
{
    protected string Name { get; }
    protected string Description { get; }
    protected int Duration { get; set; }

    public MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity(int duration)
    {
        Duration = duration;
        Console.WriteLine($"\nStarting {Name} Activity...");
        Console.WriteLine(Description);
        Console.WriteLine($"Duration: {Duration} seconds\n");

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

        PerformActivity();

        Console.WriteLine("\nGreat job! You've completed the activity.");
        Console.WriteLine($"Activity: {Name} | Duration: {Duration} seconds");
        ShowSpinner(3);
    }

    protected abstract void PerformActivity();

    protected void ShowSpinner(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    protected override void PerformActivity()
    {
        Console.WriteLine("Breathe in...");
        ShowSpinner(Duration / 2);

        Console.WriteLine("Breathe out...");
        ShowSpinner(Duration / 2);
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Length)]);
        ShowSpinner(5);
        Console.WriteLine("Start reflecting...");

        foreach (string question in Questions)
        {
            Console.WriteLine(question);
            ShowSpinner(5);
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Length)]);
        ShowSpinner(5);
        Console.WriteLine("Start listing...");

        Console.WriteLine("Enter as many items as you can:");
        for (int i = 1; i <= Duration; i++)
        {
            Console.Write($"{i}. ");
            Console.ReadLine();
        }

        Console.WriteLine($"\nYou listed {Duration} items.");
    }
}

class GratitudeActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Think of three things you're grateful for right now.",
        "Reflect on someone who has helped you recently. What are you grateful for about them?",
        "Consider a challenge you've faced recently. What positive outcomes or lessons can you be grateful for?"
    };

    public GratitudeActivity() : base("Gratitude", "This activity will help you cultivate gratitude by focusing on things you're thankful for.") { }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Length)]);
        ShowSpinner(5);
        Console.WriteLine("Start reflecting...");
        ShowSpinner(Duration);
    }
}

class VisualizationActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Close your eyes and visualize a peaceful place you'd like to be right now.",
        "Imagine yourself accomplishing a goal you've set for yourself. How does it feel?",
        "Visualize yourself overcoming a challenge you're currently facing. Picture the steps you'll take to succeed."
    };

    public VisualizationActivity() : base("Visualization", "This activity will guide you through visualization exercises to promote relaxation and positive thinking.") { }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Length)]);
        ShowSpinner(5);
        Console.WriteLine("Start visualizing...");
        ShowSpinner(Duration);
    }
}
