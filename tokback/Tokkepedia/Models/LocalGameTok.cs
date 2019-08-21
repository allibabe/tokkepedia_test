using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models
{
    public class LocalGameTok
    {
        public int id { get; set; }
        public string tok_group { get; set; }
        public string tok_type { get; set; }
        public string primary_text { get; set; }
        public string secondary_text { get; set; }
        public string certified { get; set; }
        public string category { get; set; }
        public string location { get; set; }
    }
}
