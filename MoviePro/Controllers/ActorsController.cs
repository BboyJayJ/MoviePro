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
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
        var data = await _service.GetAllAsync();
            return View(data);
        }

        //取得演員新增畫面   
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,PictureUrl,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        //取得演員詳細資料畫面
        [AllowAnonymous]
        public async Task<IActionResult>Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

		//取得演員編輯畫面     
		public async Task <IActionResult> Edit(int id)
		{
			var actorDetails = await _service.GetByIdAsync(id);
			if (actorDetails == null) return View("NotFound");
			return View(actorDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,PictureUrl,Bio")] Actor actor)
		{
			if (!ModelState.IsValid)
			{
				return View(actor);
			}
			await _service.UpdateAsync(id, actor);
			return RedirectToAction(nameof(Index));
		}

		//取得演員刪除畫面     
		public async Task<IActionResult> Delete(int id)
		{
			var actorDetails = await _service.GetByIdAsync(id);
			if (actorDetails == null) return View("NotFound");
			return View(actorDetails);
		}

		[HttpPost,ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{

			var actorDetails = await _service.GetByIdAsync(id);
			if (actorDetails == null) return View("NotFound");

			await _service.DeleteAsync(id);			
			return RedirectToAction(nameof(Index));
		}
	}
}
