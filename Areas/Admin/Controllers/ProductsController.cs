using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPTLongChau.Data;
using FPTLongChau.Models;
using FPTLongChau.Services.Abstract;
using FPTLongChau.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FPTLongChau.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IImageService _imageService;

		public ProductsController(ApplicationDbContext context, IImageService imageService)
		{
			_context = context;
			_imageService = imageService;
		}

		// GET: Admin/Products
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Products.Include(p => p.Category);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Admin/Products/Details/5
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

		// GET: Admin/Products/Create
		public IActionResult Create()
		{
			ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Title");
			return View();
		}

		// POST: Admin/Products/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Title,Price,Description,CategoryId")] Product product, IFormFile? FileImage)
		{
			if(ModelState.IsValid)
			{
				product.Id = Guid.NewGuid();
				if(FileImage != null)
				{
					product.Image = _imageService.UploadImageToAzureBlob(FileImage);
				}
				_context.Add(product);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Title", product.CategoryId);
			return View(product);
		}

		// GET: Admin/Products/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var product = await _context.Products.FindAsync(id);
			if(product == null)
			{
				return NotFound();
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Title", product.CategoryId);
			return View(product);
		}

		// POST: Admin/Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Price,Description,CategoryId")] Product product, IFormFile? FileImage)
		{
			if(id != product.Id)
			{
				return NotFound();
			}

			if(ModelState.IsValid)
			{
				try
				{
					var oldImage = _context.Products.Where(p => p.Id == product.Id).Select(p => p.Image).FirstOrDefault();
					product.Image = oldImage;
					if(FileImage != null)
						if(FileImage.FileName != null)
						{
							if(oldImage != null)
							{
								_imageService.DeleteImageFromAzureBlob(oldImage);
								product.Image = _imageService.UploadImageToAzureBlob(FileImage);
							}
							else
							{
								product.Image = _imageService.UploadImageToAzureBlob(FileImage);
							}
						}
					_context.Update(product);
					await _context.SaveChangesAsync();
				}
				catch(DbUpdateConcurrencyException)
				{
					if(!ProductExists(product.Id))
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
			ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Title", product.CategoryId);
			return View(product);
		}

		// GET: Admin/Products/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
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

		// POST: Admin/Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var product = await _context.Products.FindAsync(id);
			if(product != null)
			{
				_context.Products.Remove(product);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ProductExists(Guid id)
		{
			return _context.Products.Any(e => e.Id == id);
		}

	}
}
