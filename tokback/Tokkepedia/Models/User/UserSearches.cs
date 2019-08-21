using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Tokkepedia.Models
{

    public class TokkepediaFollow 
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString("n");

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "follow";

        //Type of feed the user is following
        [JsonProperty(PropertyName = "feed_label")]
        public string FeedLabel { get; set; } = "user";

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; } = "user";

        //Retrieve separately in the client in case changes are made
        [JsonProperty(PropertyName = "user_display_name")]
        public string UserDisplayName { get; set; } = "User Name";

        [JsonProperty(PropertyName = "user_photo")]
        public string UserPhoto { get; set; }
        //---

        [JsonProperty(PropertyName = "follow_id")]
        public string FollowId { get; set; }

        [JsonProperty(PropertyName = "follow_display_name")]
        public string FollowDisplayName { get; set; }

        [JsonProperty(PropertyName = "follow_photo")]
        public string FollowPhoto { get; set; }

        [JsonProperty(PropertyName = "following")]
        public bool IsFollowing { get; set; }

        [JsonProperty(PropertyName = "update_count")]
        public int UpdateCount { get; set; }

        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        //DataTime format
        [JsonProperty(PropertyName = "timestamp")]
        public new DateTime Timestamp { get; set; } = DateTime.Now;

        //Unix time format
        [JsonProperty(PropertyName = "_ts")]
        public int _Timestamp { get; set; }

        [JsonProperty(PropertyName = "pk")]
        public string PartitionKey { get; set; }

        public string UserFollowed { get; set; }
    }
}
