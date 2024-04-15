using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPTLongChau.Areas.Admin.Models;
using FPTLongChau.Data;

namespace FPTLongChau.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShipModesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShipModesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ShipModes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShipModes.ToListAsync());
        }

        // GET: Admin/ShipModes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipMode = await _context.ShipModes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipMode == null)
            {
                return NotFound();
            }

            return View(shipMode);
        }

        // GET: Admin/ShipModes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ShipModes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] ShipMode shipMode)
        {
            if (ModelState.IsValid)
            {
                shipMode.Id = Guid.NewGuid();
                _context.Add(shipMode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipMode);
        }

        // GET: Admin/ShipModes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipMode = await _context.ShipModes.FindAsync(id);
            if (shipMode == null)
            {
                return NotFound();
            }
            return View(shipMode);
        }

        // POST: Admin/ShipModes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description")] ShipMode shipMode)
        {
            if (id != shipMode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipMode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipModeExists(shipMode.Id))
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
            return View(shipMode);
        }

        // GET: Admin/ShipModes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipMode = await _context.ShipModes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipMode == null)
            {
                return NotFound();
            }

            return View(shipMode);
        }

        // POST: Admin/ShipModes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var shipMode = await _context.ShipModes.FindAsync(id);
            if (shipMode != null)
            {
                _context.ShipModes.Remove(shipMode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipModeExists(Guid id)
        {
            return _context.ShipModes.Any(e => e.Id == id);
        }
    }
}
