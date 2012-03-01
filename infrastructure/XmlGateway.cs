using domain;
using infrasrtucture.contracts;

namespace infrasrtucture
{
    public class XmlGateway : IXmlGateway
    {
        private readonly IProviderFactory providerFactory;

        public XmlGateway(IProviderFactory providerFactory)
        {
            this.providerFactory = providerFactory;
        }

        public MeetingsLibrary SerializeDocument()
        {
            var document = this.providerFactory.CreateDocument<MeetingsLibrary>();
            return document;
        }
    }
}