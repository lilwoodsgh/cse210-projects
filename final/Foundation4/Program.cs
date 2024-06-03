using System;
using System.Collections.Generic;

namespace FitnessCenterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating activities
            Activity running = new Running("03 Nov 2022", 30, 3.0);
            Activity cycling = new Cycling("03 Nov 2022", 45, 18.0);
            Activity swimming = new Swimming("03 Nov 2022", 25, 20);

            // Listing of activities
            List<Activity> activities = new List<Activity> { running, cycling, swimming };

            // Displaying summaries for each activity
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
                Console.WriteLine();
            }
        }
    }

    public abstract class Activity
    {
        private string date;
        private int minutes;

        public Activity(string date, int minutes)
        {
            this.date = date;
            this.minutes = minutes;
        }

        public string Date
        {
            get { return date; }
        }

        public int Minutes
        {
            get { return minutes; }
        }

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            return $"{Date} {GetType().Name} ({Minutes} min): Distance {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
        }
    }

    public class Running : Activity
    {
        private double distance;

        public Running(string date, int minutes, double distance) 
            : base(date, minutes)
        {
            this.distance = distance;
        }

        public override double GetDistance()
        {
            return distance;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / GetDistance();
        }
    }

    public class Cycling : Activity
    {
        private double speed;

        public Cycling(string date, int minutes, double speed) 
            : base(date, minutes)
        {
            this.speed = speed;
        }

        public override double GetDistance()
        {
            return (speed / 60) * Minutes;
        }

        public override double GetSpeed()
        {
            return speed;
        }

        public override double GetPace()
        {
            return 60 / speed;
        }
    }

    public class Swimming : Activity
    {
        private int laps;

        public Swimming(string date, int minutes, int laps) 
            : base(date, minutes)
        {
            this.laps = laps;
        }

        public override double GetDistance()
        {
            return laps * 50 / 1000.0;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / GetDistance();
        }

        public override string GetSummary()
        {
            return $"{Date} {GetType().Name} ({Minutes} min): Distance {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km, Laps: {laps}";
        }
    }
}
