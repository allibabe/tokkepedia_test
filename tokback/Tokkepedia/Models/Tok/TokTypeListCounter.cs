using Newtonsoft.Json;
using System;

namespace Tokkepedia.Models
{
    /// <summary>  
    ///  Used for counting Toks by type
    /// </summary>
    public class TokTypeListCounter
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "toktypelistcounter";

        [JsonProperty(PropertyName = "tok_group")]
        public string TokGroup { get; set; }

        [JsonProperty(PropertyName = "group_count")]
        public int GroupCount { get; set; }

        [JsonProperty(PropertyName = "tok_types")]
        public string[] TokTypes { get; set; }

        [JsonProperty(PropertyName = "tok_type_ids")]
        public string[] TokTypeIds { get; set; }

        [JsonProperty(PropertyName = "type_counts")]
        public int[] TokTypeCounts { get; set; }

        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        //DataTime format
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "pk")]
        public string PartitionKey { get; set; } = "toktypelist";

        //Unix time format
        [JsonProperty(PropertyName = "_ts")]
        public int _Timestamp { get; set; }
    }

    /// <summary>  
    /// Stores user tok count and type/group points
    /// </summary>
    public class TokTypeListUserCounter
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = "";

        [JsonProperty(PropertyName = "pk")]
        public string PartitionKey { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "toktypelistusercounter";

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; } = "user";

        [JsonProperty(PropertyName = "user_display_Name")]
        public string UserDisplayName { get; set; } = "User Name";

        [JsonProperty(PropertyName = "tok_group")]
        public string TokGroup { get; set; }

        [JsonProperty(PropertyName = "group_count")]
        public int GroupCount { get; set; }

        [JsonProperty(PropertyName = "group_points")]
        public int GroupPoints { get; set; }

        [JsonProperty(PropertyName = "group_reports")]
        public int GroupReports { get; set; }

        [JsonProperty(PropertyName = "group_reports_current")]
        public int GroupReportsCurrent { get; set; }

        [JsonProperty(PropertyName = "tok_types")]
        public string[] TokTypes { get; set; }

        [JsonProperty(PropertyName = "tok_type_ids")]
        public string[] TokTypeIds { get; set; }

        [JsonProperty(PropertyName = "type_counts")]
        public int[] TokTypeCounts { get; set; }

        [JsonProperty(PropertyName = "type_points")]
        public int[] TokTypePoints { get; set; }

        [JsonProperty(PropertyName = "type_reports")]
        public int[] TokTypeReports { get; set; }

        [JsonProperty(PropertyName = "type_reports_current")]
        public int[] TokTypeReportsCurrent { get; set; }

        [JsonProperty(PropertyName = "created_date")]
        public DateTime Published { get; set; } = DateTime.Now;
    }
}
