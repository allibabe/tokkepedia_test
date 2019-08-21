using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Tokkepedia.Models
{
    public class Tok
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString("n");

        [JsonProperty(PropertyName = "activity_id")]
        public string ActivityId { get; set; } = "";

        [JsonProperty(PropertyName = "pk")]
        public string PartitionKey { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "tok";

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; } = "user";

        //Retrieve separately in the client in case changes are made
        [JsonProperty(PropertyName = "user_display_name")]
        public string UserDisplayName { get; set; } = "User Name";

        [JsonProperty(PropertyName = "user_photo", NullValueHandling = NullValueHandling.Ignore)]
        public string UserPhoto { get; set; } = null;

        [JsonProperty(PropertyName = "cover_photo", NullValueHandling = NullValueHandling.Ignore)]
        public string CoverPhoto { get; set; } = null;

        [JsonProperty(PropertyName = "user_bio", NullValueHandling = NullValueHandling.Ignore)]
        public string UserBio { get; set; } = null;

        [JsonProperty(PropertyName = "user_website", NullValueHandling = NullValueHandling.Ignore)]
        public string UserWebsite { get; set; } = null;

        [JsonProperty(PropertyName = "user_country", NullValueHandling = NullValueHandling.Ignore)]
        public string UserCountry { get; set; } = null;

        #region Accessories
        /// <summary>Id of the user's selected avatar</summary>
        [JsonProperty(PropertyName = "selected_avatar", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedAvatar { get; set; } = string.Empty;

        /// <summary>True if the user is using an Avatar as their profile picture, false if</summary>
        [JsonProperty(PropertyName = "is_avatar_profile_picture", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAvatarProfilePicture { get; set; } = null;

        /// <summary>Id of the tok's tile sticker</summary>
        [JsonProperty(PropertyName = "sticker", NullValueHandling = NullValueHandling.Ignore)]
        public string Sticker { get; set; } = string.Empty;

        /// <summary>Url of the tok's tile sticker image</summary>
        [JsonProperty(PropertyName = "sticker_image", NullValueHandling = NullValueHandling.Ignore)]
        public string StickerImage { get; set; } = string.Empty;
        #endregion

        [JsonProperty(PropertyName = "tok_group")]
        public string TokGroup { get; set; }

        [JsonProperty(PropertyName = "tok_type")]
        public string TokType { get; set; }

        [JsonProperty(PropertyName = "tok_type_id")]
        public string TokTypeId { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "category_id")]
        public string CategoryId { get; set; }

        [JsonProperty(PropertyName = "primary_name")]
        public string PrimaryFieldName { get; set; }

        [JsonProperty(PropertyName = "primary_text")]
        public string PrimaryFieldText { get; set; }

        [JsonProperty(PropertyName = "secondary_name")]
        public string SecondaryFieldName { get; set; }

        [JsonProperty(PropertyName = "secondary_text", NullValueHandling = NullValueHandling.Ignore)]
        public string SecondaryFieldText { get; set; }

        [JsonIgnore]
        public int PrimaryFieldLimit { get; set; }

        [JsonIgnore]
        public int SecondaryFieldLimit { get; set; }

        [JsonProperty(PropertyName = "details", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Details { get; set; } = null;

        [JsonProperty(PropertyName = "details_images", NullValueHandling = NullValueHandling.Ignore)]
        public string[] DetailsImages { get; set; } = null;

        [JsonProperty("language")]
        public string Language { get; set; } = "english";

        [JsonProperty(PropertyName = "english_primary_text", NullValueHandling = NullValueHandling.Ignore)]
        public string EnglishPrimaryFieldText { get; set; }

        [JsonProperty(PropertyName = "english_secondary_text", NullValueHandling = NullValueHandling.Ignore)]
        public string EnglishSecondaryFieldText { get; set; }

        [JsonProperty(PropertyName = "english_details", NullValueHandling = NullValueHandling.Ignore)]
        public string[] EnglishDetails { get; set; } = null;

        [JsonProperty(PropertyName = "required_field_values", NullValueHandling = NullValueHandling.Ignore)]
        public string[] RequiredFieldValues { get; set; } = null;

        [JsonProperty(PropertyName = "optional_field_values", NullValueHandling = NullValueHandling.Ignore)]
        public string[] OptionalFieldValues { get; set; } = null;

        [JsonIgnore]
        public string[] RequiredFields { get; set; } = new string[0];

        [JsonIgnore]
        public string[] OptionalFields { get; set; } = new string[0];

        [JsonProperty(PropertyName = "notes", NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; set; } = null;

        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; } = null;

        [JsonProperty(PropertyName = "is_detail_based")]
        public bool IsDetailBased { get; set; }

        [JsonProperty(PropertyName = "is_english")]
        public bool IsEnglish { get; set; } = true;

        [JsonProperty(PropertyName = "is_replicated")]
        public bool IsReplicated { get; set; }

        [JsonProperty(PropertyName = "is_edited")]
        public bool IsEdited { get; set; }

        [JsonProperty(PropertyName = "is_global")]
        public bool IsGlobal { get; set; } = true;

        [JsonProperty(PropertyName = "verified")]
        public bool IsVerified { get; set; } = false;

        #region Answer field (Only for Test)
        [JsonProperty(PropertyName = "has_answer_field", NullValueHandling = NullValueHandling.Ignore)]
        public bool HasAnswerField { get; set; }

        [JsonProperty(PropertyName = "answer_field_number", NullValueHandling = NullValueHandling.Ignore)]
        public int AnswerFieldNumber { get; set; }
        #endregion

        #region Statistics
        //Statistics

        [JsonProperty(PropertyName = "reactions", NullValueHandling = NullValueHandling.Ignore)]
        public long? Reactions { get; set; } = null;

        [JsonProperty(PropertyName = "users_reacted", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsersReacted { get; set; } = null;

        [JsonProperty(PropertyName = "coins", NullValueHandling = NullValueHandling.Ignore)]
        public long? Coins { get; set; } = null;

        [JsonProperty(PropertyName = "likes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Likes { get; set; } = null;

        //[JsonProperty(PropertyName = "dislikes", NullValueHandling = NullValueHandling.Ignore)]
        //public long? Dislikes { get; set; } = null;

        [JsonProperty(PropertyName = "accurates", NullValueHandling = NullValueHandling.Ignore)]
        public long? Accurates { get; set; } = null;

        [JsonProperty(PropertyName = "inaccurates", NullValueHandling = NullValueHandling.Ignore)]
        public long? Inaccurates { get; set; } = null;

        [JsonProperty(PropertyName = "comments", NullValueHandling = NullValueHandling.Ignore)]
        public long? Comments { get; set; } = null;

        [JsonProperty(PropertyName = "accurates_details", NullValueHandling = NullValueHandling.Ignore)]
        public long[] AccuratesDetails { get; set; } = null;

        [JsonProperty(PropertyName = "inaccurates_details", NullValueHandling = NullValueHandling.Ignore)]
        public long[] InaccuratesDetails { get; set; } = null;

        [JsonProperty(PropertyName = "comments_details", NullValueHandling = NullValueHandling.Ignore)]
        public long[] CommentsDetails { get; set; } = null;

        [JsonProperty(PropertyName = "reports", NullValueHandling = NullValueHandling.Ignore)]
        public long? Reports { get; set; } = null;

        [JsonProperty(PropertyName = "shares", NullValueHandling = NullValueHandling.Ignore)]
        public long? Shares { get; set; } = null;

        [JsonProperty(PropertyName = "views", NullValueHandling = NullValueHandling.Ignore)]
        public long? Views { get; set; } = null;

        #endregion

        [JsonIgnore] DateTime createdTime = DateTime.Now;
        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime
        {
            get { return createdTime; }
            set
            {
                RelativeTime = DateConvert.ConvertToRelative(value);
                createdTime = value;
            }
        }

        [JsonIgnore]
        public string RelativeTime { get; set; }

        //DataTime format
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        //Unix time format
        [JsonProperty(PropertyName = "_ts")]
        public int _Timestamp { get; set; }

        [JsonIgnore]
        public Set[] Sets { get; set; }

        [JsonProperty("latest_reactions", NullValueHandling = NullValueHandling.Ignore)]
        public TokkepediaReactions LatestReactions { get; set; } = null;

        [JsonProperty("own_reactions", NullValueHandling = NullValueHandling.Ignore)]
        public TokkepediaReactions OwnReactions { get; set; } = null;

        [JsonIgnore]
        public string ColorHex { get; set; }
    }

    public class TokkepediaReactions
    {
        [JsonProperty("like")]
        public List<TokkepediaReaction> Likes { get; set; }

        [JsonProperty("dislike")]
        public List<TokkepediaReaction> Dislikes { get; set; }

        [JsonProperty("accurate")]
        public List<TokkepediaReaction> Accurates { get; set; }

        [JsonProperty("inaccurate")]
        public List<TokkepediaReaction> Inaccurates { get; set; }

        [JsonProperty("comment")]
        public List<TokkepediaReaction> Comments { get; set; }

        #region Details
        [JsonProperty("accurate1")]
        public List<TokkepediaReaction> AccuratesDetail1 { get; set; }

        [JsonProperty("inaccurate1")]
        public List<TokkepediaReaction> InaccuratesDetail1 { get; set; }

        [JsonProperty("comment1")]
        public List<TokkepediaReaction> CommentsDetail1 { get; set; }

        [JsonProperty("accurate2")]
        public List<TokkepediaReaction> AccuratesDetail2 { get; set; }

        [JsonProperty("inaccurate2")]
        public List<TokkepediaReaction> InaccuratesDetail2 { get; set; }

        [JsonProperty("comment2")]
        public List<TokkepediaReaction> CommentsDetail2 { get; set; }

        [JsonProperty("accurate3")]
        public List<TokkepediaReaction> AccuratesDetail3 { get; set; }

        [JsonProperty("inaccurate3")]
        public List<TokkepediaReaction> InaccuratesDetail3 { get; set; }

        [JsonProperty("comment3")]
        public List<TokkepediaReaction> CommentsDetail3 { get; set; }

        [JsonProperty("accurate4")]
        public List<TokkepediaReaction> AccuratesDetail4 { get; set; }

        [JsonProperty("inaccurate4")]
        public List<TokkepediaReaction> InaccuratesDetail4 { get; set; }

        [JsonProperty("comment4")]
        public List<TokkepediaReaction> CommentsDetail4 { get; set; }

        [JsonProperty("accurate5")]
        public List<TokkepediaReaction> AccuratesDetail5 { get; set; }

        [JsonProperty("inaccurate5")]
        public List<TokkepediaReaction> InaccuratesDetail5 { get; set; }

        [JsonProperty("comment5")]
        public List<TokkepediaReaction> CommentsDetail5 { get; set; }
        #endregion
    }
}
