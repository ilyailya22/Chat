using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Chat.Entities.Models.ChatItem
{
    public class Group
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Type Type { get; set; }
    }
}
