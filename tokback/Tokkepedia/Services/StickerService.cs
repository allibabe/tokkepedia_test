using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tokkepedia.Models;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools.Extensions;

namespace Tokkepedia.Services
{
    public class StickerService : IStickerService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApiSettingsViewModel _apiSettings;

        public StickerService(IHttpContextAccessor httpContextAccessor, HttpClient client, IOptions<ApiSettingsViewModel> options)
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

        /// <summary>Gets all stickers available for purchase. Used for the Stickers Shop</summary>
        public async Task<List<Sticker>> GetStickersAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/stickers{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultData<Sticker>>(content);
            return result.Results;
        }

        /// <summary>Gets all stickers purchased by a user. Used in add/change/remove sticker in a tok, and also the user sticker inventory page</summary>
        public async Task<List<PurchasedSticker>> GetStickersUserAsync(string userId)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/stickersuser/{userId}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultData<PurchasedSticker>>(content);
            return result.Results;
        }

        /// <summary>Adds a tok sticker or changes the existing one. Works as both an add and update function</summary>
        public async Task<bool> AddStickerToTokAsync(string tokId, string newStickerId)
        {
            if (_httpContextAccessor.HttpContext.User == null)
                throw new UnauthorizedAccessException();

            var apiUrl = $"{_apiSettings.ApiPrefix}/stickertokupdate/{tokId}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(apiUrl, newStickerId).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <summary>Removes a tok sticker</summary>
        public async Task<bool> RemoveStickerFromAsync(string tokId, string stickerId)
        {
            if (_httpContextAccessor.HttpContext.User == null)
                throw new UnauthorizedAccessException();

            var apiUrl = $"{_apiSettings.ApiPrefix}/stickertokupdate/{tokId}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(apiUrl, stickerId).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <summary>Purchases a sticker for a user</summary>
        public async Task<bool> PurchaseStickerAsync(string stickerId)
        {
            if (_httpContextAccessor.HttpContext.User == null)
                throw new UnauthorizedAccessException();

            _httpClient.DefaultRequestHeaders.Add("deviceplatform", "web");
            var apiUrl = $"{_apiSettings.ApiPrefix}/purchasecoins/{stickerId}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, stickerId).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}
