using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Tools;
using Tokkepedia.Tools.Helpers;

namespace Tokkepedia.Models
{
    public class NotficationQueryValues
    {
        public int limit = 20;
        public string pagination_id = "";
        public string userid = "";
        public string token = "";
        public string streamtoken = "";
    }
}
