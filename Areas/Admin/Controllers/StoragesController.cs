using FPTLongChau.Areas.Admin.Models;
using FPTLongChau.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FPTLongChau.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class StoragesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public StoragesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Admin/Storages
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Storages.Include(s => s.Product).Include(s=>s.Product.Category).Include(s => s.Supplier);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Admin/Storages/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var storage = await _context.Storages
				.Include(s => s.Product)
				.Include(s => s.Supplier)
				.FirstOrDefaultAsync(m => m.Id == id);
			if(storage == null)
			{
				return NotFound();
			}

			return View(storage);
		}

		// GET: Admin/Storages/Create
		public IActionResult Create()
		{
			ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Title");
			ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
			return View();
		}

		// POST: Admin/Storages/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,ProductId,SupplierId,Quantity,Time")] Storage storage)
		{
			if(ModelState.IsValid)
			{
				storage.Id = Guid.NewGuid();
				_context.Add(storage);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Title", storage.ProductId);
			ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", storage.SupplierId);
			return View(storage);
		}

		// GET: Admin/Storages/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var storage = await _context.Storages.FindAsync(id);
			if(storage == null)
			{
				return NotFound();
			}
			ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Title", storage.ProductId);
			ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", storage.SupplierId);
			return View(storage);
		}

		// POST: Admin/Storages/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProductId,SupplierId,Quantity,Time")] Storage storage)
		{
			if(id != storage.Id)
			{
				return NotFound();
			}

			if(ModelState.IsValid)
			{
				try
				{
					_context.Update(storage);
					await _context.SaveChangesAsync();
				}
				catch(DbUpdateConcurrencyException)
				{
					if(!StorageExists(storage.Id))
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
			ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Title", storage.ProductId);
			ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", storage.SupplierId);
			return View(storage);
		}

		// GET: Admin/Storages/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var storage = await _context.Storages
				.Include(s => s.Product)
				.Include(s => s.Supplier)
				.FirstOrDefaultAsync(m => m.Id == id);
			if(storage == null)
			{
				return NotFound();
			}

			return View(storage);
		}

		// POST: Admin/Storages/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var storage = await _context.Storages.FindAsync(id);
			if(storage != null)
			{
				_context.Storages.Remove(storage);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool StorageExists(Guid id)
		{
			return _context.Storages.Any(e => e.Id == id);
		}
	}
}
