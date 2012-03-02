using System.Web.Mvc;
using controllers.Controllers.Home.viewmodel;
using Presentation.contracts;

namespace controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IMeetingTasks meetingTasks;

        public HomeController(IMeetingTasks meetingTasks)
        {
            this.meetingTasks = meetingTasks;
        }

        public ActionResult Index()
        {
            var pageViewModel = this.meetingTasks.GetAllMeetings();
            return View(pageViewModel);
        }

        [HttpPost]
        public ActionResult Index(MeetingFormViewModel formViewModel)
        {
             var pageViewModel = this.meetingTasks.GetAllMeetings();
            return View(pageViewModel);
        }
    }
}