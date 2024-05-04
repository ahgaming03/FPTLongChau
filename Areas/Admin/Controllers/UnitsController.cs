using FPTLongChau.Areas.Admin.Models;
using FPTLongChau.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPTLongChau.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UnitsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public UnitsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Admin/Units
		public async Task<IActionResult> Index()
		{
			return View(await _context.Units.ToListAsync());
		}

		// GET: Admin/Units/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var unit = await _context.Units
				.FirstOrDefaultAsync(m => m.Id == id);
			if(unit == null)
			{
				return NotFound();
			}

			return View(unit);
		}

		// GET: Admin/Units/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Admin/Units/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Title,Description")] Unit unit)
		{
			if(ModelState.IsValid)
			{
				unit.Id = Guid.NewGuid();
				_context.Add(unit);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(unit);
		}

		// GET: Admin/Units/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var unit = await _context.Units.FindAsync(id);
			if(unit == null)
			{
				return NotFound();
			}
			return View(unit);
		}

		// POST: Admin/Units/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description")] Unit unit)
		{
			if(id != unit.Id)
			{
				return NotFound();
			}

			if(ModelState.IsValid)
			{
				try
				{
					_context.Update(unit);
					await _context.SaveChangesAsync();
				}
				catch(DbUpdateConcurrencyException)
				{
					if(!UnitExists(unit.Id))
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
			return View(unit);
		}

		// GET: Admin/Units/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var unit = await _context.Units
				.FirstOrDefaultAsync(m => m.Id == id);
			if(unit == null)
			{
				return NotFound();
			}

			return View(unit);
		}

		// POST: Admin/Units/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var unit = await _context.Units.FindAsync(id);
			if(unit != null)
			{
				_context.Units.Remove(unit);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool UnitExists(Guid id)
		{
			return _context.Units.Any(e => e.Id == id);
		}
	}
}
