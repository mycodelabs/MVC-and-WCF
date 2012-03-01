using System.Collections.Generic;
using System.Linq;
using domain;
using infrasrtucture.contracts;
using infrasrtucture.utilities;

namespace infrasrtucture
{
    public class XmlGateway : IXmlGateway
    {
        private readonly IProviderFactory providerFactory;

        public XmlGateway(IProviderFactory providerFactory)
        {
            this.providerFactory = providerFactory;
        }

        public Meeting SerializeDocument()
        {
            var document = this.providerFactory.CreateDocument<Meeting>();
            return document;
        }
    }
}