using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
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
            private Establish c = () =>
                                      {
                                          the_document =
                                              XDocument.Load(
                                                  new StringReader(
                                                      "<Meetings><Meeting><ID>1</ID><Name>Test</Name><Events Type=\"list\"><Event><EventName>Test Event</EventName><StartTime>12:00</StartTime></Event><Event><EventName>Test Event 2</EventName><StartTime>1:00</StartTime></Event></Events></Meeting></Meetings>"));
                                          
                                          the_meetings = new List<Meeting>();
                                          TheProvider = depends.on<IProviderFactory>();
                                          TheProvider.setup(x => x.CreateDocument()).Return(the_document);
                                      };

            protected static IProviderFactory TheProvider;
            protected static List<Meeting> the_meetings;
            protected static XDocument the_document;
        }

        public class when_asked_to_get_all_meetings : when_asked_to_get_data_concern
        {
           /* private Because b = () => results = sut.SerializeDocument();
            private It should_return_all_meetings = () => results.ShouldNotBeEmpty();
            private static IEnumerable<Meeting> results;*/
        }
    }
}
