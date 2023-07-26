using MoviePro.Models;

namespace MoviePro.Data.Services
{
	public interface ICinemasService
	{
		Task <IEnumerable<Cinema>> GetAllAsync();
		Task<Cinema> GetByIdAsync(int id);
		Task AddAsync(Cinema cinema);
		Cinema Update(int id, Cinema newCinema);
		void Delete(int id);
	}
}
