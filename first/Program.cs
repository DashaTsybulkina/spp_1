using core;
using core.serializer;
using core.tracer;
using core.tracers;
using System;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace first
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tracer = new Tracer();
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();

            Thread thread = new Thread(new ParameterizedThreadStart(Do1));
            thread.Start(tracer);
            thread.Join();

            TracerResult result = tracer.GetTraceResult();

            ISerializer serializer = new JSONSerializer();
            string output = serializer.Serialize(result);

            Console.WriteLine(output);

            using (var file = new FileStream("result.json", FileMode.Create))
            {
                using (var writer = new StreamWriter(file))
                {
                    writer.WriteLine(output);
                }
            }
        }

        private static void Do1(Object tracer)
        {
            Tracer tracerTest = (Tracer)tracer;
            tracerTest.StartTrace();
            Thread.Sleep(100);
            tracerTest.StopTrace();
        }

        private class Example {
            public ITracer tracer;

            public Example(ITracer tracer)
            {
                this.tracer = tracer;
            }

            public void MethodFirst() { 
                tracer.StartTrace();
                Thread.Sleep(500);
                tracer.StopTrace(); 
            }

            public void MethodSecond()
            {
                tracer.StartTrace();
                Thread.Sleep(100);
                MethodFirst();
                tracer.StopTrace();
            }

            public void MethodThird()
            {
                tracer.StartTrace();
                MethodFirst();
                MethodSecond();
                tracer.StopTrace();
            }
        }
    }
}