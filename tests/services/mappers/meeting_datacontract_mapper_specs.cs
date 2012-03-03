using System.Collections.Generic;
using developwithpassion.specifications.rhinomocks;
using domain;
using Machine.Specifications;
using services.datamodel;
using services.mappers;
using services.mappers.contracts;

namespace tests.services.mappers
{
    [Subject("Mapping from domain object to data contract")]
    public class meeting_datacontract_mapper_specs
    {
        public abstract class mapping_object_to_datacontract_concern : Observes<IMeetingDataContractMapper, MeetingDataContractMapper>
        {
            
        }

        public class when_a_data_contract_mapper_is_asked_to_map_from_domain : mapping_object_to_datacontract_concern
        {
            private static IEnumerable<Meeting> meetings;

            private static IEnumerable<MeetingData> result;

            private Establish c = () =>
                                      {
                                          meetings = new List<Meeting>(){ new Meeting()};
                                          result = new List<MeetingData>();
                                      };

            private Because b = () => result = sut.MapFrom(meetings);

            private It should_return_datacontract = () => result.ShouldNotBeNull();
        }
    }
}
