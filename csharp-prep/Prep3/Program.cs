using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            // Generate a random number from 1 to 100
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            bool guessedCorrectly = false;
            int guesses = 0;

            // Game loop that keeps requesting guesses until correct guess is entered
            while (!guessedCorrectly)
            {
                // Request guess from user
                Console.Write("Kindly guess a number: ");
                int guess = int.Parse(Console.ReadLine());
                guesses++;

                // Check if the guess matches the magic number
                if (guess < magicNumber)
                {
                    Console.WriteLine("Very low, Try a Higher Number");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Very High, Try a Lower Number");
                }
                else
                {
                    Console.WriteLine("Congratulations!! You guessed it!");
                    guessedCorrectly = true;
                }
            }

            Console.WriteLine("It took you " + guesses + " guesses to get it Right.");

            // Ask if user would like to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainResponse = Console.ReadLine();

            if (playAgainResponse.ToLower() != "yes")
            {
                playAgain = false;
            }
        }
    }
}
