using System.Runtime.Serialization;

namespace services.datamodel
{
    [DataContract]
    public class MeetingEventsData
    {
        [DataMember]
        public string EventName { get; set; }

        [DataMember]
        public string StartsAt { get; set; }
    }
}