using System.ComponentModel.DataAnnotations;

namespace MoviePro.Data
{
    
    public enum MovieCategroy
    {
        [Display(Name = "動作")]
        Action = 1,
        [Display(Name = "喜劇")]
        Comdey,
        [Display(Name = "劇情")]
        Drama,
        [Display(Name = "紀錄片")]
        Documentary,
        [Display(Name = "卡通")]
        Horror,
        [Display(Name = "恐怖")]
        Cartoon
        
	}
}
