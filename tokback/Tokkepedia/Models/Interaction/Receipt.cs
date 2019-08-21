using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models
{
    public class WebReceipt
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string BundleId { get; set; } = "tokkepedia.com";
        public string TransactionId { get; set; } //Order Id
    }
}
