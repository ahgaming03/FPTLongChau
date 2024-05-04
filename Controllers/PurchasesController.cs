using Microsoft.AspNetCore.Mvc;

namespace FPTLongChau.Controllers
{
	public class PurchasesController : Controller
	{
		// GET: PurchasesController
		public ActionResult Index()
		{
			return View();
		}

		// GET: PurchasesController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PurchasesController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PurchasesController/Create
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

		// GET: PurchasesController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PurchasesController/Edit/5
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

		// GET: PurchasesController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PurchasesController/Delete/5
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
