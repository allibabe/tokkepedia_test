using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class TransactionViewModel
    {
        public string UserId { get; set; }
        public Order TransactionDetails { get; set; }
    }
}
