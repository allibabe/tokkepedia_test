using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Tokkepedia.Tools;

namespace Tokkepedia.Models
{
    public class BaseModel
    {
        [JsonIgnore]
        string id = Guid.NewGuid().ToString("n");

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set
            {
                PartitionKey = value;
                id = value;
            }
        }

        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        [JsonIgnore]
        private DateTime timestamp = DateTime.Now;

        //DataTime format
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp
        {
            get { return timestamp; }
            set
            {
                timestamp = DateTime.Now;
                _Timestamp = DateTime.Now.ToUnixTime();
            }
        }

        //Unix time format
        [JsonProperty(PropertyName = "_ts")]
        public long _Timestamp { get; set; }

        [JsonProperty(PropertyName = "pk")]
        public string PartitionKey { get; set; }
    }
}
