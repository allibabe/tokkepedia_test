using BraintreeHttp;
using Microsoft.Extensions.Options;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Tokkepedia.Models;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools.Helpers;

namespace Tokkepedia.Services
{
    public class PaypalService : IPaypalService
    {
        private PayPalEnvironment _payPalEnvironment;
        private HttpClient _httpClient;

        public PaypalService(IOptions<PaypalSettingsViewModel> options)
        {
            if(options.Value.IsSandbox)
            {
                _payPalEnvironment = new SandboxEnvironment(options.Value.ClientId, options.Value.SecretKey);
            }
            else
            {

            }

            _httpClient = new PayPalHttpClient(_payPalEnvironment);
        }

        public async Task<Order> OrderProduct(string productId, string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return null;
            var product = PurchasesTool.GetProduct(productId);
            var purchaseRequest = new OrdersCreateRequest();
            purchaseRequest.Prefer("return=representation");
            purchaseRequest.RequestBody(product.GetOrderRequest(userId));
            return (await _httpClient.Execute(purchaseRequest)).Result<Order>();
        }

        ///**
        //    Use this method to serialize Object to a JSON string.
        //*/
        //public static String ObjectToJSONString(Object serializableObject)
        //{
        //    MemoryStream memoryStream = new MemoryStream();
        //    var writer = JsonReaderWriterFactory.CreateJsonWriter(
        //                memoryStream, Encoding.UTF8, true, true, "  ");
        //    DataContractJsonSerializer ser = new DataContractJsonSerializer(serializableObject.GetType(), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
        //    ser.WriteObject(writer, serializableObject);
        //    memoryStream.Position = 0;
        //    StreamReader sr = new StreamReader(memoryStream);
        //    return sr.ReadToEnd();
        //}
    }
}
