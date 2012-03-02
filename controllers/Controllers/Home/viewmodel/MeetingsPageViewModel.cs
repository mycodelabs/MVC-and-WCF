using System.Collections.Generic;
using System.Web.Mvc;

namespace controllers.Home
{
    public class MeetingsPageViewModel
    {
        public MeetingsPageViewModel()
        {
            Meetings = new List<SelectListItem>();
        }
        public IList<SelectListItem> Meetings { get; set; }
    }
}