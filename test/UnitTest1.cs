using core.tracers;
using core.tracer.tracerResult;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using core.serializer;
using core.tracer;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {
            Tracer tracer = new Tracer();
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
            List<TracerThreadResult> TracerResult = tracer.GetTraceResult().GetThreads();
            Assert.AreEqual(1, TracerResult.Count);
        }

        [TestMethod]
        public void TestMethod2() {

            Tracer tracer = new Tracer();
            tracer.StartTrace();
            Thread.Sleep(10);
            tracer.StopTrace();
            Thread thread = new Thread(new ParameterizedThreadStart(fun1));
            thread.Start(tracer);
            thread.Join();
            TracerResult tracerResult = tracer.GetTraceResult();

            ISerializer serializer = new JSONSerializer();
            string output = serializer.Serialize(tracerResult);

            Console.WriteLine(output);

            using (var file = new FileStream("result.json", FileMode.Create))
            {
                using (var writer = new StreamWriter(file))
                {
                    writer.WriteLine(output);
                }
            }
            Assert.AreEqual(2, tracerResult.GetThreads().Count);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var tracer = new Tracer();
            tracer.StartTrace();
            FirstMethod(tracer);
            Thread.Sleep(100);
            tracer.StopTrace();
            Main2(tracer);

            TracerResult tracerResult = tracer.GetTraceResult();
            ISerializer serializer = new JSONSerializer();
            string output = serializer.Serialize(tracerResult);

            Console.WriteLine(output);

            using (var file = new FileStream("result.json", FileMode.Create))
            {
                using (var writer = new StreamWriter(file))
                {
                    writer.WriteLine(output);
                }
            }
            var result = tracerResult.GetThreads();
            Assert.AreEqual("FirstMethod", result[0].Methods[0].Methods[0].MethodName);
        }

        private static void fun1(Object tracer)
        {
            Tracer tracerTest = (Tracer)tracer;
            tracerTest.StartTrace();
            Thread.Sleep(100);
            tracerTest.StopTrace();
        }

        public void Main2(Tracer tracer)
        {
            tracer.StartTrace();
            Thread.Sleep(10);
            tracer.StopTrace();
        }
        public void FirstMethod(Tracer tracer)
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            SecondMethod(tracer);
            tracer.StopTrace();
        }
        public void SecondMethod(Tracer tracer)
        {
            tracer.StartTrace();
            Thread.Sleep(120);
            tracer.StopTrace();
        }
    }
}