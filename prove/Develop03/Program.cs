using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizationApp
{
    public class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public override string ToString()
        {
            return IsHidden ? "_" : Text;
        }
    }

    public class Reference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int StartVerse { get; private set; }
        public int? EndVerse { get; private set; }

        public Reference(string book, int chapter, int startVerse, int? endVerse = null)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            return EndVerse.HasValue 
                ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}" 
                : $"{Book} {Chapter}:{StartVerse}";
        }
    }

    public class Scripture
    {
        public Reference ScriptureReference { get; private set; }
        public List<Word> Words { get; private set; }

        public Scripture(Reference reference, string text)
        {
            ScriptureReference = reference;
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void HideRandomWords(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                var visibleWords = Words.Where(word => !word.IsHidden).ToList();
                if (visibleWords.Count == 0) break;

                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
            }
        }

        public bool AllWordsHidden()
        {
            return Words.All(word => word.IsHidden);
        }

        public override string ToString()
        {
            return $"{ScriptureReference}\n{string.Join(" ", Words)}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Scripture> scriptures = new List<Scripture>
            {
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
                new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."),
                new Scripture(new Reference("Psalm", 23, 1, 4), "The Lord is my shepherd, I lack nothing. He makes me lie down in green pastures, he leads me beside quiet waters, he refreshes my soul. He guides me along the right paths for his name’s sake. Even though I walk through the darkest valley, I will fear no evil, for you are with me; your rod and your staff, they comfort me."),
                new Scripture(new Reference("Romans", 8, 28), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose.")
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select a scripture to memorize:");
                for (int i = 0; i < scriptures.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {scriptures[i].ScriptureReference}");
                }
                Console.Write("Enter the number of the scripture or type 'quit' to exit: ");
                string input = Console.ReadLine();

                if (input?.ToLower() == "quit")
                {
                    break;
                }

                if (int.TryParse(input, out int scriptureIndex) && scriptureIndex >= 1 && scriptureIndex <= scriptures.Count)
                {
                    Scripture selectedScripture = scriptures[scriptureIndex - 1];
                    MemorizeScripture(selectedScripture);
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
        }

        static void MemorizeScripture(Scripture scripture)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture);
                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden. The program will now end.");
                    break;
                }
                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input?.ToLower() == "quit")
                {
                    break;
                }
                scripture.HideRandomWords(3);
            }
        }
    }
}