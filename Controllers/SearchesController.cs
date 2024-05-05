using FPTLongChau.Areas.Admin.Models;
using FPTLongChau.Data;
using FPTLongChau.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FPTLongChau.Controllers
{
	public class SearchesController : Controller
	{
		private readonly ApplicationDbContext _context;
		public SearchesController(ApplicationDbContext context)
		{
			_context = context;
		}
        // GET: Searches/Index
        public async Task<IActionResult> Index(string searchString)
        {
            IQueryable<Product> productsQuery = _context.Products;

            if (!String.IsNullOrEmpty(searchString))
            {
                productsQuery = productsQuery.Where(p => p.Title.Contains(searchString));
            }

            var products = await productsQuery.ToListAsync();

            // Fetch the categories associated with the filtered products
            var categories = await _context.Categories.ToListAsync();

            var viewModel = new ProductViewModel(products, categories, searchString);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetFilteredProducts(Guid[] categoryIds, string searchString)
        {
            IQueryable<Product> productsQuery = _context.Products;

            // Check if categoryIds is null or empty
            if (categoryIds == null || categoryIds.Length == 0)
            {
                // If no categories are selected, return an empty list
                return PartialView("~/Views/Shared/Products/_ProductCardList.cshtml", new List<Product>());
            }
            else
            {
                // If categories are selected, filter products by categories
                productsQuery = productsQuery.Where(p => categoryIds.Contains(p.CategoryId));

                // If searchString is not null or empty, further filter products by search string
                if (!String.IsNullOrEmpty(searchString))
                {
                    productsQuery = productsQuery.Where(p => p.Title.Contains(searchString));
                }

                var products = await productsQuery.ToListAsync();

                return PartialView("~/Views/Shared/Products/_ProductCardList.cshtml", products);
            }
        }
    }
}
