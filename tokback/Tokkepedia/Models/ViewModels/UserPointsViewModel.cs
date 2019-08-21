using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class UserPointsViewModel
    {
        public List<TokTypeList> TokGroups { get; set; }
        public List<string> TokTypes { get; set; }
        public TokTypeListUserCounter[] Counters { get; set; }
        public ApplicationUser User { get; set; }
    }
}
