using Microsoft.EntityFrameworkCore;
using MoviePro.Models;

namespace MoviePro.Data.Services
{
	public class ProducersService : IProducersService
	{
		private readonly AppDbContext _context;

		public ProducersService(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Producer producer)
		{
			await _context.Producers.AddAsync(producer);
			await _context.SaveChangesAsync();
		}

		public Task<Producer> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task <IEnumerable<Producer>> GetAllAsync()
		{
			var result = await _context.Producers.ToListAsync();
			return result;
		}

		public Task<Producer> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Producer> Update(int id, Producer newProducer)
		{
			throw new NotImplementedException();
		}
	}
}
