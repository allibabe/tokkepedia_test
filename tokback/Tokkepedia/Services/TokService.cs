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
using Tokkepedia.Tools;
using Tokkepedia.Tools.Extensions;

namespace Tokkepedia.Services
{
    public class TokService : ITokService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApiSettingsViewModel _apiSettings;

        public TokService(IHttpContextAccessor httpContextAccessor, HttpClient client, IOptions<ApiSettingsViewModel> options)
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

        public async Task<bool> CreateTokAsync(Tok tok)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/tok{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";

            _httpClient.DefaultRequestHeaders.Add("tokgroupid", tok.TokGroup.ToIdFormat());
            _httpClient.DefaultRequestHeaders.Add("toktypeid", tok.TokTypeId);
            _httpClient.DefaultRequestHeaders.Add("categoryid", tok.CategoryId);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, tok);
            return response.IsSuccessStatusCode;
        }

        public async Task<Tok> GetTokAsync(string id)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/tok/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<Tok>();
        }

        public async Task<bool> UpdateTokAsync(Tok tok)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/tok/{tok.Id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(apiUrl, tok);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTokAsync(string id)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/tok/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.DeleteAsync(apiUrl);
            return response.IsSuccessStatusCode;
        }

        public async Task<ResultData<Tok>> GetToksAsync(TokQueryValues values = null)
        {
            if (values == null)
                values = new TokQueryValues();
            
            _httpClient.DefaultRequestHeaders.Remove("userid"); // Remove default
            _httpClient.DefaultRequestHeaders.Remove("token"); // Remove default
            _httpClient.DefaultRequestHeaders.Remove("streamtoken"); // Remove default

            _httpClient.DefaultRequestHeaders.Add("order", values?.order);
            _httpClient.DefaultRequestHeaders.Add("country", values?.country);
            _httpClient.DefaultRequestHeaders.Add("category", values?.category);
            _httpClient.DefaultRequestHeaders.Add("tokgroup", values?.tokgroup);
            _httpClient.DefaultRequestHeaders.Add("toktype", values?.toktype);
            _httpClient.DefaultRequestHeaders.Add("userid", values?.userid);
            _httpClient.DefaultRequestHeaders.Add("text", values?.text);
            _httpClient.DefaultRequestHeaders.Add("loadmore", values?.loadmore);
            _httpClient.DefaultRequestHeaders.Add("token", values?.token);
            _httpClient.DefaultRequestHeaders.Add("streamtoken", values?.streamtoken);
            var apiUrl = new Uri($"{_apiSettings.BaseUrl}{_apiSettings.ApiPrefix}/toks{_apiSettings.CodePrefix}{_apiSettings.ApiKey}");
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            try
            {
                var data = await response.Content.ReadAsAsync<ResultData<Tok>>();

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

        public async Task<ResultData<Tok>> GetToksByIdsAsync(string[] ids)
        {
            if (ids == null)
                return null;

            if (ids.Length > 100)
                return null;

            var apiUrl = $"{_apiSettings.ApiPrefix}/toks{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, ids);

            try
            {
                var data = await response.Content.ReadAsAsync<ResultData<Tok>>();

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

        public async Task<ResultData<Tok>> GetFeaturedToksAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/featuredtoks{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            try
            {
                var data = await response.Content.ReadAsAsync<ResultData<Tok>>();

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

        public async Task<ResultData<Tok>> GetAllFeaturedToksAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/allfeaturedtoks{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            try
            {
                var data = await response.Content.ReadAsAsync<ResultData<Tok>>();

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

        public async Task<ResultData<Tok>> GetUserFeedAsync(int limit, string idLt = null)
        {
            //Id of the final returned item, used for pagination
            _httpClient.DefaultRequestHeaders.Add("id_lt", idLt);

            var apiUrl = $"{_apiSettings.ApiPrefix}/userfeed/{limit}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<ResultData<Tok>>();
        }

        public async Task<ResultData<Tok>> GetToksByIdAsync(List<string> ids)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/toksbyid{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, ids);
            return await response.Content.ReadAsAsync<ResultData<Tok>>();
        }

        public async Task<List<TokTypeList>> GetTokGroupsAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/tokgroups{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<List<TokTypeList>>();
        }

        public async Task<List<TokTypeListCounter>> GetTokGroupCountersAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/tokgroupcounters{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<List<TokTypeListCounter>>();
        }

        public async Task<TokTypeList> GetTokGroupAsync(string id)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/tokgroup/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<TokTypeList>();
        }

        public async Task<TokTypeListCounter> GetTokGroupCounterAsync(string id)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/tokgroupcounter/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<TokTypeListCounter>();
        }

        /// <summary>  
        /// Gets a user tok type counter for a single tok group
        /// </summary>
        public async Task<TokTypeListUserCounter> GetTokGroupUserCounterAsync(string id)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/tokgroupusercounter/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<TokTypeListUserCounter>();
        }

        /// <summary>  
        /// Gets a user's tok type counters for all tok groups
        /// </summary>
        public async Task<List<TokTypeListUserCounter>> GetTokGroupUserCountersAsync(string userId)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/tokgroupusercounters/{userId}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<List<TokTypeListUserCounter>>();
        }

        public async Task<Category> GetCategoryAsync(string id)
        {
            Category cat = null;
            var apiUrl = $"{_apiSettings.ApiPrefix}/category/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Accepted:
                case System.Net.HttpStatusCode.BadRequest:
                case System.Net.HttpStatusCode.Created:
                case System.Net.HttpStatusCode.Forbidden:
                case System.Net.HttpStatusCode.NotFound:
                case System.Net.HttpStatusCode.Unauthorized:
                    cat = new Category() { Id = id };
                    break;
                case System.Net.HttpStatusCode.OK:
                    return await response.Content.ReadAsAsync<Category>();
            }

            return cat;
        }
        
        public async Task<bool> CreateReportAsync(Report item)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/report{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, item);
            return response.IsSuccessStatusCode;
        }

        #region Weekly/Monthly Counts
        public async Task<ResultData<Category>> GetTopCategoriesWeekAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/categoriesweek{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<ResultData<Category>>();
        }

        public async Task<ResultData<Category>> GetTopCategoriesMonthAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/categoriesweek{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<ResultData<Category>>();
        }

        public async Task<ResultData<TokType>> GetTopTokTypesWeekAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/toktypesweek{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<ResultData<TokType>>();
        }

        public async Task<ResultData<TokType>> GetTopTokTypesMonthAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/toktypesmonth{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<ResultData<TokType>>();
        }

        public async Task<ResultData<TokketUser>> GetTopUsersWeekAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/usersweek{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<ResultData<TokketUser>>();
        }
        #endregion

        public async Task<TokkepediaCounter> GetTokkepediaCounterAsync()
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/tokkepediacounter{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsAsync<TokkepediaCounter>();
        }
    }
}
