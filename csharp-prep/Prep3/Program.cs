using System;

class Program
{
    static void Main(string[] args)
    {
        // user guessing a specified number
        Console.WriteLine("Kindly Guess the Magic Number:");
        int MagicNumber = int.Parse(Console.ReadLine());
        int Guess = 20;

        while (Guess != MagicNumber)
        {
            Console.Write("Kindly Guess Again:");
            Guess = int.Parse(Console.ReadLine());

            if (MagicNumber > Guess)
            {
                Console.WriteLine("Too High, Guess a Lower number");
            }
            else if (MagicNumber < Guess)
            {
                Console.WriteLine("Too Low, Guess a Higher Number");
            }
             else if (MagicNumber == Guess)
            {
                Console.WriteLine("Too Low, Guess a Higher Number");
            } 
        }
        Console.WriteLine("Congratulations,You Won!!");
        
    }
}