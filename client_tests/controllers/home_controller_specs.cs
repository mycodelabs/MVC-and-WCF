using System.Collections.Generic;
using System.Web.Mvc;
using controllers.Controllers.Home.viewmodel;
using controllers.Home;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using Presentation.contracts;

namespace client_tests.controllers
{
    [Subject("Home Controller specs")]
    public class home_controller_specs
    {
        public abstract class home_controller_concern : Observes<HomeController>
        {
            protected static IMeetingTasks the_client_tasks;

            protected static MeetingsPageViewModel the_page_view_model;

            private Establish c = () =>
                                      {
                                          the_client_tasks = depends.on<IMeetingTasks>();
                                          the_page_view_model = new MeetingsPageViewModel
                                                                    {
                                                                        Meetings =
                                                                            new List<SelectListItem>
                                                                                {new SelectListItem()},
                                                                        Events = new List<Event> { new Event()}
                                                                    };
                                      };
        }

        public class when_home_controller_is_asked_to_return_index_view : home_controller_concern
        {
            private static ActionResult result;

            private Establish c = () => the_client_tasks.setup(x => x.GetAllMeetings()).Return(the_page_view_model);
            private Because b = () => result = sut.Index();

            private It should_return_a_view_with_meetings_pageviewmodel = () => result.ShouldBeAView().And().ShouldContainAViewModelOfType<MeetingsPageViewModel>();

            private It should_return_a_pageviewmodel_with_meetings =
                () =>
                result.ShouldBeAView().And().ShouldContainAViewModelOfType<MeetingsPageViewModel>().Meetings.Count.
                    ShouldEqual(1);
        }

        public class when_the_home_controller_is_asked_to_get_events_in_a_meeting : home_controller_concern
        {
            private static MeetingFormViewModel the_form_view_model;

            private static string THE_MEETING_ID = "1";

            private static ActionResult result;

            private Establish c = () =>
                                      {
                                          the_form_view_model = new MeetingFormViewModel {Meetings = THE_MEETING_ID};
                                          the_client_tasks.setup(x => x.GetAllEventsInMeeting(the_form_view_model)).Return(the_page_view_model);
                                      };

            private Because b = () => result = sut.Index(the_form_view_model);

            private It should_return_a_pageviewmodel_with_events = () => result.ShouldBeAView().And().ShouldContainAViewModelOfType<MeetingsPageViewModel>();

            It should_return_the_page_view_model_with_events = () => result.ShouldBeAView().And().ShouldContainAViewModelOfType<MeetingsPageViewModel>().Events.downcast_to<IList<Event>>().Count.ShouldEqual(1);
        }
    }
}
