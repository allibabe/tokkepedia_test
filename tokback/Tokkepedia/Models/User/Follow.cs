using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Tokkepedia.Models
{
    public class UserSearches : BaseModel
    {
        [JsonProperty("label")]
        public string Label { get; set; } = "usersearches";

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("searches")]
        public List<string> Searches { get; set; } = new List<string>();

    }
}
