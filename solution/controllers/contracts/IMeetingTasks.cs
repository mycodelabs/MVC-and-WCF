using controllers.Home;

namespace Presentation.contracts
{
    public interface IMeetingTasks
    {
        MeetingsPageViewModel GetAllMeetings();
    }
}