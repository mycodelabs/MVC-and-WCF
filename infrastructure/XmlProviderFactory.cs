using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using infrasrtucture.contracts;

namespace infrasrtucture
{
    public class XmlProviderFactory : IProviderFactory
    {
        readonly IFileProvider fileProvider;
       
        
        public XmlProviderFactory(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
            
        }

        public T CreateDocument<T>()
        {
            T loadedObject;
            var serializer = new XmlSerializer(typeof (T));
            using( var stream = this.fileProvider.GetStreamFromXml())
            {
                loadedObject = (T) serializer.Deserialize(stream);
            }
            return loadedObject;
        }
    }
}