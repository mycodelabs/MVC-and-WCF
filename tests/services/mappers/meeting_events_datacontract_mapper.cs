using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using domain;
using Machine.Specifications;
using services.datamodel;
using services.mappers;
using services.mappers.contracts;

namespace tests.services.mappers
{
    [Subject("Mapping events in a meeting to datacontract")]
    public class meeting_events_datacontract_mapper
    {
        public abstract class mapping_to_meeting_events_data_concern : Observes<IMeetingEventsDataMapper, MeetingEventsDataMapper>
        {
            
        }


        public class when_asked_to_map_to_meeting_events_data : mapping_to_meeting_events_data_concern
        {
            private Establish c = () =>
                                      {
                                          the_meeting = new Meeting
                                                            {
                                                                Events = new List<Event> {new Event(), new Event()}
                                                            };
                                      };

            private Because b = () => result = sut.MapFrom(the_meeting);

            private It should_return_list_of_events_in_a_meeting = () => result.ShouldNotBeNull();

            private It should_contain_two_events =
                () => result.downcast_to<IList<MeetingEventsData>>().Count.ShouldEqual(2);
            private static Meeting the_meeting;
            private static IEnumerable<MeetingEventsData> result;
        }
    }
}
