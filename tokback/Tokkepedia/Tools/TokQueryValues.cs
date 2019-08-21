using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tokkepedia
{
    public class TokQueryValues
    {
        /// <summary>  
        ///  "oldest" or "newest"
        /// </summary>  
        public string order { get; set; }
        
        public string country { get; set; }


        public string category { get; set; }
        public string tokgroup { get; set; }
        public string toktype { get; set; }
        public string userid { get; set; }
        public string itemid { get; set; }
        public string text { get; set; }

        /// <summary>  
        ///  "yes" or "no"
        /// </summary>  
        public string loadmore { get; set; }
        public string token { get; set; }
        public string streamtoken { get; set; }

        /// <summary>  
        ///  -1 (only main tok), 0 (everything), 1 (just detail 1), 2, 3, 4, 5. Value must be numeric
        /// </summary>  
        public string detailnumber { get; set; } = "0";
        public string offset { get; set; }
    }

    public class SetQueryValues
    {
        public string order { get; set; }
        public string text { get; set; }
        public string userid { get; set; }
        public string loadmore { get; set; }
        public string token { get; set; }
        public int offset { get; set; } = 25; //MaxItemCount, default is 25
        public string toktypeid { get; set; }

        //public string category { get; set; }
        //public string tokgroup { get; set; }

    }
}
