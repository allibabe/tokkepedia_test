using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
namespace Tokkepedia.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class TokketUser : IdentityUser
    {
        [JsonProperty(PropertyName = "id")]
        public override string Id { get; set; }

        [JsonIgnore]
        public string IdToken { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }


        [JsonRequired]
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; } = "user";

        [JsonIgnore]
        public override string UserName { get; set; } = "";

        [JsonIgnore]
        public override string NormalizedUserName { get; set; } = "";

        public override string Email { get; set; } = "";

        [JsonIgnore]
        public override string NormalizedEmail { get; set; } = "";

        public override string PasswordHash { get; set; } = "";

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "user_photo")]
        public string UserPhoto { get; set; }

        [JsonProperty(PropertyName = "cover_photo")]
        public string CoverPhoto { get; set; }

        [JsonProperty(PropertyName = "bio")]
        public string Bio { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

        #region Birthday
        [JsonProperty(PropertyName = "birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty(PropertyName = "birthdate")]
        public string BirthDate { get; set; }

        [JsonProperty(PropertyName = "birth_year")]
        public int BirthYear { get; set; }

        [JsonProperty(PropertyName = "birth_month")]
        public int BirthMonth { get; set; }

        [JsonProperty(PropertyName = "birth_day")]
        public int BirthDay { get; set; }
        #endregion

        [JsonProperty(PropertyName = "joined")]
        public DateTime Joined { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; } = null;

        [JsonProperty(PropertyName = "is_locked_out")]
        public bool IsLockedOut { get; set; } = false;

        #region Accessories

        #region Avatars
        /// <summary>Id of the user's selected avatar</summary>
        [JsonProperty(PropertyName = "selected_avatar", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedAvatar { get; set; } = null;

        /// <summary>Id of the user's favorite avatar</summary>
        [JsonProperty(PropertyName = "favorite_avatar", NullValueHandling = NullValueHandling.Ignore)]
        public string FavoriteAvatar { get; set; } = null;

        /// <summary>True if the user is using an Avatar as their profile picture, false if</summary>
        [JsonProperty(PropertyName = "is_avatar_profile_picture", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAvatarProfilePicture { get; set; } = null;
        #endregion

        #region Tokmoji
        /// <summary>Id of the user's favorite tokmoji</summary>
        [JsonProperty(PropertyName = "favorite_tokmoji", NullValueHandling = NullValueHandling.Ignore)]
        public string FavoriteTokmoji { get; set; } = null;

        /// <summary>Replaces all Tokmoji on the site with ♦ {text here} ♦</summary>
        [JsonProperty(PropertyName = "is_tokmoji_disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsTokmojiDisabled { get; set; } = null;
        #endregion

        #endregion

        #region User counter
        [JsonProperty("toks", NullValueHandling = NullValueHandling.Ignore)]
        public long? Toks { get; set; } = null;

        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public long? Points { get; set; } = null;

        [JsonProperty("coins", NullValueHandling = NullValueHandling.Ignore)]
        public long? Coins { get; set; } = null;

        [JsonProperty("strikes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Strikes { get; set; } = null;

        [JsonProperty("sets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sets { get; set; } = null;

        [JsonProperty("deleted_toks", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedToks { get; set; } = null;

        [JsonProperty("deleted_points", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedPoints { get; set; } = null;

        [JsonProperty("deleted_coins", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedCoins { get; set; } = null;

        [JsonProperty("deleted_strikes", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedStrikes { get; set; } = null;

        [JsonProperty("deleted_sets", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedSets { get; set; } = null;

        #region Reactions
        [JsonProperty(PropertyName = "reactions", NullValueHandling = NullValueHandling.Ignore)]
        public long? Reactions { get; set; } = null;

        [JsonProperty(PropertyName = "deleted_reactions", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedReactions { get; set; } = null;

        [JsonProperty(PropertyName = "likes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Likes { get; set; } = null;

        [JsonProperty(PropertyName = "dislikes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Dislikes { get; set; } = null;

        [JsonProperty(PropertyName = "accurates", NullValueHandling = NullValueHandling.Ignore)]
        public long? Accurates { get; set; } = null;

        [JsonProperty(PropertyName = "inaccurates", NullValueHandling = NullValueHandling.Ignore)]
        public long? Inaccurates { get; set; } = null;

        [JsonProperty(PropertyName = "comments", NullValueHandling = NullValueHandling.Ignore)]
        public long? Comments { get; set; } = null;

        [JsonProperty(PropertyName = "reports", NullValueHandling = NullValueHandling.Ignore)]
        public long? Reports { get; set; } = null;

        [JsonProperty(PropertyName = "deleted_likes", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedLikes { get; set; } = null;

        [JsonProperty(PropertyName = "deleted_dislikes", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedDislikes { get; set; } = null;

        [JsonProperty(PropertyName = "deleted_accurates", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedAccurates { get; set; } = null;

        [JsonProperty(PropertyName = "deleted_inaccurates", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedInaccurates { get; set; } = null;

        [JsonProperty(PropertyName = "deleted_comments", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedComments { get; set; } = null;

        [JsonProperty(PropertyName = "followers", NullValueHandling = NullValueHandling.Ignore)]
        public long? Followers { get; set; } = null;

        [JsonProperty(PropertyName = "following", NullValueHandling = NullValueHandling.Ignore)]
        public long? Following { get; set; } = null;

        [JsonProperty(PropertyName = "deleted_followers", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedFollowers { get; set; } = null;

        [JsonProperty(PropertyName = "deleted_following", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeletedFollowing { get; set; } = null;
        #endregion
        //---
        #endregion

        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        //DataTime format
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        //Unix time format
        [JsonProperty(PropertyName = "_ts")]
        public int _Timestamp { get; set; }

        [JsonProperty(PropertyName = "pk")]
        public string PartitionKey { get; set; }
    }


}
