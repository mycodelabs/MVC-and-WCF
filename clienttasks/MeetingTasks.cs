using System;
using clienttasks.mappers.contracts;
using clienttasks.meetingsservice;
using controllers.Controllers.Home.viewmodel;
using Presentation.contracts;
using controllers.Home;

namespace clienttasks
{
    public class MeetingTasks : IMeetingTasks
    {
        private readonly IMeetingsService meetingsService;
        private readonly IMeetingsPageViewModelMapper meetingsPageViewModelMapper;

        public MeetingTasks(IMeetingsService meetingsService, IMeetingsPageViewModelMapper meetingsPageViewModelMapper)
        {
            this.meetingsService = meetingsService;
            this.meetingsPageViewModelMapper = meetingsPageViewModelMapper;
        }

        public MeetingsPageViewModel GetAllMeetings()
        {
            return meetingsPageViewModelMapper.MapFrom(this.GetMeetings());
        }

        public MeetingsPageViewModel GetAllEventsInMeeting(MeetingFormViewModel theFormViewModel)
        {
            var events = this.meetingsService.GetAllEventsInMeeting(theFormViewModel.Meetings);
            return meetingsPageViewModelMapper.MapFrom(this.GetMeetings(), events);
        }

        private MeetingData[] GetMeetings()
        {
            return this.meetingsService.GetAllMeetings();
        }
    }
}
