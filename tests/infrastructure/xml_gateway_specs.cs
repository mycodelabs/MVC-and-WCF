using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using domain;
using infrasrtucture;
using infrasrtucture.contracts;
using Machine.Specifications;

namespace tests.infrastructure
{
    [Subject("XML Gateway Specs")]
    public class xml_gateway_specs
    {
        public abstract class when_asked_to_get_data_concern : Observes<IXmlGateway, XmlGateway>
        {
        }

        public class when_asked_to_get_all_meetings : when_asked_to_get_data_concern
        {
            static IProviderFactory the_provider;
            static Meetings the_meetings;

          Establish c = () => 
            {
                the_meetings = new Meetings();
                the_provider = depends.on<IProviderFactory>();
                       the_provider.setup(x => x.CreateDocument<Meetings>()).Return(the_meetings);
            };

            private Because b = () => results = sut.SerializeDocument();
            private It should_return_all_meetings = () => results.ShouldNotBeNull();
            private static Meetings results;
        }
    }
}
