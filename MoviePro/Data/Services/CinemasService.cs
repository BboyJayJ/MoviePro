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

		public async Task AddAsync(Cinema cinema)
		{
			await _context.Cinemas.AddAsync(cinema);
			await _context.SaveChangesAsync();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task <IEnumerable<Cinema>> GetAllAsync()
		{
			var result = await _context.Cinemas.ToListAsync();
			return result;
		}

		public async Task <Cinema> GetByIdAsync(int id)
		{
			var result = await _context.Cinemas.FirstOrDefaultAsync(n => n.Id ==id);
			return result;
		}

		public Cinema Update(int id, Cinema newCinema)
		{
			throw new NotImplementedException();
		}
	}
}
