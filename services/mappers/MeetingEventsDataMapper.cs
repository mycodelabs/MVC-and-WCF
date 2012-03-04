using System.Collections.Generic;
using System.Linq;
using domain;
using services.datamodel;
using services.mappers.contracts;

namespace services.mappers
{
    public class MeetingEventsDataMapper : IMeetingEventsDataMapper
    {
        public IEnumerable<MeetingEventsData> MapFrom(Meeting meeting)
        {
            var meetingEventsData = meeting.Events.Select(meetingEvent => new MeetingEventsData()
                                                                              {
                                                                                  EventName = meetingEvent.Name, 
                                                                                  StartsAt = meetingEvent.StartsAt
                                                                              }).ToList();
            return meetingEventsData;
        }
    }
}