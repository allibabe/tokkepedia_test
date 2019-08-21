using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class TokGroupViewModel
    {
        public IEnumerable<Tok> Tok { get; set; }
        public string Token { get; set; }
        public int Toks { get; set; }
        public IEnumerable<Set> Sets { get; set; }
        public IEnumerable<TokkepediaReaction> UserReactions { get; set; }
        public TokTypeList TokGroup { get; set; }

        public bool IsSignedIn { get; set; }
    }
}
