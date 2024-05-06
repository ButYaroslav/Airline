using Airline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airline.Controllers
{
    public class FlightsController : Controller
    {
        private readonly AppDbContext? _db;

        public FlightsController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (_db != null)
            {
                IEnumerable<Flights> objList = _db.Flights;
                foreach (var obj in objList)
                {
                    obj.Airlines = _db.Airlines.FirstOrDefault(u => u.Id == obj.AirlinesId);
                }
                return View(objList);
            }
            return View();
        }


		// GET CREATE
		public IActionResult Create()
		{
			IEnumerable<SelectListItem> AirlinesDropDown = _db.Airlines.Select(i => new SelectListItem
			{
				Text = i.Name,
				Value = i.Id.ToString()
			});
			ViewBag.AirlinesDropDown = AirlinesDropDown;
			return View();
		}
		// POST CREATE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Flights obj)
		{
			if (ModelState.IsValid)
			{
				_db?.Flights.Add(obj);
				_db?.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}


		// GET UPDATE
		public IActionResult Update(int? id)
		{
			IEnumerable<SelectListItem> AirlinesDropDown = _db.Airlines.Select(i => new SelectListItem
			{
				Text = i.Name,
				Value = i.Id.ToString()
			});
			ViewBag.AirlinesDropDown = AirlinesDropDown;
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db?.Flights.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}
		// POST UPDATE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Flights obj)
		{
			if (ModelState.IsValid)
			{
				_db?.Flights.Update(obj);
				_db?.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}


		// GET DELETE
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db?.Flights.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}
		// POST DELETE
		public IActionResult DeleteFlight(int? id)
		{
			var obj = _db?.Flights.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db?.Flights.Remove(obj);
			_db?.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
