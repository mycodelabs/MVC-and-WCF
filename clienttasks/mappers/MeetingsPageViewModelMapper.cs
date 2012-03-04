using System;
using System.Collections.Generic;
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
            return MapFrom(meetingsData, null);
        }

        public MeetingsPageViewModel MapFrom(MeetingData[] meetingsData, MeetingEventsData[] theEventsData)
        {
            var pageViewModel = new MeetingsPageViewModel();
            foreach (var meetingData in meetingsData)
            {
                pageViewModel.Meetings.Add(new SelectListItem() {Text = meetingData.Name, Value = meetingData.Id});
            }

            if (theEventsData !=null)
            {
                foreach (var meetingEventsData in theEventsData)
                {
                   pageViewModel.Events.Add(new Event(){ EventName = meetingEventsData.EventName, StartsAt = meetingEventsData.StartsAt});
                }
            }
            return pageViewModel;
        }
    }
}