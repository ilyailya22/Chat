using Chat.Entities.Models.User;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Entities.Models.ChatItem
{
    public class Message
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("GroupId")]
        public Guid GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [JsonProperty("UserId")]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserInfo UserInfo { get; set; }
    }
}
