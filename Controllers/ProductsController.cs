using FPTLongChau.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPTLongChau.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ProductsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Products
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Products.Include(p => p.Category);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Products/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var product = await _context.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
			if(product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		private bool ProductExists(Guid id)
		{
			return _context.Products.Any(e => e.Id == id);
		}
	}
}
