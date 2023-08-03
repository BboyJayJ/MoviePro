using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MoviePro.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name ="全名")]
        public string ? FullName { get; set; }
    }
}
