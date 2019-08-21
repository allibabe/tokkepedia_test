using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class UserReactionsViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<TokkepediaReaction> Reactions { get; set; }
        public string Token { get; set; } = "";
    }
}
