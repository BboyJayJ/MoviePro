using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePro.Data;
using MoviePro.Data.Services;
using MoviePro.Models;

namespace MoviePro.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task <IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();

            return View(allProducers);
        }

        //取得製作人新增畫面

        public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Create([Bind("FullName,PictureUrl,Bio")] Producer producer)
		{
			if (!ModelState.IsValid)
			{
				return View(producer);
			}
			await _service.AddAsync(producer);
			return RedirectToAction(nameof(Index));
		}

		//取得製作人詳細資料畫面

        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
               
                    
        }
		//取得製作人編輯畫面
		public async Task <IActionResult> Edit(int id)
		{
			var producerDetails = await _service.GetByIdAsync(id);
			if (producerDetails == null) return View("NotFound");
			return View(producerDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,PictureUrl,Bio")] Producer producer)
		{
			if (!ModelState.IsValid)
			{
				return View(producer);
			}
			await _service.UpdateAsync(id, producer);
			return RedirectToAction(nameof(Index));
		}

		//取得製作人刪除畫面
		public async Task<IActionResult> Delete(int id)
		{
			var producerDetails = await _service.GetByIdAsync(id);
			if (producerDetails == null) return View("NotFound");
			return View(producerDetails);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var producerDetails = await _service.GetByIdAsync(id);
			if (producerDetails == null) return View("NotFound");

			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
