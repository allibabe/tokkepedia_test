using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tokkepedia.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Tok> Tok { get; set; } = new List<Tok>();
        public string Token { get; set; } = "";
        public long Toks { get; set; }
        public IEnumerable<Set> Sets { get; set; }
        public IEnumerable<TokkepediaReaction> UserReactions { get; set; }

        public string SearchText { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }

        public bool IsSignedIn { get; set; }

        public List<TokType> TopTokTypes { get; set; } = new List<TokType>();
        public List<Category> TopCategories { get; set; } = new List<Category>();
        public List<TokketUser> TopUsers { get; set; } = new List<TokketUser>();
    }

}
