using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tokkepedia
{
    public class ReactionQueryValues
    {
        public int limit = 20;
        public string kind = "all";
        public string item_id = "";
        public string activity_id = "";
        public string user_id = "";
        public string reaction_id = "";
        public string pagination_id = "";
    }
}
