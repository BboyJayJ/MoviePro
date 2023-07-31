using MoviePro.Data.Base;
using MoviePro.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviePro.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="電影名稱")]
        public string ? Name { get; set; }
		[Display(Name = "電影描述")]
		public string ? Description { get; set; }
		[Display(Name = "電影價錢")]
		public double Price { get; set; }
		[Display(Name = "電影圖片")]
		public string ? ImageURL { get; set; }
		[Display(Name = "電影開始時間")]
		public DateTime StartDate { get; set; }
		[Display(Name = "電影結束時間")]
		public DateTime EndDate { get; set; }

        public MovieCategroy MovieCategroy { get; set; }

        public List<Actor_Movie>? Actors_Movies { get; set; }

        //Cinema
        public int CinemaID { get; set; }
        [ForeignKey("CinemaID")]
        public Cinema ? Cinema { get; set; }

        //Producer
        public int ProducerID { get; set; }
        [ForeignKey("ProducerID")]
        public Producer? Producer { get; set; }
    }
}
