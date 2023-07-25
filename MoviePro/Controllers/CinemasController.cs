using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePro.Data;
using MoviePro.Data.Services;
using MoviePro.Models;

namespace MoviePro.Controllers
{
    public class CinemasController : Controller
    {
		
		private readonly ICinemasService _service;

		public CinemasController(ICinemasService service)
		{
			_service = service;
		}
		public async Task<IActionResult> Index()
        {
			var allCinemas = await _service.GetAll();

			return View(allCinemas);
        }

		//取得電影院新增畫面
		public IActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		public IActionResult Create([Bind("Name,Logo,Description")] Cinema cinema)
		{
			if (!ModelState.IsValid)
			{
				return View(cinema);
			}
			_service.Add(cinema);
			return RedirectToAction(nameof(Index));
		}

		




	}

}
