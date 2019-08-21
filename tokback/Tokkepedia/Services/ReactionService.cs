using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tokkepedia.Models;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools.Extensions;

namespace Tokkepedia.Services
{
    public class ReactionService : IReactionService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApiSettingsViewModel _apiSettings;

        public ReactionService(IHttpContextAccessor httpContextAccessor, HttpClient client, IOptions<ApiSettingsViewModel> options)
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

        public async Task<bool> AddReaction(TokkepediaReaction item)
        {
            _httpClient.DefaultRequestHeaders.Remove("streamtoken"); // Remove Default
            _httpClient.DefaultRequestHeaders.Add("itemid", item.ItemId);

            var apiUrl = $"{_apiSettings.ApiPrefix}/reaction{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateReaction(string id, TokkepediaReaction item)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/reaction/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(apiUrl, item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteReaction(string id)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/reaction/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.DeleteAsync(apiUrl);
            return response.IsSuccessStatusCode;
        }

        public async Task<ResultData<TokkepediaReaction>> GetReactionsAsync(ReactionQueryValues values = null)
        {
            if (values == null)
                values = new ReactionQueryValues();

            _httpClient.DefaultRequestHeaders.Add("limit", values?.limit.ToString());
            _httpClient.DefaultRequestHeaders.Add("kind", values?.kind);
            _httpClient.DefaultRequestHeaders.Add("item_id", values?.item_id);
            _httpClient.DefaultRequestHeaders.Add("activity_id", values?.activity_id);
            _httpClient.DefaultRequestHeaders.Add("user_id", values?.user_id);
            _httpClient.DefaultRequestHeaders.Add("reaction_id", values?.reaction_id);
            _httpClient.DefaultRequestHeaders.Add("pagination_id", values?.pagination_id);
            var apiUrl = $"{_apiSettings.ApiPrefix}/reactions{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            try
            {
                var data = await response.Content.ReadAsAsync<ResultData<TokkepediaReaction>>();

                for (int i = 0; i < data.Results.Count; ++i)
                {
                    if (data.Results[i].UserId == "tokket")
                    {
                        data.Results[i].UserPhoto = "/images/tokket.png";
                    }
                }

                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}
