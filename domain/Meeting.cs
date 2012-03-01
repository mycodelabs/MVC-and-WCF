using System;
using System.Collections.Generic;

namespace domain
{
    [Serializable]
    public class Meeting : Entity
    {
        public Meeting()
        {
            this.Events = new List<Event>();
        }

        public List<Event> Events { get; set; }
    }
}