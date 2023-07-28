using MoviePro.Models;

namespace MoviePro.Data.Services
{
	public interface IProducersService
	{
		public Task <IEnumerable<Producer>> GetAllAsync();
		Task<Producer> GetById(int id);
		Task AddAsync(Producer producer);
		Task<Producer> Update(int id,Producer newProducer);
		Task<Producer> Delete(int id);

	}
}
