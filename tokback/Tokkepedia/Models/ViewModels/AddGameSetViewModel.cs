using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class AddGameSetViewModel
    {
        public Set Set { get; set; }
        public List<string> TokIds { get; set; }
    }
}
