using core.tracer;
using Newtonsoft.Json;

namespace core.serializer
{
    public class JSONSerializer :ISerializer
    {
        public string Serialize(TracerResult result)
        {
            return JsonConvert.SerializeObject(result.GetThreads(), Formatting.Indented);
        }
    }
}
