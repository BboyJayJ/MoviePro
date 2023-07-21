using System.ComponentModel.DataAnnotations;

namespace MoviePro.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="圖片網址")]
        [Required(ErrorMessage = "圖片網址不可為空")]
        public string ? PictureUrl { get; set; }
		[Display(Name = "全名")]
		[Required(ErrorMessage = "全名不可為空")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="全名長度範圍在3~50個字之間" )]
		public string ? FullName { get; set; }
		[Display(Name = "簡介")]
		[Required(ErrorMessage = "簡介不可為空")]
		public string ? Bio { get; set; }

        public List<Actor_Movie> ? Actors_Movies { get; set; }
    }
}
