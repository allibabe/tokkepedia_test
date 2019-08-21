using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models
{
    public class GroupBind
    {
        public string group { get; set; }
        public string comment { get; set; }
        public string data3 { get; set; }
        public string order { get; set; }
        public string country { get; set; }
        public string category { get; set; }
        public string tokgroup { get; set; }
        public string toktype { get; set; }
        public string toktypeid { get; set; }
        public string userid { get; set; }
        public string isLoadMore { get; set; }
        public string detailtext { get; set; }
        public bool isCard { get; set; } = false;
        public int loadCount { get; set; } = 0;
    }

    public class ReactionBodyDataBind
    {
        public string item { get; set; }
        public string user_id { get; set; }
        public string item_user_id { get; set; }
        public string kind { get; set; } //example: "like", "dislike"
        public string activityId { get; set; }
        public string comment { get; set; } = null;
        public string comment_id { get; set; } = null;
        public int detail_num { get; set; }
    }

}
