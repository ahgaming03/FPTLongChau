using Microsoft.AspNetCore.Mvc;

namespace FPTLongChau.Controllers
{
	public class SearchesController : Controller
	{
		// GET: SearchesController
		public ActionResult Index()
		{
			return View();
		}

		// GET: SearchesController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: SearchesController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: SearchesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: SearchesController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: SearchesController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: SearchesController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SearchesController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
