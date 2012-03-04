using System;
using System.Collections.Generic;
using System.Web.Mvc;
using clienttasks;
using clienttasks.mappers.contracts;
using clienttasks.meetingsservice;
using controllers.Controllers.Home.viewmodel;
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
            protected static IMeetingsService meeting_service;

            protected static MeetingData[] meetings_data;

            protected static IMeetingsPageViewModelMapper the_meetings_page_viewmodel_mapper;

            protected static MeetingsPageViewModel the_page_view_model;

            protected Establish c = () =>
                                      {
                                          meetings_data = new MeetingData[]{ new MeetingData(), new MeetingData(),  };
                                          meeting_service = depends.on<IMeetingsService>();
                                          the_page_view_model = new MeetingsPageViewModel
                                                                    {
                                                                        Meetings =
                                                                            new List<SelectListItem>()
                                                                                {
                                                                                    new SelectListItem(),
                                                                                    new SelectListItem()
                                                                                },
                                                                        Events = new List<Event>()
                                                                                     {
                                                                                         new Event(),
                                                                                         new Event()
                                                                                      }

                                                                     };
                                          meeting_service.setup(x => x.GetAllMeetings()).Return(meetings_data);
                                          the_meetings_page_viewmodel_mapper = depends.on<IMeetingsPageViewModelMapper>();
                                          the_meetings_page_viewmodel_mapper.setup(x => x.MapFrom(meetings_data)).Return(the_page_view_model);
                                      };
        }

        public class when_client_is_asked_to_get_meetings : meeting_tasks_concern
        {
            private Because b = () => result = sut.GetAllMeetings();
            private It should_return_all_meetings = () => { the_page_view_model.ShouldNotBeNull(); };

            private It should_return_page_view_model_with_two_items = () => result.Meetings.Count.ShouldEqual(2);
            private static MeetingsPageViewModel result; 
        }

        public class when_client_is_asked_to_get_events_in_a_meeting : meeting_tasks_concern
        {
            private static MeetingFormViewModel the_form_view_model;
            private static string THE_MEETING_ID = "1";

            private static MeetingEventsData[] the_events_data;
            private static MeetingsPageViewModel result;

            private Establish c = () =>
                                      {
                                          the_form_view_model = new MeetingFormViewModel {Meetings = THE_MEETING_ID};
                                          the_events_data = new MeetingEventsData[]{ new MeetingEventsData(), new MeetingEventsData() };
                                          meeting_service.setup(x => x.GetAllEventsInMeeting(the_form_view_model.Meetings)).Return(the_events_data);
                                          the_meetings_page_viewmodel_mapper = depends.on<IMeetingsPageViewModelMapper>();
                                          the_meetings_page_viewmodel_mapper.setup(x => x.MapFrom(meetings_data, the_events_data)).Return(the_page_view_model);
                                      };

            private Because b = () => result = sut.GetAllEventsInMeeting(the_form_view_model);

            private It should_return_the_list_of_events_in_a_meeting = () => result.Events.Count.ShouldEqual(2);
        }
    }
}
