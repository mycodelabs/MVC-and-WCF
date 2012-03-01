using System.Collections.Generic;
using domain;
using infrasrtucture.contracts;

namespace infrasrtucture
{
    public class MeetingRepository : IRepository<Meeting>
    {
        private readonly IXmlGateway xmlGateway;

        public MeetingRepository(IXmlGateway xmlGateway)
        {
            this.xmlGateway = xmlGateway;
        }

        public Meeting GetAll()
        {
            return this.xmlGateway.SerializeDocument();
        }
    }
}