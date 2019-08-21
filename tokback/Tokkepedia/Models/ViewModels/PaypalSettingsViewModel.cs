using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class PaypalSettingsViewModel
    {
        public string ClientId { get; set; }
        public string SecretKey { get; set; }
        public bool IsSandbox { get; set; }
    }
}
