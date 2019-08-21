using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public TokketUser User { get; set; }
        public IEnumerable<Tok> Tok { get; set; }
        public string Token { get; set; }

        public IEnumerable<Set> Sets { get; set; }
        public TokkepediaFollow UserFollow { get; set; }
        public string UserFollowString { get; set; }

        public bool IsSignedIn { get; set; }
    }
}
