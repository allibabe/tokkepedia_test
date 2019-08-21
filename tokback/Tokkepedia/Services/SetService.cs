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
    public class SetService : ISetService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApiSettingsViewModel _apiSettings;

        public SetService(IHttpContextAccessor httpContextAccessor, HttpClient client, IOptions<ApiSettingsViewModel> options)
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

        public async Task<bool> CreateSetAsync(Set set)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/set{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, set);
            return response.IsSuccessStatusCode;
        }

        public async Task<Set> GetSetAsync(string id)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/set/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<Set>();
        }

        public async Task<bool> UpdateSetAsync(Set set)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/set/{set.Id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(apiUrl, set);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteSetAsync(string id)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/set/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.DeleteAsync(apiUrl);
            return response.IsSuccessStatusCode;
        }

        public async Task<ResultData<Set>> GetSetsAsync(SetQueryValues values = null)
        {
            if (values == null)
                values = new SetQueryValues();

            _httpClient.DefaultRequestHeaders.Remove("userid"); // Remove default
            _httpClient.DefaultRequestHeaders.Remove("token"); // Remove default

            _httpClient.DefaultRequestHeaders.Add("order", values?.order);
            _httpClient.DefaultRequestHeaders.Add("offset", values.offset.ToString());
            //_httpClient.DefaultRequestHeaders.Add("category", values?.category);
            //_httpClient.DefaultRequestHeaders.Add("toktype", values?.toktype);
            _httpClient.DefaultRequestHeaders.Add("userid", values?.userid);
            _httpClient.DefaultRequestHeaders.Add("text", values?.text);
            _httpClient.DefaultRequestHeaders.Add("loadmore", values?.loadmore);
            _httpClient.DefaultRequestHeaders.Add("token", values?.token);
            var apiUrl = $"{_apiSettings.ApiPrefix}/sets{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<ResultData<Set>>();
        }

        public async Task<ResultData<Set>> GetGameSetsAsync(SetQueryValues values = null)
        {
            if (values == null)
                values = new SetQueryValues();

            _httpClient.DefaultRequestHeaders.Remove("userid"); // Remove default
            _httpClient.DefaultRequestHeaders.Remove("token"); // Remove default

            _httpClient.DefaultRequestHeaders.Add("order", values?.order);
            _httpClient.DefaultRequestHeaders.Add("offset", values.offset.ToString());
            //_httpClient.DefaultRequestHeaders.Add("category", values?.category);
            //_httpClient.DefaultRequestHeaders.Add("toktype", values?.toktype);
            _httpClient.DefaultRequestHeaders.Add("userid", values?.userid);
            _httpClient.DefaultRequestHeaders.Add("text", values?.text);
            _httpClient.DefaultRequestHeaders.Add("loadmore", values?.loadmore);
            _httpClient.DefaultRequestHeaders.Add("token", values?.token);
            var apiUrl = $"{_apiSettings.ApiPrefix}/gamesets{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<ResultData<Set>>();
        }

        public async Task<bool> AddTokToSetAsync(string setId, string setUserId, string tokId)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/setaddtok/{setId}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(apiUrl, tokId);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTokFromSetAsync(string setId, string setUserId, string tokId)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/setdeletetok/{setId}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(apiUrl, tokId);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddToksToSetAsync(string setId, string setUserId, string[] tokIds)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/setaddtoks/{setId}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(apiUrl, tokIds);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteToksFromSetAsync(Set set, string[] tokIds)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/setdeletetoks/{set.Id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(apiUrl, tokIds);
            return response.IsSuccessStatusCode;
        }
    }
}
