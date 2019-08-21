using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class BrowseViewModel
    {
        public List<TokTypeList> TokGroups { get; set; }
        public List<string> TokTypes { get; set; }
        public List<TokTypeListCounter> Counters { get; set; }
    }
}
