using controllers.Controllers.Home.viewmodel;
using controllers.Home;

namespace Presentation.contracts
{
    public interface IMeetingTasks
    {
        MeetingsPageViewModel GetAllMeetings();
        MeetingsPageViewModel GetAllEventsInMeeting(MeetingFormViewModel theFormViewModel);
    }
}