using System.Collections.Generic;
using System.Configuration;
using System.Xml.Linq;
using System.Xml.Serialization;
using infrasrtucture.contracts;

namespace infrasrtucture
{
    public class XmlProviderFactory : IProviderFactory
    {
        readonly IFileProvider fileProvider;
        static string xmlFileName;
        
        public XmlProviderFactory(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
            xmlFileName = ConfigurationManager.AppSettings["xmlFileName"];
        }

        public XDocument CreateDocument()
        {
            return new XDocument();
        }

        public T CreateDocument<T>()
        {
            T loadedObject;
            var serializer = new XmlSerializer(typeof (List<T>));
            using( var stream = this.fileProvider.GetStreamFromXml(xmlFileName))
            {
                stream.Position = 0;
                loadedObject = (T) serializer.Deserialize(stream);
            }
            return loadedObject;
        }
    }
}