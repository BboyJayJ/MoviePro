using Microsoft.EntityFrameworkCore;
using MoviePro.Data.Base;
using MoviePro.Models;

namespace MoviePro.Data.Services
{
	public class ProducersService : EntityBaseRepository<Producer>, IProducersService
	{
		public ProducersService(AppDbContext context) : base(context) { }

	}
}
