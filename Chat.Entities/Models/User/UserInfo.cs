using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Chat.Entities.Models.User
{
    public class UserInfo
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
