using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class UserCoinsViewModel
    {
        public ApplicationUser User { get; set; }
        public long Coins { get; set; }
    }
}
