using Microsoft.EntityFrameworkCore;
using MoviePro.Data.Base;
using MoviePro.Models;

namespace MoviePro.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
		public ActorsService(AppDbContext context) : base(context) { }
    }
}
