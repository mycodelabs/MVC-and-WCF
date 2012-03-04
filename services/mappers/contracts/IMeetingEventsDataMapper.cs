using System;
using System.Collections.Generic;
using domain;
using services.datamodel;

namespace services.mappers.contracts
{
    public interface IMeetingEventsDataMapper
    {
        IEnumerable<MeetingEventsData> MapFrom(Meeting meeting);
    }
}