using FPTLongChau.Areas.Admin.Models;
using FPTLongChau.Data;
using FPTLongChau.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Controllers
{
	public class CartsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CartsController(ApplicationDbContext context)
		{
			_context = context;
		}
		// GET: Carts
		public async Task<ActionResult> Index()
		{
			return View();
		}

		//POST: Carts/ViewCart
	   [HttpPost]
		public async Task<ActionResult> ViewCart([FromBody] List<CartItem> cartItems)
		{


			var prodcuts = new List<CartItemViewModel>();
			foreach(var item in cartItems)
			{
				var product = await _context.Products.FindAsync(item.Id);
				prodcuts.Add(new CartItemViewModel
				{
					Id = item.Id,
					Price = product.Price,
					Title = product.Title,
					Image = product.Image,
					Quantity = item.Quantity
				});
			}

			return PartialView("_CartList", prodcuts);
		}




	}
}
