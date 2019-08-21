using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class ChangeProfilePictureViewModel
    {
        public ApplicationUser User { get; set; }
        public string Base64Image { get; set; }
        public string Base64Image_Cover { get; set; }
    }
}
