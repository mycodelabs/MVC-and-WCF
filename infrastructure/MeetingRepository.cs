using System.Collections.Generic;
using contracts;
using domain;
using infrasrtucture.contracts;

namespace infrasrtucture
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly IXmlGateway xmlGateway;

        public MeetingRepository(IXmlGateway xmlGateway)
        {
            this.xmlGateway = xmlGateway;
        }

        public IEnumerable<Meeting> GetAll()
        {
           var meetingsLibrary = this.xmlGateway.SerializeDocument();
            foreach (var meeting in meetingsLibrary.MeetingsLibrary)
            {
                yield return meeting;
            }
        }
    }
}