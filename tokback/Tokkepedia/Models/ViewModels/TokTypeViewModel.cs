using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Models.ViewModels
{
    public class TokTypeViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }

        public IEnumerable<Tok> Tok { get; set; }
        public string Token { get; set; }
        public IEnumerable<Set> Sets { get; set; }
        public IEnumerable<TokkepediaReaction> UserReactions { get; set; }
        public TokType TokType { get; set; }

        public bool IsSignedIn { get; set; }
    }
}
