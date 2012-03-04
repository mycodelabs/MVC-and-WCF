using System.Collections.Generic;
using System.ServiceModel;
using services.datamodel;

namespace services
{
    [ServiceContract]
    public interface IMeetingsService
    {
        [OperationContract]
        IEnumerable<MeetingData> GetAllMeetings();

        [OperationContract]
        IEnumerable<MeetingEventsData> GetAllEventsInMeeting(string theMeetingId);
    }
}
