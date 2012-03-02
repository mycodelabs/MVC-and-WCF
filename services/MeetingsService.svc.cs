using System;
using System.Collections.Generic;
using contracts;
using domain;
using services.datamodel;
using services.mappers.contracts;

namespace services 
{
    public class MeetingsService : IMeetingsService
    {
        private readonly IMeetingRepository meetingRepository;
        private readonly IMeetingDataContractMapper meetingDataContractMapper;

        public MeetingsService(IMeetingRepository meetingRepository, IMeetingDataContractMapper meetingDataContractMapper)
        {
            this.meetingRepository = meetingRepository;
            this.meetingDataContractMapper = meetingDataContractMapper;
        }

        public IEnumerable<MeetingData> GetAllMeetings()
        {
            var meetings = this.meetingRepository.GetAll();
            return this.meetingDataContractMapper.MapFrom(meetings);
        }
    }
}
