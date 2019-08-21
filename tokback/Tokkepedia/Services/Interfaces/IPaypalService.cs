using BraintreeHttp;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Services.Interfaces
{
    public interface IPaypalService
    {
        Task<Order> OrderProduct(string productId, string userId);
    }
}
