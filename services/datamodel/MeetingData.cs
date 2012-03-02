using System.Runtime.Serialization;

namespace services.datamodel
{
    [DataContract]
    public class MeetingData
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}