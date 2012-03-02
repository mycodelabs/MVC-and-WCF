using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using contracts;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using domain;
using infrasrtucture;
using infrasrtucture.contracts;
using Machine.Specifications;

namespace tests.infrastructure
{
    [Subject("Meeting Repository Specs")]
    public class meeting_repository_specs 
    {
        public abstract class meeting_repository_concern : Observes<IMeetingRepository, MeetingRepository>
        {
        }

        public class when_asked_to_retrieve_meetings_from_xml_file : meeting_repository_concern
        {
            private static IXmlGateway the_gateway;
            private static IEnumerable<Meeting> results;
            private static Meetings _meetings;
            private Establish c = () =>
                                      {
                                          results = new List<Meeting>();
                                          _meetings = new Meetings();
                                          the_gateway = depends.on<IXmlGateway>();
                                          the_gateway.setup(x => x.SerializeDocument()).Return(_meetings);
                                      };

            Because b = () => results = sut.GetAll();

            It should_return_meetings = () => results.ShouldNotBeNull();

            //private It should_contain_one_meeting = () => results.Count().ShouldEqual(1);
        }
    }
}
