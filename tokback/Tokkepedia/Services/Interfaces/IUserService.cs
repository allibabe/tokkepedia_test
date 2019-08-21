using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Models;

namespace Tokkepedia.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(TokketUser item);
        Task<TokketUser> GetUserAsync(string id);
        Task<bool> UpdateUserAsync(TokketUser item);
        Task<bool> DeleteUserAsync(string id);
        Task<FirebaseAuthLink> SignUpAsync(string email, string password, string displayName, string country, DateTime date, string userPhoto);
        Task<FirebaseAuthLink> LoginEmailPasswordAsync(string email, string password);
        Task<FirebaseAuthLink> LoginOAuthAsync(string providerName, string token);
        Task<bool> SendPasswordResetAsync(string email);
        Task<FirebaseAuthLink> LinkAccountsAsync(string token, string email, string password);
        Task<bool> CreateFollowAsync(TokkepediaFollow item);
        Task<TokkepediaFollow> GetFollowAsync(string id);
        Task<bool> UpdateFollowAsync(TokkepediaFollow tok);
        Task<string> UploadImageAsync(string base64);
        Task<string> UploadProfilePictureAsync(string base64);
        Task<string> UploadProfileCoverAsync(string base64);
        Task<bool> UpdateUserBioAsync(string bio);
        Task<bool> UpdateUserWebsiteAsync(string website);
        Task<bool> UseAvatarAsProfilePictureAsync(bool isAvatarProfilePicture);
        Task<bool> UserSelectAvatarAsync(string avatarId);
        Task<bool> UserFavoriteAvatarAsync(string avatarId);
    }
}
