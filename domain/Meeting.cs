using System.Collections.Generic;

namespace domain
{
    public class Meeting : Entity
    {
        public Meeting()
        {
            this.Events = new List<Event>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public List<Event> Events { get; set; }
    }

    public class Event
    {
        public string EventName { get; set; }

        public string StartTime { get; set; }
    }
}