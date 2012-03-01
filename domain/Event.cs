using System;

namespace domain
{
   [Serializable]
    public class Event : Entity
    {
        public string StartsAt { get; set; }
    }
}