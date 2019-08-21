using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class UserPlatformPointsViewModel
    {
        public ApplicationUser User { get; set; }
        public long TotalPoints { get; set; }
        public long TokkepediaPoints { get; set; }
        public long TokketPoints { get; set; }
        public long TokGamePoints { get; set; }
    }
}
