using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class TokInfoViewModel
    {
        public Tok Tok { get; set; }
        public IEnumerable<TokkepediaReaction> Comments { get; set; }
        public string Token { get; set; } = "";
        public List<TokTypeList> TokGroups { get; set; }
    }
}
