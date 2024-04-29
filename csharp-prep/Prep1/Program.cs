using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Kindly Input Your Firstname:");
        string fname = Console.ReadLine();

        Console.Write("Kindly Input Your Lastname:");
        string lname = Console.ReadLine();

        Console.WriteLine($"Your name is {fname} {lname}.");
    }
}