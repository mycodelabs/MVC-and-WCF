using System;
using System.Collections.Generic;
using System.Linq;
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

        public Meetings SerializeDocument()
        {
            return GetMeetings();
        }

        public Meeting GetMeetingById(string meetingId)
        {
            var meetings = GetMeetings();
            return meetings.MeetingsLibrary.Where(x => x.Id == meetingId).FirstOrDefault();
        }

        private Meetings GetMeetings()
        {
            return this.providerFactory.CreateDocument<Meetings>();
        }
    }
}