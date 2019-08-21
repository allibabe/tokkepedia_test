using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Tokkepedia.Tools;
using Tokkepedia.Tools.Helpers;

namespace Tokkepedia.Models
{
    public class TokkepediaReaction
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "reaction";

        [JsonRequired]
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonIgnore]
        public Reaction ReactionKind { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; } = "user";

        [JsonProperty(PropertyName = "item_id")]
        public string ItemId { get; set; } = "";

        [JsonProperty(PropertyName = "activity_id")]
        public string ActivityId { get; set; }

        [JsonProperty(PropertyName = "category_id")]
        public string CategoryId { get; set; } = "";

        [JsonProperty(PropertyName = "tok_type_id")]
        public string TokTypeId { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
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

        #region Counter fields
        [JsonProperty("children_counts", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, int> ChildrenCounts { get; set; } = null;
        #endregion

        #region Retrieve separately in case changes are made
        [JsonProperty(PropertyName = "user_display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string UserDisplayName { get; set; } = null;

        [JsonProperty(PropertyName = "user_photo", NullValueHandling = NullValueHandling.Ignore)]
        public string UserPhoto { get; set; } = null;

        [JsonProperty(PropertyName = "cover_photo", NullValueHandling = NullValueHandling.Ignore)]
        public string CoverPhoto { get; set; } = null;

        [JsonProperty(PropertyName = "user_bio", NullValueHandling = NullValueHandling.Ignore)]
        public string UserBio { get; set; } = null;
        #endregion

        #region Base fields
        [JsonIgnore]
        string id = "";

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
        #endregion

        #region Avatars
        /// <summary>Id of the user's selected avatar</summary>
        [JsonProperty(PropertyName = "selected_avatar", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedAvatar { get; set; } = null;

        /// <summary>True if the user is using an Avatar as their profile picture, false if</summary>
        [JsonProperty(PropertyName = "is_avatar_profile_picture", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAvatarProfilePicture { get; set; } = null;
        #endregion

        [JsonIgnore]
        public List<TokkepediaReaction> ChildComments { get; set; } = new List<TokkepediaReaction>();
        
        public bool IsActive { get; set; }
    }
}
