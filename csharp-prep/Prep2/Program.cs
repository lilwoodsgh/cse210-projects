using System;
using System.Data.Common;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Kindly insert your Score out of 100: ");
        string answer = Console.ReadLine();
        int marks = int.Parse(answer);

        string grade = "";

        if (marks >= 90)
         {
            grade = "A";
         } 
         else if ( marks >= 80)
         {
            grade = " B ";
         }
         else if ( marks >= 70)
         {
            grade = "C";
         } else if ( marks >= 60)
         {
            grade = " D ";
         }
         else if ( marks >= 50)
         {
            grade = " E ";
         } 
         else 
         {
            grade = " F ";
         }
         
         Console.WriteLine($"Your Grade is: {grade}");

         if (marks >=70)
         {
            Console.WriteLine("Hurray You Passed!");
         }
         else
         {
            Console.WriteLine("Sorry, Better Luck Next Time.");
         }
         } 
}
