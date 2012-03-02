using System.Collections.Generic;
using System.IO;
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

            private Establish c = () =>
                                      {
                                          xml_file = @"D:\Labs\MVC and WCF\data\Meetings.xml";
                                      };
        }

        public class when_asked_to_deserialize_xml : when_asked_to_serialize_xml_concern
        {
            private static IFileProvider the_file_provider;
            private static FileStream stream;
            private static Meetings result;

            private Establish c = () =>
                                      {
                                          result = new Meetings();
                                          the_file_provider = depends.on<IFileProvider>();
                                          stream = new FileStream(xml_file, FileMode.Open, FileAccess.Read); 
                                          the_file_provider.setup(x => x.GetStreamFromXml(xml_file)).Return(stream);
                                      };

            private Because b = () => result = sut.CreateDocument<Meetings>();
            private It should_return_object = () => result.ShouldNotBeNull();
        }
    }
}
