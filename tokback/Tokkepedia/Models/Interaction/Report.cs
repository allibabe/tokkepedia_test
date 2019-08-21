using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models
{
    public class Report
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = "report-" + Guid.NewGuid().ToString("n");

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "report";

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        //Can be a tok, user, etc
        [JsonProperty(PropertyName = "item_id")]
        public string ItemId { get; set; }

        [JsonProperty(PropertyName = "item_label")]
        public string ItemLabel { get; set; }

        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "pk")]
        public string PartitionKey { get; set; } = "report-userid";
    }
}
