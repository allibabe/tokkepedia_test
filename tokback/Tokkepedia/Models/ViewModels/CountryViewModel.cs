using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class CountryViewModel
    {

        public IEnumerable<Tok> Tok { get; set; }
        public string Token { get; set; }
        public IEnumerable<Set> Sets { get; set; }
        public IEnumerable<TokkepediaReaction> UserReactions { get; set; }
        public Country Country { get; set; }

        public bool IsSignedIn { get; set; }
    }
}
