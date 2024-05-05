using FPTLongChau.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FPTLongChau.Areas.Admin.Models;
using FPTLongChau.Models;

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
            var products = _context.Products;
            var categories = _context.Categories;
            var viewModel = new ProductViewModel(products,categories);
            return View(viewModel);
        }

//     // GET: Products
//     public async Task<IActionResult> Index()
//     {
//         var products = _context.Products;
//         return View(new ProductViewModel(products));
//     }


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

		[HttpPost]
        public IActionResult GetFilteredProducts(Guid[] categoryIds)
        {
            var products = _context.Products
				.Where(p => categoryIds
				.Contains(p.CategoryId))
				.ToList();
			return PartialView("~/Views/Shared/Products/_ProductCardList.cshtml", products);
		}
    }

// 		private bool ProductExists(Guid id)
// 		{
// 			return _context.Products.Any(e => e.Id == id);
// 		}
// 	}

}
