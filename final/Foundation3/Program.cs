using System;
using System.Collections.Generic;

namespace EventPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses for the specific events
            Address address1 = new Address("5767 Proton St", "Bortianor", "GA", "Ghana");
            Address address2 = new Address("Nummo Laweh St", "Korleygono", "GA", "Ghana");
            Address address3 = new Address("Kojo Oppong St", "Kumasi", "KSI", "Ghana");

            // Creating events
            Event lecture = new Lecture("Find a better job Conference", "A lecture on how to apply for good jobs", "2024-06-15", "10:00 AM", address1, "Mr Bright", 120);
            Event reception = new Reception("Launch of Sports Awards Event", "An evening of networking and cocktails", "2024-07-20", "8:00 PM", address2, "rsvp@littlerocksc.com");
            Event outdoorGathering = new OutdoorGathering("Community Sanitation Awareness Day", "An Educative and fun-filled outdoor activity", "2024-08-10", "11:00 AM", address3, "Sunny");

            // Listing of events
            List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

            // Generate and display marketing messages for each event
            foreach (var ev in events)
            {
                Console.WriteLine("Standard Details:");
                Console.WriteLine(ev.GetStandardDetails());
                Console.WriteLine();

                Console.WriteLine("Full Details:");
                Console.WriteLine(ev.GetFullDetails());
                Console.WriteLine();

                Console.WriteLine("Short Description:");
                Console.WriteLine(ev.GetShortDescription());
                Console.WriteLine();
            }
        }
    }

    public class Address
    {
        private string street;
        private string city;
        private string stateOrProvince;
        private string country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            this.street = street;
            this.city = city;
            this.stateOrProvince = stateOrProvince;
            this.country = country;
        }

        public string GetFullAddress()
        {
            return $"{street}, {city}, {stateOrProvince}, {country}";
        }
    }

    public abstract class Event
    {
        private string title;
        private string description;
        private string date;
        private string time;
        private Address address;

        public Event(string title, string description, string date, string time, Address address)
        {
            this.title = title;
            this.description = description;
            this.date = date;
            this.time = time;
            this.address = address;
        }

        public string GetStandardDetails()
        {
            return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address.GetFullAddress()}";
        }

        public abstract string GetFullDetails();

        public abstract string GetShortDescription();
    }

    public class Lecture : Event
    {
        private string speaker;
        private int capacity;

        public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            this.speaker = speaker;
            this.capacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
        }

        public override string GetShortDescription()
        {
            return $"Type: Lecture\nTitle: {base.GetStandardDetails().Split('\n')[0].Replace("Title: ", "")}\nDate: {base.GetStandardDetails().Split('\n')[2].Replace("Date: ", "")}";
        }
    }

    public class Reception : Event
    {
        private string rsvpEmail;

        public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
            : base(title, description, date, time, address)
        {
            this.rsvpEmail = rsvpEmail;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
        }

        public override string GetShortDescription()
        {
            return $"Type: Reception\nTitle: {base.GetStandardDetails().Split('\n')[0].Replace("Title: ", "")}\nDate: {base.GetStandardDetails().Split('\n')[2].Replace("Date: ", "")}";
        }
    }

    public class OutdoorGathering : Event
    {
        private string weather;

        public OutdoorGathering(string title, string description, string date, string time, Address address, string weather)
            : base(title, description, date, time, address)
        {
            this.weather = weather;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {weather}";
        }

        public override string GetShortDescription()
        {
            return $"Type: Outdoor Gathering\nTitle: {base.GetStandardDetails().Split('\n')[0].Replace("Title: ", "")}\nDate: {base.GetStandardDetails().Split('\n')[2].Replace("Date: ", "")}";
        }
    }
}
