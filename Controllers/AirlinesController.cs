using Airline.Models;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Controllers
{
	public class AirlinesController : Controller
	{
		private readonly AppDbContext? _db;

		public AirlinesController(AppDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			if (_db != null)
			{
				IEnumerable<Airlines> objList = _db.Airlines;
				return View(objList);
			}
			return View();
		}
		// GET CREATE
		public IActionResult Create()
		{
			return View();
		}

		// POST CREATE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Airlines obj)
		{
			if (ModelState.IsValid)
			{
				_db?.Airlines.Add(obj);
				_db?.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		// GET UPDATE
		public IActionResult Update(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db?.Airlines.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		// POST UPDATE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Airlines obj)
		{
			if (ModelState.IsValid)
			{
				_db?.Airlines.Update(obj);
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
			var obj = _db?.Airlines.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		// POST DELETE
		public IActionResult DeletePost(int? id)
		{
			var obj = _db?.Airlines.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db?.Airlines.Remove(obj);
			_db?.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
