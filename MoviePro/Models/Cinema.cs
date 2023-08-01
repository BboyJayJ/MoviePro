using MoviePro.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MoviePro.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="電影院Logo")]
		[Required(ErrorMessage = "電影院Logo不可為空")]
		public string ?  Logo { get; set; }
		[Display(Name = "電影院名稱")]
		[Required(ErrorMessage = "名稱不可為空")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "名稱長度範圍在3~50個字之間")]
		public string? Name { get; set; }
		[Display(Name = "電影院描述")]
		[Required(ErrorMessage = "描述不可為空")]
		public string? Description { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}
