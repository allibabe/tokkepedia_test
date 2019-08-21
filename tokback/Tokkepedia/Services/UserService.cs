using Firebase.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tokkepedia.Models;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools.Extensions;

namespace Tokkepedia.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApiSettingsViewModel _apiSettings;

        public UserService(IHttpContextAccessor httpContextAccessor, HttpClient client, IOptions<ApiSettingsViewModel> options)
        {
            _httpContextAccessor = httpContextAccessor;
            _apiSettings = options.Value;

            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            if (_httpContextAccessor.HttpContext.User != null)
            {
                if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    var userid = _httpContextAccessor.HttpContext.User.GetUserId();
                    var idToken = _httpContextAccessor.HttpContext.User.GetToken();
                    var streamToken = _httpContextAccessor.HttpContext.User.GetStreamToken();

                    client.DefaultRequestHeaders.Add("userid", userid);
                    client.DefaultRequestHeaders.Add("token", idToken);
                    client.DefaultRequestHeaders.Add("streamtoken", streamToken);
                }
            }

            _httpClient = client;
        }

        public async Task<bool> CreateUserAsync(TokketUser item)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/user/{item.Id}"; // Api Method to Call with values
            apiUrl += $"{_apiSettings.CodePrefix}{_apiSettings.ApiKey}"; // Add Suffix for API
            return (await _httpClient.PostAsJsonAsync(apiUrl, item)).IsSuccessStatusCode;
        }

        public async Task<TokketUser> GetUserAsync(string id)
        {
            var apiUrl = new Uri($"{_apiSettings.BaseUrl}{_apiSettings.ApiPrefix}/user/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}"); // Api Method to Call with values
            var item = await _httpClient.GetAsync(apiUrl);
            return JsonConvert.DeserializeObject<TokketUser>(await item.Content.ReadAsStringAsync());
        }

        public async Task<bool> UpdateUserAsync(TokketUser item)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/user/{item.Id}"; // Api Method to Call with values
            apiUrl += $"{_apiSettings.CodePrefix}{_apiSettings.ApiKey}"; // Add Suffix for API
            return (await _httpClient.PutAsJsonAsync(apiUrl, item)).IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/user/{id}"; // Api Method to Call with values
            apiUrl += $"{_apiSettings.CodePrefix}{_apiSettings.ApiKey}"; // Add Suffix for API
            return (await _httpClient.DeleteAsync(apiUrl)).IsSuccessStatusCode;
        }

        public async Task<FirebaseAuthLink> SignUpAsync(string email, string password, string displayName, string country, DateTime date, string userPhoto)
        {
            TokketUser user = new TokketUser() { Email = email, PasswordHash = password, DisplayName = displayName, Country = country, Birthday = date, UserPhoto = userPhoto };
            user.BirthDate = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month)} {date.Day}";
            user.BirthYear = date.Year;
            user.BirthMonth = date.Month;
            user.BirthDay = date.Day;

            var apiUrl = $"{_apiSettings.ApiPrefix}/signup"; // Api Method to Call with values
            apiUrl += $"{_apiSettings.CodePrefix}{_apiSettings.ApiKey}"; // Add Suffix for API

            var res = await _httpClient.PostAsJsonAsync(apiUrl, user);
            return JsonConvert.DeserializeObject<FirebaseAuthLink>(await res.Content.ReadAsStringAsync());
        }

        public async Task<FirebaseAuthLink> LoginEmailPasswordAsync(string email, string password)
        {
            TokketUser user = new TokketUser() { Email = email, PasswordHash = password };
            var apiUrl = $"{_apiSettings.ApiPrefix}/login"; // Api Method to Call with values
            apiUrl += $"{_apiSettings.CodePrefix}{_apiSettings.ApiKey}"; // Add Suffix for API
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, user);
            return JsonConvert.DeserializeObject<FirebaseAuthLink>(await response.Content.ReadAsStringAsync());
        }

        public async Task<FirebaseAuthLink> LoginOAuthAsync(string providerName, string token)
        {
            _httpClient.DefaultRequestHeaders.Add("providerName", providerName);
            _httpClient.DefaultRequestHeaders.Add("token", token);
            var apiUrl = $"{_apiSettings.ApiPrefix}/loginoauth"; // Api Method to Call with values
            apiUrl += $"{_apiSettings.CodePrefix}{_apiSettings.ApiKey}"; // Add Suffix for API
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            var res = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FirebaseAuthLink>(res);
        }

        public async Task<bool> SendPasswordResetAsync(string email)
        {
            _httpClient.DefaultRequestHeaders.Add("email", email);
            var apiUrl = $"{_apiSettings.ApiPrefix}/sendpasswordreset"; // Api Method to Call with values
            apiUrl += $"{_apiSettings.CodePrefix}{_apiSettings.ApiKey}"; // Add Suffix for API
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, email);
            return response.IsSuccessStatusCode;
        }

        /// <summary>  
        ///  Links Facebook/Google login with an Email and Password
        /// </summary>  
        public async Task<FirebaseAuthLink> LinkAccountsAsync(string token, string email, string password)
        {
            TokketUser user = new TokketUser() { Email = email, PasswordHash = password };
            _httpClient.DefaultRequestHeaders.Add("email", email);
            _httpClient.DefaultRequestHeaders.Add("password", password);
            _httpClient.DefaultRequestHeaders.Add("token", token);
            var apiUrl = $"{_apiSettings.ApiPrefix}/linkaccounts"; // Api Method to Call with values
            apiUrl += $"{_apiSettings.CodePrefix}{_apiSettings.ApiKey}"; // Add Suffix for API
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, user);
            return await response.Content.ReadAsAsync<FirebaseAuthLink>();
        }

        public async Task<bool> CreateFollowAsync(TokkepediaFollow item)
        {
            var apiUrl = new Uri($"{_apiSettings.ApiPrefix}/follow/{item.Id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}", UriKind.Relative);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, item);
            return response.IsSuccessStatusCode;
        }

        public async Task<TokkepediaFollow> GetFollowAsync(string id)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/follow/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<TokkepediaFollow>();
        }

        public async Task<bool> UpdateFollowAsync(TokkepediaFollow tok)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/follow/{tok.Id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(apiUrl, tok);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateUserBioAsync(string bio)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/userbio{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, bio);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateUserWebsiteAsync(string website)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/userwebsite{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, website);
            return response.IsSuccessStatusCode;
        }

        #region Image
        public async Task<string> UploadImageAsync(string base64)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/image{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, base64);
            return await response.Content.ReadAsAsync<string>();
        }

        public async Task<string> UploadProfilePictureAsync(string base64)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/profilepicture{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, base64);
            return await response.Content.ReadAsAsync<string>();
        }

        public async Task<string> UploadProfileCoverAsync(string base64)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/profilecover{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, base64);
            return await response.Content.ReadAsAsync<string>();
        }
        #endregion

        #region Accessory (Avatars, Tokmoji)
        public async Task<bool> UseAvatarAsProfilePictureAsync(bool isAvatarProfilePicture)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/avataruseasprofilepicture{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, isAvatarProfilePicture);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UserSelectAvatarAsync(string avatarId)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/avataruserselect{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, avatarId);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UserFavoriteAvatarAsync(string avatarId)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/avataruserfavorite{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, avatarId);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
