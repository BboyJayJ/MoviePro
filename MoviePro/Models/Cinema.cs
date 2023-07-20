using System.ComponentModel.DataAnnotations;

namespace MoviePro.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="電影院Logo")]
        public string ?  Logo { get; set; }
		[Display(Name = "電影院名稱")]
		public string? Name { get; set; }
		[Display(Name = "電影院描述")]
		public string? Description { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}
