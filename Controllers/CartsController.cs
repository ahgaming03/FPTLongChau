using FPTLongChau.Areas.Admin.Models;
using FPTLongChau.Data;
using FPTLongChau.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using NToastNotify;
using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Controllers
{
	public class CartsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IToastNotification _toastNotification;
		private readonly UserManager<ApplicationUser> _userManager;

		public CartsController(ApplicationDbContext context, IToastNotification toastNotification, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_toastNotification = toastNotification;
			_userManager = userManager;
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
					Quantity = item.Quantity,
					TotalPrice = Math.Round(item.Quantity * product.Price, 2)
				});
			}
			_toastNotification.AddSuccessToastMessage("Cart updated successfully");
			return PartialView("_CartList", prodcuts);
		}

		//POST: Carts/TotalCartPrice
		[HttpPost]
		public async Task<ActionResult> TotalCartPrice([FromBody] List<CartItem> cartItems)
		{
			var totalPrice = 0.0;
			foreach(var item in cartItems)
			{
				var product = await _context.Products.FindAsync(item.Id);
				totalPrice += item.Quantity * product.Price;
			}

			return Ok(Math.Round(totalPrice, 2));
		}

		//Get: Carts/Purchase
		public async Task<ActionResult> Purchase()
		{
			ViewData["PayModeId"] = new SelectList(_context.PayModes, "Id", "Title");
			return View();
		}

		//Get: Carts/ViewReceipt
		public async Task<ActionResult> ViewReceipt([FromBody] List<CartItem> cartItems)
		{
			var prodcuts = new List<CartItemViewModel>();
			var totalPrice = 0.0;
			foreach(var item in cartItems)
			{
				var product = await _context.Products.FindAsync(item.Id);
				prodcuts.Add(new CartItemViewModel
				{
					Id = item.Id,
					Price = product.Price,
					Title = product.Title,
					Image = product.Image,
					Quantity = item.Quantity,
					TotalPrice = Math.Round(item.Quantity * product.Price, 2)
				});
				totalPrice += item.Quantity * product.Price;
			}

			ViewBag.TotalPrice = Math.Round(totalPrice, 2);


			return PartialView("_Receipt", prodcuts);
		}

		//POST: Carts/Checkout
		[HttpPost]
		public async Task<ActionResult> Checkout([Bind("Id,FirstName,LastName,Address,PhoneNumber,PayModeId")] Order order, string shoppingCart)
		{
			if(ModelState.IsValid)
			{
				ApplicationUser user = await _userManager.GetUserAsync(User);
				order.Customer = user;

				order.Id = Guid.NewGuid();

				var totalPrice = 0.0;

				var cartItems = JsonConvert.DeserializeObject<List<CartItem>>(shoppingCart);
				foreach(var item in cartItems)
				{
					var product = await _context.Products.FindAsync(item.Id);
					var orderDetail = new OrderDetail
					{
						ProductId = item.Id,
						Quantity = item.Quantity,
						OrderId = order.Id,
					};
					totalPrice += item.Quantity * product.Price;
					_context.OrderDetails.Add(orderDetail);
				}
				order.TotalPrice = (decimal)Math.Round(totalPrice, 2);
				_context.Add(order);
				await _context.SaveChangesAsync();
				_toastNotification.AddSuccessToastMessage("Order placed successfully");

				string script = "<script>localStorage.removeItem('shoppingCart'); window.location.href='/';</script>";
				return Content(script, "text/html");
			}
			ViewData["PayModeId"] = new SelectList(_context.PayModes, "Id", "Title");
			return View("Purchase", order);
		}

	}
}
