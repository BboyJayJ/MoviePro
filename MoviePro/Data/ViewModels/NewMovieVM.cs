using MoviePro.Data;
using System.ComponentModel.DataAnnotations;

namespace MoviePro.Models
{
	public class NewMovieVM
	{
		public int Id { get; set; }
		[Display(Name = "電影名稱")]
		[Required(ErrorMessage = "電影名稱不可為空")]
		public string? Name { get; set; }
		[Display(Name = "電影描述")]
		[Required(ErrorMessage = "電影描述不可為空")]
		public string? Description { get; set; }
		[Display(Name = "電影價錢 $")]
		[Required(ErrorMessage = "電影價錢不可為空")]
		public double Price { get; set; }
		[Display(Name = "電影圖片")]
		[Required(ErrorMessage = "電影圖片不可為空")]
		public string? ImageURL { get; set; }
		[Display(Name = "電影開始時間")]
		[Required(ErrorMessage = "電影開始時間不可為空")]
		public DateTime StartDate { get; set; }
		[Display(Name = "電影結束時間")]
		[Required(ErrorMessage = "電影結束時間不可為空")]
		public DateTime EndDate { get; set; }

        [Display(Name = "電影類型")]
        public MovieCategroy MovieCategroy { get; set; }

		//Relationships
		[Display(Name = "選擇演員")]
		[Required(ErrorMessage = "選擇演員不可為空")]
		public List<int>? ActorIds  { get; set; }

		[Display(Name = "選擇電影院")]
		[Required(ErrorMessage = "選擇電影院不可為空")]
		public int CinemaId { get; set; }

		[Display(Name = "選擇製作人")]
		[Required(ErrorMessage = "選擇製作人不可為空")]
		public int ProducerId { get; set; }
	}
}
