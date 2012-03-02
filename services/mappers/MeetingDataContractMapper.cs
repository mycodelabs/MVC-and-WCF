using System.Collections.Generic;
using System.Linq;
using domain;
using services.datamodel;
using services.mappers.contracts;

namespace services.mappers
{
    public class MeetingDataContractMapper : IMeetingDataContractMapper
    {
        public IEnumerable<MeetingData> MapFrom(IEnumerable<Meeting> meetings)
        {
            var meetingsData = meetings.Select(meeting => new MeetingData() {Id = meeting.Id, Name = meeting.Name}).ToList();
            return meetingsData;
        }
    }
}