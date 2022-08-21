using Newtonsoft.Json;

namespace Chat.Entities.Models.Auth
{
    public class AuthResult
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
