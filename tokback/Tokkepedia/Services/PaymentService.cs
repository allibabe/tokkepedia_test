using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools.Extensions;

namespace Tokkepedia.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApiSettingsViewModel _apiSettings;

        public PaymentService(IHttpContextAccessor httpContextAccessor, HttpClient client, IOptions<ApiSettingsViewModel> options)
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

        /// <summary>
        ///  Save all information about the transaction of the user logged in
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CompletePayment(TransactionViewModel model)
        {
            if (model.TransactionDetails.Id == null)
                return false;

            //Append website to the end of the Links
            if (model.TransactionDetails.Links == null)
                model.TransactionDetails.Links = new List<LinkDescription>();

            model.TransactionDetails.Links.Add(new LinkDescription() { Title = "tokkepedia.com", Href = "tokkepedia.com" });
            try
            {
                string url = $"{_apiSettings.ApiPrefix}/purchaseweb{_apiSettings.CodePrefix}{_apiSettings.ApiKey}";
                var apiUrl = new Uri(url, UriKind.RelativeOrAbsolute);
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, model.TransactionDetails);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }
        }
    }
}
