using System;
using System.Collections.Generic;

namespace ModasSeedData
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Time Start
            DateTime start = DateTime.Now;

            // Location list
            List<Location> Locations = new List<Location>(){
                // Added locations
                new Location { LocationId = 1, Name = "School"},
                new Location { LocationId = 2, Name = "Church"},
                new Location { LocationId = 3, Name = "Walmart"},
                new Location { LocationId = 4, Name = "Walgreens"},

            };
            // current date/time for date stamp
            DateTime localDate = DateTime.Now;
            // backdate it to 6months
            DateTime eventDate = localDate.AddMonths(-6);
            // using random to generate
            Random rnd = new Random();
            // event list
            List<Event> events = new List<Event>();
            // loop through 6 months back to date
            while (eventDate < localDate)
            {
                // For each day, generate between 0-5 events
                int num = rnd.Next(0, 6);
                // For each event on a given day, generate a random time (hours, minutes, seconds)  and a random location (using the List<Location>)
                SortedList<DateTime, Event> dailyEvents = new SortedList<DateTime, Event>();
                // for each event, loop to generate times for event
                for (int i = 0; i < num; i++)
                {
                    // randomly choose btw 0 and 23 for hours
                    int hour = rnd.Next(0, 24);
                    // randomly choose btw 0 and 59 for minute of the day
                    int minute = rnd.Next(0, 60);
                    // randomly btw 0 and 59 for seconds
                    int second = rnd.Next(0, 60);
                    // randomly choose location using the added location(s)
                    int loc = rnd.Next(0, Locations.Count);
                    // create event date and time
                    DateTime d = new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, hour, minute, second);
                    // create event using location and time/date
                    Event e = new Event { Flagged = false, Location = Locations[loc], LocationId = Locations[loc].LocationId, TimeStamp = d };
                    // add daily event to the list
                    dailyEvents.Add(d, e);
                }

                // loop for daily events
                foreach (var de in dailyEvents)
                {
                    // add daily event to Events
                    events.Add(de.Value);
                }
                // add 1 day to eventDate
                eventDate = eventDate.AddDays(1);
            }
            // loop through Events
            foreach (Event e in events)
            {
                // display event
                Console.WriteLine($"{e.TimeStamp}, {e.Location.Name}");
            }

           
        }
    }
}
