using System.ComponentModel.DataAnnotations;

namespace MoviePro.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name ="全名")]
        [Required(ErrorMessage ="全名不可為空")]
        public string? FullName { get; set; }
        [Display(Name = "電子郵件")]
        [Required(ErrorMessage = "電子郵件不可為空")]
        public string? EmailAddress { get; set; }
        [Display(Name = "密碼")]
        [Required(ErrorMessage = "密碼不可為空")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "確認密碼")]
        [Required(ErrorMessage = "確認密碼不可為空")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="密碼與確認密碼不一致")]
        public string? ConfirmPassword { get; set; }
    }
}
