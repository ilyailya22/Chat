using Chat.Entities.Models.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Entities.Models.ChatItem
{
    public class UsersGroup
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

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
