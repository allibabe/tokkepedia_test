using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class AddMultipleToksViewModel
    {
        public Tok Tok { get; set; }
        public List<TokTypeList> TokGroups { get; set; }

        public string[] TokGroupStrings { get; set; }
        public string TokGroupString { get; set; }
        public string TokGroupDataString { get; set; }
        public string Toks { get; set; }

        public TokTypeList TokGroup { get; set; }
    }
}
