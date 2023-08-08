using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviePro.Data.Services;
using MoviePro.Data.Static;
using MoviePro.Models;

namespace MoviePro.Controllers
{
	[Authorize(Roles = UserRoles.Admin)]
	public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
           _service= service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
			var allMovies = await _service.GetAllAsync(n => n.Cinema);
			return View(allMovies);
		}
		//搜尋電影功能
		[AllowAnonymous]
		public async Task<IActionResult> Filter(string searchString)
		{
			var allMovies = await _service.GetAllAsync(n => n.Cinema);
			if (!string.IsNullOrEmpty(searchString))
			{
				var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

				return View("Index", filteredResultNew);
			}

			return View("Index", allMovies);
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
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
		{
			var movieDetails = await _service.GetMovieByIdAsync(id);
			return View(movieDetails);
		}
        //取得電影編輯畫面
		public async Task<IActionResult> Edit(int id)
		{
			var movieDetails = await _service.GetMovieByIdAsync(id);
			if (movieDetails == null) return View("NotFound");

			var reponse = new NewMovieVM()
			{
				Id = movieDetails.Id,
				Name = movieDetails.Name,
				Description = movieDetails.Description,
				Price = movieDetails.Price,
				StartDate = movieDetails.StartDate,
				EndDate = movieDetails.EndDate,
				ImageURL = movieDetails.ImageURL,
				MovieCategroy = movieDetails.MovieCategroy,
				CinemaId = movieDetails.CinemaID,
				ProducerId = movieDetails.ProducerID,
				ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
			};

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(reponse);
        }

		[HttpPost]
		public async Task<IActionResult> Edit(int id, NewMovieVM movie)
		{
			if (id != movie.Id) return View("NotFound");

			if (!ModelState.IsValid)
			{
				var movieDropdownData = await _service.GetNewMovieDropdownsValues();

				ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
				ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "Name");
				ViewBag.Actors = new SelectList(movieDropdownData.Actors,"Id", "Name");

				return View(movie);
			}

			await _service.UpdateMovieAsync(movie);
			return RedirectToAction(nameof(Index));
		}
    }
}
