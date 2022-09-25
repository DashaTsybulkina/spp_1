using core.tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.serializer
{
    public interface ISerializer
    {
        string Serialize(TracerResult result);
    }
}
