using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_ContratoV1.Data;
using Web_ContratoV1.Entidades;

namespace Web_ContratoV1.Controllers
{
    public class SedesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SedesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sedes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBT_SEDES.ToListAsync());
        }

        // GET: Sedes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBT_SEDES = await _context.TBT_SEDES
                .FirstOrDefaultAsync(m => m.IDD_SEDES == id);
            if (tBT_SEDES == null)
            {
                return NotFound();
            }

            return View(tBT_SEDES);
        }

        // GET: Sedes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDD_SEDES,COD_SEDES,DES_SEDES")] TBT_SEDES tBT_SEDES)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBT_SEDES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBT_SEDES);
        }

        // GET: Sedes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBT_SEDES = await _context.TBT_SEDES.FindAsync(id);
            if (tBT_SEDES == null)
            {
                return NotFound();
            }
            return View(tBT_SEDES);
        }

        // POST: Sedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDD_SEDES,COD_SEDES,DES_SEDES")] TBT_SEDES tBT_SEDES)
        {
            if (id != tBT_SEDES.IDD_SEDES)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBT_SEDES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBT_SEDESExists(tBT_SEDES.IDD_SEDES))
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
            return View(tBT_SEDES);
        }

        // GET: Sedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBT_SEDES = await _context.TBT_SEDES
                .FirstOrDefaultAsync(m => m.IDD_SEDES == id);
            if (tBT_SEDES == null)
            {
                return NotFound();
            }

            return View(tBT_SEDES);
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tBT_SEDES = await _context.TBT_SEDES.FindAsync(id);
            _context.TBT_SEDES.Remove(tBT_SEDES);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBT_SEDESExists(int id)
        {
            return _context.TBT_SEDES.Any(e => e.IDD_SEDES == id);
        }
    }
}
