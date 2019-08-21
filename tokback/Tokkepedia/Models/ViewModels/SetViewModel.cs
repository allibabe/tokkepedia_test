using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class SetViewModel
    {
        public Set CurrentSet { get; set; }
        public List<Tok> Toks { get; set; }
        public string Token { get; set; }
        public bool IsSignedIn { get; set; }
    }
}
