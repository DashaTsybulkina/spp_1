using core.tracer;
using core.tracer.tracerResult;
using System.Collections;
using System.Collections.Concurrent;

using System.Diagnostics;

namespace core.tracers
{
    public class Tracer: ITracer
    {
        private ConcurrentDictionary<int, ConcurrentStack<MethodTracerResult>> threads;

        public Tracer() { 
            threads = new ConcurrentDictionary<int, ConcurrentStack<MethodTracerResult>>();
        }

        public void StartTrace()
        {
            int threedId = Thread.CurrentThread.ManagedThreadId;
            StackFrame[] stackFrames = new StackTrace(true).GetFrames();
            var stackFrame = stackFrames[1];
            ConcurrentStack<MethodTracerResult> stack = threads.GetOrAdd(threedId, new ConcurrentStack<MethodTracerResult>());
            MethodTracerResult method = new MethodTracerResult(stackFrame.GetMethod().DeclaringType.FullName, stackFrame.GetMethod().Name);
            stack.Push(method);
            method.StartTimer();
        }

        public void StopTrace()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            ConcurrentStack<MethodTracerResult> stack = threads.GetOrAdd(id, new ConcurrentStack<MethodTracerResult>());
            stack.TryPop(out var method);
            method.StopTimer();
            if (stack.TryPeek(out var parent))
            {
                parent.AddMethod(method);
            }
            else
            {
                stack.Push(method);
            }
        }

        public TracerResult GetTraceResult() 
        {
            List<TracerThreadResult> results = new List<TracerThreadResult>();
            foreach (var id in threads.Keys)
            {
                TracerThreadResult thread = new TracerThreadResult(id);
                ConcurrentStack<MethodTracerResult> methods = threads.GetOrAdd(id, new ConcurrentStack<MethodTracerResult>());
                thread.AddMethods(methods.ToList());
                results.Add(thread);
            }
            TracerResult resultTrace = new TracerResult(results);
            return resultTrace;
        }
    }
}
