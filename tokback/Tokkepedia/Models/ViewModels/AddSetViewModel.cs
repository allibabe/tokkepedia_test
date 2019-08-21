using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class AddSetViewModel
    {
        public Set Set { get; set; }
        public List<TokTypeList> TokGroups { get; set; }
        public string TokGroupDataString { get; set; }
        public string Base64Image { get; set; }

        //public bool IsReplicate { get; set; }
        //public bool IsEdit { get; set; }

        public TokTypeList TokGroup { get; set; }
    }
}
