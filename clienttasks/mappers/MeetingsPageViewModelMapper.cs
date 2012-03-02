using System.Web.Mvc;
using clienttasks.mappers.contracts;
using clienttasks.meetingsservice;
using Presentation.contracts;
using controllers.Home;

namespace clienttasks.mappers
{
    public class MeetingsPageViewModelMapper : IMeetingsPageViewModelMapper
    {
        public MeetingsPageViewModel MapFrom(MeetingData[] meetingsData)
        {
            var pageViewModel = new MeetingsPageViewModel();
            foreach (var meetingData in meetingsData)
            {
                pageViewModel.Meetings.Add(new SelectListItem() {Text = meetingData.Name, Value = meetingData.Id});
            }

            return pageViewModel;
        }
    }
}