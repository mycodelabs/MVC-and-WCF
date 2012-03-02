using System.Collections.Generic;
using contracts;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using domain;
using Machine.Specifications;
using services;
using services.datamodel;
using services.mappers.contracts;

namespace tests.services
{
    [Subject("Meetings Service Specs")]
    public class meetings_service_specs
    {
        public abstract class meetings_service_concern : Observes<IMeetingsService, MeetingsService>
        {
            protected static IMeetingRepository the_meetings_repository;

            protected Establish c = () =>
                                      {
                                          the_meetings_repository = depends.on<IMeetingRepository>();
                                      };
        }  

        public class when_the_service_asks_repository_to_get_list_of_meetings : meetings_service_concern
        {
            private static IEnumerable<MeetingData> result;
            private static IMeetingDataContractMapper the_meetings_data_mapper;
            private static IEnumerable<Meeting> the_meetings;
            private static IEnumerable<MeetingData> the_meetings_data;

            private Establish c = () =>
                                      {
                                          the_meetings_data = new List<MeetingData>{ new MeetingData()};
                                          the_meetings = new List<Meeting>{new Meeting()};
                                          the_meetings_repository.setup(x => x.GetAll()).Return(the_meetings);
                                          the_meetings_data_mapper = depends.on<IMeetingDataContractMapper>();
                                          the_meetings_data_mapper.setup(x => x.MapFrom(the_meetings)).Return(the_meetings_data);
                                      };

            private Because b = () => result = sut.GetAllMeetings();

            private It should_ask_repository_to_return_meetings = () => result.ShouldNotBeNull();

            private It should_contain_one_meeting = () => result.downcast_to<IList<MeetingData>>().Count.ShouldEqual(1);
        }
    }
}
