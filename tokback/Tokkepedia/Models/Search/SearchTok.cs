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
    /// <summary>Indexing of toks in the Azure Search service</summary>
    public class SearchTok
    {
        /// <summary>Determines how the document is stored</summary>
        [System.ComponentModel.DataAnnotations.Key]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>Only get toks of a specific tok group</summary>
        [IsFilterable]
        [JsonProperty(PropertyName = "tok_group")]
        public string TokGroup { get; set; }

        /// <summary>Only get toks of a specific tok type</summary>
        [IsFilterable]
        [JsonProperty(PropertyName = "tok_type")]
        public string TokType { get; set; }

        /// <summary>Only get toks of a specific category</summary>
        [IsFilterable]
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [IsSearchable]
        [Analyzer(AnalyzerName.AsString.StandardLucene)]
        [JsonProperty(PropertyName = "primary_text")]
        public string PrimaryText { get; set; }

        [IsSearchable]
        [Analyzer(AnalyzerName.AsString.StandardLucene)]
        [JsonProperty(PropertyName = "secondary_text", NullValueHandling = NullValueHandling.Ignore)]
        public string SecondaryText { get; set; }

        [IsSearchable]
        [Analyzer(AnalyzerName.AsString.StandardLucene)]
        [JsonProperty(PropertyName = "details", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] Details { get; set; }

        /// <summary>Filter out content with or without image</summary>
        [IsFilterable]
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        /// <summary>Filter out content with or without details</summary>
        [IsFilterable]
        [JsonProperty(PropertyName = "is_detail_based")]
        public bool IsDetailBased { get; set; }

        /// <summary>Filter out sensitive content</summary>
        [IsFilterable]
        [JsonProperty(PropertyName = "nsfw")]
        public bool NSFW { get; set; } = false;

        /// <summary>Sort by date (Top vs Latest)</summary>
        [IsSortable]
        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; }
    }
}
