using Newtonsoft.Json;
using System;

namespace Tokkepedia.Models
{
    //Used for 
    public class TokTypeList
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "toktypelist";

        [JsonProperty(PropertyName = "pk")]
        public string PartitionKey { get; set; }

        [JsonProperty(PropertyName = "tok_group")]
        public string TokGroup { get; set; }

        [JsonProperty(PropertyName = "primary_field_name")]
        public string PrimaryFieldName { get; set; }

        [JsonProperty(PropertyName = "secondary_field_name")]
        public string SecondaryFieldName { get; set; }

        [JsonProperty(PropertyName = "is_detail_based")]
        public bool IsDetailBased { get; set; }

        [JsonProperty(PropertyName = "primary_char_limit")]
        public int PrimaryCharLimit { get; set; }

        [JsonProperty(PropertyName = "secondary_char_limit")]
        public int SecondaryCharLimit { get; set; }

        [JsonProperty(PropertyName = "tok_types")]
        public string[] TokTypes { get; set; }

        [JsonProperty(PropertyName = "tok_type_ids")]
        public string[] TokTypeIds { get; set; }

        [JsonProperty(PropertyName = "optional_fields")]
        public string[] OptionalFields { get; set; }

        [JsonProperty(PropertyName = "optional_limits")]
        public int[] OptionalLimits { get; set; }

        [JsonProperty(PropertyName = "required_fields")]
        public string[] RequiredFields { get; set; }

        //INFORMATIONAL FIELDS
        //Tok Group Description
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        //Tok Type Descriptions
        [JsonProperty(PropertyName = "descriptions")]
        public string[] Descriptions { get; set; }

        //Tok Group Examples
        [JsonProperty(PropertyName = "example")]
        public string Example { get; set; }

        //Tok Type Descriptions
        [JsonProperty(PropertyName = "examples")]
        public string[] Examples { get; set; }

        [JsonProperty(PropertyName = "has_answer_field", NullValueHandling = NullValueHandling.Ignore)]
        public bool HasAnswerField { get; set; } = false;

        #region Details min, max, and default
        [JsonProperty(PropertyName = "details_min")]
        public int DetailsMin { get; set; } = 3;

        [JsonProperty(PropertyName = "details_max")]
        public int DetailsMax { get; set; } = 5;

        [JsonProperty(PropertyName = "details_default")]
        public int DetailsDefault { get; set; } = 5;
        #endregion
    }

    public class TokGroup : BaseModel
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "tokgroup";

        [JsonProperty(PropertyName = "tok_group")]
        public string TokGroupName { get; set; }

        [JsonProperty("toks")]
        public long Toks { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("coins")]
        public long Coins { get; set; }

        [JsonProperty("deleted_toks")]
        public long DeletedToks { get; set; }

        [JsonProperty("deleted_points")]
        public long DeletedPoints { get; set; }

        [JsonProperty("deleted_coins")]
        public long DeletedCoins { get; set; }
    }

    public class TokType : TokGroup
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "label")]
        public new string Label { get; set; } = "toktype";

        [JsonProperty(PropertyName = "tok_type")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; } = null;

        [JsonProperty(PropertyName = "example", NullValueHandling = NullValueHandling.Ignore)]
        public string Example { get; set; } = null;
    }

    public class Category : BaseModel
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "category";

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty("toks")]
        public long Toks { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("coins")]
        public long Coins { get; set; }

        [JsonProperty("deleted_toks")]
        public long DeletedToks { get; set; }

        [JsonProperty("deleted_points")]
        public long DeletedPoints { get; set; }

        [JsonProperty("deleted_coins")]
        public long DeletedCoins { get; set; }

        [JsonProperty(PropertyName = "likes")]
        public long Likes { get; set; }

        [JsonProperty(PropertyName = "followers")]
        public long Followers { get; set; }
    }

    public class Country : BaseModel
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "country";

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty("toks")]
        public long Toks { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("coins")]
        public long Coins { get; set; }

        [JsonProperty("deleted_toks")]
        public long DeletedToks { get; set; }

        [JsonProperty("deleted_points")]
        public long DeletedPoints { get; set; }

        [JsonProperty("deleted_coins")]
        public long DeletedCoins { get; set; }
    }
}
