using MoviePro.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MoviePro.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="製作人圖片")]
        [Required(ErrorMessage ="製作人圖片不可為空")]
        public string? PictureUrl { get; set; }
		[Display(Name = "製作人全名")]
		[Required(ErrorMessage = "製作人全名不可為空")]
        [StringLength(50,MinimumLength = 3,ErrorMessage = "製作人全名長度範圍在3~50字之間")]
		public string? FullName { get; set; }
		[Display(Name = "製作人簡介")]
		[Required(ErrorMessage = "製作人簡介不可為空")]
		public string? Bio { get; set; }

        public List<Movie> ? Movies { get; set; }
    }
}
