using System.Text.Json;

namespace Mechanic.DDD.api.Utilidades
{
    public static class JsonHelper
    {
        public static T Deserialize<T>(string json, JsonSerializerOptions options = null)
        {
            if (options == null)
            {
                options = new JsonSerializerOptions
                {
                    AllowTrailingCommas = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
            }

            return JsonSerializer.Deserialize<T>(json, options);
        }

        public static string Serialize(object json, JsonSerializerOptions options = null)
        {
            if (options == null)
            {
                options = new JsonSerializerOptions
                {
                    AllowTrailingCommas = true,
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreNullValues = false //revisar q uso se le puede dar
                };
            }

            return JsonSerializer.Serialize(json, options: options);
        }
    }

}
