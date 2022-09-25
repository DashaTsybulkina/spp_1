using core.tracer;
using core.tracer.tracerResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace core.serializer
{
    public class XMLSerializer : XmlSerializer, ISerializer
    {
        public XMLSerializer() { }
        public string Serialize(TracerResult result)
        {
            StringWriter stream = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(List<TracerThreadResult>));
            serializer.Serialize(stream, result.GetThreads());
            return stream.ToString();
        }
    }
}
