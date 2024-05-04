using FPTLongChau.Areas.Admin.Models;
using FPTLongChau.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPTLongChau.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PayModesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public PayModesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Admin/PayModes
		public async Task<IActionResult> Index()
		{
			return View(await _context.PayModes.ToListAsync());
		}

		// GET: Admin/PayModes/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var payMode = await _context.PayModes
				.FirstOrDefaultAsync(m => m.Id == id);
			if(payMode == null)
			{
				return NotFound();
			}

			return View(payMode);
		}

		// GET: Admin/PayModes/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Admin/PayModes/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Title,Description")] PayMode payMode)
		{
			if(ModelState.IsValid)
			{
				payMode.Id = Guid.NewGuid();
				_context.Add(payMode);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(payMode);
		}

		// GET: Admin/PayModes/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var payMode = await _context.PayModes.FindAsync(id);
			if(payMode == null)
			{
				return NotFound();
			}
			return View(payMode);
		}

		// POST: Admin/PayModes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description")] PayMode payMode)
		{
			if(id != payMode.Id)
			{
				return NotFound();
			}

			if(ModelState.IsValid)
			{
				try
				{
					_context.Update(payMode);
					await _context.SaveChangesAsync();
				}
				catch(DbUpdateConcurrencyException)
				{
					if(!PayModeExists(payMode.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(payMode);
		}

		// GET: Admin/PayModes/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var payMode = await _context.PayModes
				.FirstOrDefaultAsync(m => m.Id == id);
			if(payMode == null)
			{
				return NotFound();
			}

			return View(payMode);
		}

		// POST: Admin/PayModes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var payMode = await _context.PayModes.FindAsync(id);
			if(payMode != null)
			{
				_context.PayModes.Remove(payMode);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PayModeExists(Guid id)
		{
			return _context.PayModes.Any(e => e.Id == id);
		}
	}
}
