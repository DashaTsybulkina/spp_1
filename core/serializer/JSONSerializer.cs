using Newtonsoft.Json;

namespace core.serializer
{
    public class JSONSerializer :ISerializer
    {
        public void serialize(TextWriter writer, object data)
        {
            writer.WriteLine(
                JsonConvert.SerializeObject(data, Formatting.Indented)
            );
        }
    }
}
