using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviePro.Data.Services;
using MoviePro.Models;

namespace MoviePro.Controllers
{
	public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
           _service= service;
        }
        public async Task<IActionResult> Index()
        {
			var allMovies = await _service.GetAllAsync(n => n.Cinema);
			return View(allMovies);
		}
		//取得新增電影畫面
        public async Task<IActionResult> Create()
        {
			var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

			ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
			ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
			ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
			return View();
        }

		[HttpPost]
		public async Task<IActionResult> Create(NewMovieVM movie)
		{
			if (!ModelState.IsValid)
			{
				var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

				ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
				ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
				ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

				return View(movie);
			}

			await _service.AddNewMovieAsync(movie);
			return RedirectToAction(nameof(Index));
		}

        //取得電影詳細資料畫面
		public async Task<IActionResult> Details(int id)
		{
			var movieDetails = await _service.GetMovieByIdAsync(id);
			return View(movieDetails);
		}
    }
}
