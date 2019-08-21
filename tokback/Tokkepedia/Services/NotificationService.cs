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
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApiSettingsViewModel _apiSettings;

        public NotificationService(IHttpContextAccessor httpContextAccessor, HttpClient client, IOptions<ApiSettingsViewModel> options)
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

        public async Task<TokkepediaNotificationSet> GetNotificationsAsync(string id, NotficationQueryValues values = null)
        {
            if (values == null)
                values = new NotficationQueryValues();
            
            _httpClient.DefaultRequestHeaders.Add("pagination_id", values?.pagination_id);
            _httpClient.DefaultRequestHeaders.Add("limit", values.limit.ToString());

            var apiUrl = $"{_apiSettings.ApiPrefix}/notifications/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            var data = await response.Content.ReadAsAsync<TokkepediaNotificationSet>();
            return data;
        }

        //Use the id from TokkepediaNotification
        public async Task<bool> MarkAsReadAsync(string id)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/markasread/{id}{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<string>(apiUrl, id);
            return response.IsSuccessStatusCode;
        }

        //Use the ids from TokkepediaNotification
        public async Task<bool> RemoveNotificationsAsync(string[] ids)
        {
            var apiUrl = $"{_apiSettings.ApiPrefix}/notifications{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, ids);
            return response.IsSuccessStatusCode;
        }
    }
}
