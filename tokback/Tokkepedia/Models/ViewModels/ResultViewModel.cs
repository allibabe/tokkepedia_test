using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Tools.Helpers;

namespace Tokkepedia.Models.ViewModels
{
    public class ResultViewModel
    {
        public Result ResultEnum { get; set; } = Result.Failed;
        public string ResultTitle { get; set; }
        public string ResultMessage { get; set; }
        public object ResultObject { get; set; }
    }
}
