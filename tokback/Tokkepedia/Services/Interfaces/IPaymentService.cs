using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Models.ViewModels;

namespace Tokkepedia.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> CompletePayment(TransactionViewModel model);
    }
}
