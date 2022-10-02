using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.tracer.tracerResult
{
    [Serializable]
    public class TracerThreadResult
    {
        public long Time
        {
            get
            {
                long res = 0;
                foreach (var method in Methods)
                {
                    res = res + method.Time;
                }
                return res;
            }
        }
        public long ThreadId { get; set; }
        public List<MethodTracerResult> Methods { get; set; }

        public TracerThreadResult(long id)
        {
            ThreadId = id;
            Methods = new List<MethodTracerResult>();
        }

        public void AddMethods(List<MethodTracerResult> methods)
        {
            this.Methods = methods;
        }
    }
}
