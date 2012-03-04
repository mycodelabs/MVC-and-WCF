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
        private readonly IMeetingEventsDataMapper meetingEventsDataMapper;


        public MeetingsService(IMeetingRepository meetingRepository, IMeetingDataContractMapper meetingDataContractMapper, IMeetingEventsDataMapper meetingEventsDataMapper)
        {
            this.meetingRepository = meetingRepository;
            this.meetingDataContractMapper = meetingDataContractMapper;
            this.meetingEventsDataMapper = meetingEventsDataMapper;
        }

        public IEnumerable<MeetingData> GetAllMeetings()
        {
            var meetings = this.meetingRepository.GetAll();
            return this.meetingDataContractMapper.MapFrom(meetings);
        }

        public IEnumerable<MeetingEventsData> GetAllEventsInMeeting(string meetingId)
        {
            var meeting = this.meetingRepository.GetById(meetingId);
            return this.meetingEventsDataMapper.MapFrom(meeting);
        }
    }
}
