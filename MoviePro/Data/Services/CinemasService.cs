using Microsoft.EntityFrameworkCore;
using MoviePro.Models;

namespace MoviePro.Data.Services
{
	public class CinemasService : ICinemasService
	{
		private readonly AppDbContext _context;

		public CinemasService(AppDbContext context)
		{
			_context = context;
		}

		public void Add(Cinema cinema)
		{
			_context.Cinemas.Add(cinema);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task <IEnumerable<Cinema>> GetAll()
		{
			var result = await _context.Cinemas.ToListAsync();
			return result;
		}

		public Cinema GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Cinema Update(int id, Cinema newCinema)
		{
			throw new NotImplementedException();
		}
	}
}
