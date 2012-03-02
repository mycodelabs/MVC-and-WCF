using System.Collections.Generic;
using domain;
using services.datamodel;

namespace services.mappers.contracts
{
    public interface IMeetingDataContractMapper
    {
        IEnumerable<MeetingData> MapFrom(IEnumerable<Meeting> meetings);
    }
}
