using System.ComponentModel.DataAnnotations;

namespace MoviePro.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="製片人圖片")]
        public string? PictureUrl { get; set; }
		[Display(Name = "製片人全名")]
		public string? FullName { get; set; }
		[Display(Name = "製片人簡介")]
		public string? Bio { get; set; }

        public List<Movie> ? Movies { get; set; }
    }
}
