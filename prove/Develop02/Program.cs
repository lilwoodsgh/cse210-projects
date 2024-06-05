using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Entry
    {
        public string Prompt { get; private set; }
        public string Response { get; private set; }
        public string Date { get; private set; }

        public Entry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Date}|{Prompt}|{Response}";
        }

        public static Entry FromString(string entryString)
        {
            string[] parts = entryString.Split(new string[] { "|" }, StringSplitOptions.None);
            if (parts.Length == 3)
            {
                return new Entry(parts[1], parts[2], parts[0]);
            }
            else
            {
                throw new FormatException("Invalid entry format.");
            }
        }
    }

    public class Journal
    {
        private List<Entry> entries;

        public Journal()
        {
            entries = new List<Entry>();
        }

        public void AddEntry(string prompt, string response)
        {
            entries.Add(new Entry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }

        public void DisplayEntries()
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                Console.WriteLine(new string('-', 20));
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine(entry.ToString());
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            entries.Clear();
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        entries.Add(Entry.FromString(line));
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            List<string> prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            while (true)
            {
                Console.WriteLine("1. Write new entries");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        foreach (var prompt in prompts)
                        {
                            Console.WriteLine(prompt);
                            string response = Console.ReadLine();
                            journal.AddEntry(prompt, response);
                        }
                        Console.WriteLine("All prompts have been answered and entries have been added to the journal. Thank you.");
                        break;
                    case "2":
                        journal.DisplayEntries();
                        Console.WriteLine("All journal entries have been displayed.");
                        break;
                    case "3":
                        Console.Write("Enter the filename to save: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveToFile(saveFilename);
                        Console.WriteLine($"Journal has been saved to {saveFilename}.");
                        break;
                    case "4":
                        Console.Write("Enter the filename to load: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadFromFile(loadFilename);
                        Console.WriteLine($"Journal has been loaded from {loadFilename}.");
                        break;
                    case "5":
                        Console.WriteLine("Thank you fro using our program");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}