using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
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
    public class CommonService : ICommonService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApiSettingsViewModel _apiSettings;

        public CommonService(IHttpContextAccessor httpContextAccessor, HttpClient client, IOptions<ApiSettingsViewModel> options)
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

        public async Task<ResultData<TokketUser>> SearchUsersAsync(string text)
        {
            _httpClient.DefaultRequestHeaders.Add("text", text);
            var apiUrl = $"{_apiSettings.ApiPrefix}/searchusers{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<ResultData<TokketUser>>();
        }

        public async Task<ResultData<Category>> SearchCategoriesAsync(string text)
        {
            _httpClient.DefaultRequestHeaders.Add("text", text);
            var apiUrl = $"{_apiSettings.ApiPrefix}/searchcategories{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<ResultData<Category>>();
        }

        public async Task<bool> AddRecentSearchAsync(string text)
        {
            _httpClient.DefaultRequestHeaders.Add("text", text);
            var apiUrl = $"{_apiSettings.ApiPrefix}/searchesaddrecent/{_httpContextAccessor.HttpContext.User.GetUserId()}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, new UserSearches());
            return response.IsSuccessStatusCode;
        }

        public async Task<UserSearches> GetRecentSearchesAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/searchesgetrecent/{_httpContextAccessor.HttpContext.User.GetUserId()}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<UserSearches>();
        }
    }
}
