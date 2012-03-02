using System.Collections.Generic;
using System.Web.Mvc;
using clienttasks;
using clienttasks.mappers.contracts;
using clienttasks.meetingsservice;
using controllers.Home;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using Presentation.contracts;

namespace client_tests
{
    public class client_meeting_tasks
    {
        public abstract class meeting_tasks_concern : Observes<IMeetingTasks, MeetingTasks>
        {
            
        }

        public class when_client_is_asked_to_get_meetings : meeting_tasks_concern
        {
            private static IMeetingsService meeting_service;

            private static MeetingData[] meetings_data;

            private static IMeetingsPageViewModelMapper the_meetings_page_viewmodel_mapper;

            private static MeetingsPageViewModel the_page_view_model;

            private Establish c = () =>
                                      {
                                          meetings_data = new MeetingData[]{ new MeetingData(), new MeetingData(),  };
                                          meeting_service = depends.on<IMeetingsService>();
                                          the_page_view_model  = new MeetingsPageViewModel
                                                                     {
                                                                         Meetings =
                                                                             new List<SelectListItem>()
                                                                                 {
                                                                                     new SelectListItem(),
                                                                                     new SelectListItem()
                                                                                 }
                                                                     };
                                          meeting_service.setup(x => x.GetAllMeetings()).Return(meetings_data);
                                          the_meetings_page_viewmodel_mapper = depends.on<IMeetingsPageViewModelMapper>();
                                          the_meetings_page_viewmodel_mapper.setup(x => x.MapFrom(meetings_data)).Return(the_page_view_model);
                                      };

            private Because b = () => result = sut.GetAllMeetings();
            private It should_return_all_meetings = () => { the_page_view_model.ShouldNotBeNull(); };

            private It should_return_page_view_model_with_two_items = () => result.Meetings.Count.ShouldEqual(2);
            private static MeetingsPageViewModel result; 
        }
    }
}
