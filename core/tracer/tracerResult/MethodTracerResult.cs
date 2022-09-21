using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace core.tracer
{
    public class MethodTracerResult
    {
        public string MethodName { get; set; }

        public string ClassName { get; set; }

        public long ExecutionTime { get;  set; }
        public ArrayList Methods { get; set; }

        public MethodTracerResult()
        {
            var method = System.Reflection.MethodBase.GetCurrentMethod();
            MethodName = method.Name;
            ClassName = method.DeclaringType.Name;
            Methods = new ArrayList();
        }

        public override string ToString()
        {
            return $"{{name: {MethodName}, class: {ClassName}, time: {ExecutionTime}, methods: [{string.Join(", ", Methods)}]}}";
        }
    }
}
