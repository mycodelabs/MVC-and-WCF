using clienttasks.mappers.contracts;
using clienttasks.meetingsservice;
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
            var meetings = this.meetingsService.GetAllMeetings();
            return meetingsPageViewModelMapper.MapFrom(meetings);
        }
    }
}
