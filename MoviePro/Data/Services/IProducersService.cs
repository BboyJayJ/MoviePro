using MoviePro.Models;

namespace MoviePro.Data.Services
{
	public interface IProducersService
	{
		public Task <IEnumerable<Producer>> GetAllAsync();
		Task<Producer> GetByIdAsync(int id);
		Task AddAsync(Producer producer);
		Task<Producer> UpdateAsync(int id,Producer newProducer);
		Task DeleteAsync(int id);

	}
}
