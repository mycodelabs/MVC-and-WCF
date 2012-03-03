using System.Collections.Generic;
using System.IO;
using System.Text;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using domain;
using infrasrtucture;
using infrasrtucture.contracts;
using Machine.Specifications;

namespace tests.infrastructure
{
    public class xml_provider_factory_specs
    {
        public abstract class when_asked_to_serialize_xml_concern : Observes<IProviderFactory, XmlProviderFactory>
        {
            protected static string xml_file;

            protected Establish c = () =>
                                      {
                                          xml_file =
                                              "<Meetings><Meeting><Id>1</Id><Name>Meeting 1</Name></Meeting></Meetings>";
                                      };
        }

        public class when_asked_to_deserialize_xml : when_asked_to_serialize_xml_concern
        {
            private static IFileProvider the_file_provider;
            private static Stream stream;
            private static Meetings result;

            private Establish c = () =>
                                      {
                                          result = new Meetings();
                                          result.MeetingsLibrary.Add(new Meeting());
                                          the_file_provider = depends.on<IFileProvider>();
                                          stream = new MemoryStream(Encoding.Default.GetBytes(xml_file)); 
                                          the_file_provider.setup(x => x.GetStreamFromXml()).Return(stream);
                                      };

            private Because b = () => result = sut.CreateDocument<Meetings>();
            private It should_return_object = () => result.ShouldNotBeNull();
            private It should_contain_one_meeting = () => result.MeetingsLibrary.Count.ShouldEqual(1);
        }
    }
}
