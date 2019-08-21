using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class TokReactionsViewModel
    {
        public Tok Tok { get; set; }
        public List<TokkepediaReaction> Reactions { get; set; } = new List<TokkepediaReaction>();
        public string Token { get; set; } = "";

        //Detail
        public List<TokkepediaReaction> Comments { get; set; } = new List<TokkepediaReaction>();
        //public DetailReactionCounter Detail { get; set; }
        public string DetailText { get; set; }
    }
}
