using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Tokkepedia.Models
{
    public class ResultData<T>
    {
        public string Token { get; set; }
        public List<T> Results { get; set; }
    }
}
