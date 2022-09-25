using core.tracer.tracerResult;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace core.tracer
{
    [Serializable]
    public class TracerResult
    {
        private List<TracerThreadResult> Threads;

        public TracerResult(List<TracerThreadResult> listThreads){
            Threads = listThreads;
        }

        public List<TracerThreadResult> GetThreads()
        {
            return Threads;
        }

    }
}
