using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class CategoryViewModel
    {
        public string Username { get; set; }

        public string StatusMessage { get; set; }

        public IEnumerable<Tok> Tok { get; set; }
        public string Token { get; set; }
        public IEnumerable<Set> Sets { get; set; }
        public IEnumerable<TokkepediaReaction> UserReactions { get; set; }
        public Category Category { get; set; }

        public bool IsSignedIn { get; set; }
    }
}
