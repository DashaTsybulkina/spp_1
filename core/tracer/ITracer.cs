using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core.tracer;

namespace core
{
    public interface ITracer
    {
        void StartTrace();
        void StopTrace();
        TracerResult GetTraceResult();
    }
}
