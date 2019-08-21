using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Tools;
using Tokkepedia.Tools.Helpers;

namespace Tokkepedia.Models
{
    public class TokkepediaNotification
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        //Id of the post involved, not working yet
        [JsonProperty(PropertyName = "item_id")]
        public string ItemId { get; set; } = "";

        [JsonRequired]
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "notification";

        [JsonProperty(PropertyName = "notification_text", NullValueHandling = NullValueHandling.Ignore)]
        public string NotificationText { get; set; } = "";

        [JsonProperty(PropertyName = "is_read")]
        public bool IsRead { get; set; }
        [JsonProperty(PropertyName = "is_seen")]
        public bool IsSeen { get; set; }

        [JsonProperty(PropertyName = "items")]
        public IEnumerable<TokkepediaNotificationActivity> Items { get; set; }

        [JsonProperty(PropertyName = "actor_count")]
        public int ActorCount { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
