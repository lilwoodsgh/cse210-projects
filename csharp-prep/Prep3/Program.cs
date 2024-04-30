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

            // Game loop
            while (!guessedCorrectly)
            {
                // Ask the user for their guess
                Console.Write("What is your guess? ");
                int guess = int.Parse(Console.ReadLine());
                guesses++;

                // Check if the guess matches the magic number
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    guessedCorrectly = true;
                }
            }

            Console.WriteLine("It took you " + guesses + " guesses.");

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainResponse = Console.ReadLine();

            if (playAgainResponse.ToLower() != "yes")
            {
                playAgain = false;
            }
        }
    }
}
