using Newtonsoft.Json;

namespace XiangXi.Evaluators
{
    public static class ObjectExtension
    {
        public static string ToJson(this object obj)
        {
            if (obj == null) return string.Empty;
            return JsonConvert.SerializeObject(obj, Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                });
        }
    }
}