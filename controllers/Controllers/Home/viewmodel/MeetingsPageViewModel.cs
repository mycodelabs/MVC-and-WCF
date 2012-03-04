using System.Collections.Generic;
using System.Web.Mvc;

namespace controllers.Home
{
    public class MeetingsPageViewModel
    {
        public MeetingsPageViewModel()
        {
            Meetings = new List<SelectListItem>();
            Events = new List<Event>();
        }
        public IList<SelectListItem> Meetings { get; set; }

        public IList<Event> Events { get; set; }
    }
}