using System.ComponentModel.DataAnnotations;

namespace MoviePro.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="圖片網址")]
        public string ? PictureUrl { get; set; }
		[Display(Name = "全名")]
		public string ? FullName { get; set; }
		[Display(Name = "簡介")]
		public string ? Bio { get; set; }

        public List<Actor_Movie> ? Actors_Movies { get; set; }
    }
}
