using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace core.tracer
{
    public class TracerResult
    {
        public long threadId { get;  set; }
        public double executionTime { get;  set; }
        public ArrayList methods { get; set; }

        public void addMethod(MethodTracerResult method)
        { 
            methods.Add(method);
        }

    }
}
