using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePro.Data;
using MoviePro.Data.Services;
using MoviePro.Data.Static;
using MoviePro.Models;
using System.Data;

namespace MoviePro.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
		
		private readonly ICinemasService _service;

		public CinemasController(ICinemasService service)
		{
			_service = service;
		}
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
			var allCinemas = await _service.GetAllAsync();

			return View(allCinemas);
        }

		//取得電影院新增畫面
		public IActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinema cinema)
		{
			if (!ModelState.IsValid)
			{
				return View(cinema);
			}
			await _service.AddAsync(cinema);
			return RedirectToAction(nameof(Index));
		}

        //取得電影院詳細資料畫面
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
		{
			var CinemaDetaisl = await _service.GetByIdAsync(id);

			if (CinemaDetaisl == null) return View("NotFound");
			return View(CinemaDetaisl);
		}

		//取得電影院編輯畫面
		public async Task <IActionResult> Edit(int id)
		{
			var CinemaDetaisl = await _service.GetByIdAsync(id);

			if (CinemaDetaisl == null) return View("NotFound");
			return View(CinemaDetaisl);
			
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,Description")] Cinema cinema)
		{
			if (!ModelState.IsValid)
			{
				return View(cinema);
			}
			await _service.UpdateAsync(id, cinema);
			return RedirectToAction(nameof(Index));
		}

		//取得電影院刪除畫面
		public async Task<IActionResult> Delete(int id)
		{
			var CinemaDetaisl = await _service.GetByIdAsync(id);
			if (CinemaDetaisl == null) return View("NotFound");
			return View(CinemaDetaisl);

		}

		[HttpPost,ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var CinemaDetaisl = await _service.GetByIdAsync(id);
			if (CinemaDetaisl == null) return View("NotFound");

			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}


	}

}
