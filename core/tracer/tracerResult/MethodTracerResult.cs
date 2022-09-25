using System.Diagnostics;

namespace core.tracer
{
    [Serializable]
    public class MethodTracerResult
    {
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public List<MethodTracerResult> Methods { get; set; }
        public long Time { get; private set; }
        private Stopwatch Stopwatch { get; }

        public MethodTracerResult(string ClassName, string MethodName)
        {
            Stopwatch = new Stopwatch();
            this.MethodName = MethodName;
            this.ClassName = ClassName;
            this.Methods = new List<MethodTracerResult>();
        }

        public void AddMethod(MethodTracerResult method)
        {
            Methods.Add(method);
        }

        public void BalanceTime(long delete)
        {
            Time = Time - delete;
        }

        public void StartTimer()
        {
            Stopwatch.Start();
        }

        public void StopTimer()
        {
            Stopwatch.Stop();
            Time = Stopwatch.ElapsedMilliseconds;
        }


    }
}
