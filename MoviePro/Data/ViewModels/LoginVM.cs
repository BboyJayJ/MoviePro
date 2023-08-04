using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoviePro.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "電子郵件")]
        [Required(ErrorMessage = "電子郵件不可為空")]
        public string? EmailAddress { get; set; }
        [Display(Name = "密碼")]
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
