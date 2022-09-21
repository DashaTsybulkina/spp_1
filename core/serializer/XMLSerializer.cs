using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace core.serializer
{
    internal class XMLSerializer : ISerializer
    {
        public void serialize(TextWriter stream, object data)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(object));
            xmlSerializer.Serialize(stream, data);
        }
    }
}
