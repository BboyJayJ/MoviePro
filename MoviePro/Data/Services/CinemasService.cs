using Microsoft.EntityFrameworkCore;
using MoviePro.Data.Base;
using MoviePro.Models;

namespace MoviePro.Data.Services
{
	public class CinemasService :EntityBaseRepository<Cinema> ,ICinemasService
	{		
		public CinemasService(AppDbContext context) : base(context) { }
					
		
	}
}
