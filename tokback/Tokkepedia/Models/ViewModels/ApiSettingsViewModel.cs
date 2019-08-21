using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class ApiSettingsViewModel
    {
        public string BaseUrl { get; set; }
        public string CodePrefix { get; set; }
        public string ApiPrefix { get; set; }
        public string ApiKey { get; set; }
    }
}
