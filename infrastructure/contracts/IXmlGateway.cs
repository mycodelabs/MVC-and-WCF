using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using domain;

namespace infrasrtucture.contracts
{
    public interface IXmlGateway
    {
        Meetings SerializeDocument();
        Meeting GetMeetingById(string id);
    }
}
