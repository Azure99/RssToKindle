using Newtonsoft.Json;

namespace SinaNewsToKindle
{
    static class JsonSerialization
    {
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static T DeSerialize<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
