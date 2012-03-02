using clienttasks.meetingsservice;
using Presentation.contracts;
using controllers.Home;

namespace clienttasks.mappers.contracts
{
    public interface IMeetingsPageViewModelMapper
    {
        MeetingsPageViewModel MapFrom(MeetingData[] meetingsData);
    }
}