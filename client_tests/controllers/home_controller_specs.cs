using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
        }

        public class when_home_controller_is_asked_to_return_index_view : home_controller_concern
        {
            private static ActionResult result;

            private static MeetingsPageViewModel the_page_view_model;

            private Establish c = () =>
                                      {
                                          the_client_tasks = depends.on<IMeetingTasks>();
                                          the_page_view_model = new MeetingsPageViewModel
                                                                    {
                                                                        Meetings =
                                                                            new List<SelectListItem>
                                                                                {new SelectListItem()}
                                                                    };
                                          the_client_tasks.setup(x => x.GetAllMeetings()).Return(the_page_view_model);
                                      };

            private Because b = () => result = sut.Index();

            private It should_return_a_view = () => result.ShouldBeOfType(typeof (ViewResult));

            private It should_reurn_the_index_view =
                () => ((ViewResult)result).ViewName.ShouldBeEmpty();

            private It should_return_a_view_containing_pageviewmodel =
                () => result.downcast_to<ViewResult>().Model.ShouldBeOfType(typeof (MeetingsPageViewModel));
        }
    }

    
}
