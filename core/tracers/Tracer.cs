using core.tracer;
using System.Collections;
using System.Diagnostics;

namespace core.tracers
{
    public class Tracer: ITracer
    {
        private double startTime;
        private double endTime;
        private TracerResult traceResult;
        public Tracer() { 
            traceResult = new TracerResult();
            traceResult.methods = new ArrayList();
        }

        public void StartTrace()
        {   
            double timesTamp = Stopwatch.GetTimestamp();
            startTime = 1_000_000_000.0 * timesTamp / Stopwatch.Frequency;
            
        }

        public void StopTrace()
        {
            double timesTamp = Stopwatch.GetTimestamp();
            endTime = 1_000_000_000.0 * timesTamp / Stopwatch.Frequency;
            traceResult.executionTime = endTime - startTime;
        }

        public TracerResult GetTraceResult() 
        { 
            return traceResult;
        }

        public void addMethodToResult(MethodTracerResult method)
        {
            traceResult.addMethod(method);
        }
    }
}
