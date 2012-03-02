using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain 
{
     [Serializable]
     [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Meetings
    {
         public Meetings()
         {
             this.MeetingsLibrary = new List<Meeting>();
         }

        [System.Xml.Serialization.XmlElementAttribute("Meeting", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<Meeting> MeetingsLibrary { get; set; }
    }
}
