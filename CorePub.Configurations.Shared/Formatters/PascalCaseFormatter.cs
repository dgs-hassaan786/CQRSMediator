using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Buffers;
using Microsoft.Net.Http.Headers;

namespace CorePub.Configurations.Shared.Formatters
{
    public class PascalCaseFormatter : JsonOutputFormatter
    {
        public PascalCaseFormatter() : base(new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() }, ArrayPool<char>.Shared)
        {
            SupportedMediaTypes.Clear();
            MediaTypeHeaderValue item = MediaTypeHeaderValue.Parse("application/json;profile=\"https://en.wikipedia.org/wiki/PascalCase\"");
            SupportedMediaTypes.Add(item);
        }
    }
}
