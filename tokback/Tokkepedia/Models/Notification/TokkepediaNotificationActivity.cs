using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tokkepedia.Models
{
    public class TokkepediaNotificationActivity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonProperty(PropertyName = "foreign_id")]
        public string ForeignId { get; set; }

        #region User data
        [JsonProperty(PropertyName = "user_display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string UserDisplayName { get; set; } = null;

        [JsonProperty(PropertyName = "user_photo", NullValueHandling = NullValueHandling.Ignore)]
        public string UserPhoto { get; set; } = null;

        [JsonProperty(PropertyName = "cover_photo", NullValueHandling = NullValueHandling.Ignore)]
        public string CoverPhoto { get; set; } = null;

        [JsonProperty(PropertyName = "user_bio", NullValueHandling = NullValueHandling.Ignore)]
        public string UserBio { get; set; } = null;
        #endregion

        #region Reaction Data
        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public ReactionData ReactionData { get; set; } = null;
        #endregion
    }

    public class ReactionData
    {
        [JsonProperty(PropertyName = "owner")]
        public string OwnerId { get; set; } = "";

        [JsonProperty(PropertyName = "is_detail_reaction")]
        public bool IsDetailReaction { get; set; } = false;

        [JsonProperty(PropertyName = "is_comment")]
        public bool IsComment { get; set; } = false;

        [JsonProperty(PropertyName = "is_child")]
        public bool IsChild { get; set; } = false;

        #region Detail fields
        [JsonProperty(PropertyName = "detail_num")]
        public long DetailNum { get; set; } = 0;
        #endregion

        #region Comment fields
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "is_edited")]
        public bool IsEdited { get; set; }
        #endregion

        #region Child fields
        [JsonProperty(PropertyName = "parent_user")]
        public string ParentUser { get; set; } = "";

        [JsonProperty(PropertyName = "parent_item")]
        public string ParentItem { get; set; } = "";
        #endregion
    }
}
