using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPTLongChau.Areas.Admin.Models;
using FPTLongChau.Data;
using FPTLongChau.Services.Abstract;

namespace FPTLongChau.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RanksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageService _imageService;

        public RanksController(ApplicationDbContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        // GET: Admin/Ranks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ranks.ToListAsync());
        }

        // GET: Admin/Ranks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rank = await _context.Ranks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rank == null)
            {
                return NotFound();
            }

            return View(rank);
        }

        // GET: Admin/Ranks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Ranks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Image")] Rank rank, IFormFile? FileImage)
        {
            if (ModelState.IsValid)
            {
                rank.Id = Guid.NewGuid();
                if(FileImage != null)
                {
                    rank.Image = _imageService.UploadImageToAzureBlob(FileImage);
                }
                _context.Add(rank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rank);
        }

        // GET: Admin/Ranks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rank = await _context.Ranks.FindAsync(id);
            if (rank == null)
            {
                return NotFound();
            }
            return View(rank);
        }

        // POST: Admin/Ranks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,Image")] Rank rank, IFormFile? FileImage)
        {
            if (id != rank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldImage = _context.Ranks.Where(r => r.Id == rank.Id).Select(r => r.Image).FirstOrDefault();
                    rank.Image = oldImage;
                    if(FileImage != null)
                    {
                        if(oldImage != null)
                        {
                            _imageService.DeleteImageFromAzureBlob(oldImage);
                        }
                        rank.Image = _imageService.UploadImageToAzureBlob(FileImage);
                    }
                    _context.Update(rank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RankExists(rank.Id))
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
            return View(rank);
        }

        // GET: Admin/Ranks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rank = await _context.Ranks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rank == null)
            {
                return NotFound();
            }

            return View(rank);
        }

        // POST: Admin/Ranks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var rank = await _context.Ranks.FindAsync(id);
            if (rank != null)
            {
                if(rank.Image != null)
                {
                    _imageService.DeleteImageFromAzureBlob(rank.Image);
                }
                _context.Ranks.Remove(rank);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RankExists(Guid id)
        {
            return _context.Ranks.Any(e => e.Id == id);
        }
    }
}
