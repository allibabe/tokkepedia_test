using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models
{
    public class TokCounter
    {
        #region Statistics

        [JsonIgnore]
        public int UsersReacted { get; set; }

        [JsonIgnore]
        public int Likes { get; set; }

        [JsonIgnore]
        public int Dislikes { get; set; }

        [JsonIgnore]
        public int Accurates { get; set; }

        [JsonIgnore]
        public int Inaccurates { get; set; }

        [JsonIgnore]
        public int Comments { get; set; }

        [JsonIgnore]
        public int Reports { get; set; }

        [JsonIgnore]
        public int Shares { get; set; }

        [JsonIgnore]
        public int Views { get; set; }

        #endregion
    }
}
