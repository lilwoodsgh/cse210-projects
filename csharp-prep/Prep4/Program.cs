using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // creating initial list variable
        List<int> numbers = new List<int>();
       // prompting user to input list of numbers
        Console.WriteLine("Please Enter a list of numbers, type 0 when finished.");

        int input;
        do
        {
            Console.Write("Please Enter number. Hit enter to input next number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }

        // list loop
        } while (input != 0);
       
        //finding sum

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine("The sum is: " + sum);
        
        // finding average

        double average = (double)sum / numbers.Count;
        Console.WriteLine("The average is: " + average);
        
        // finding the highest number amongst the listed.
        int max = numbers.Count > 0 ? numbers[0] : 0;
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine("The Highest number in your list is: " + max);
    }
}
