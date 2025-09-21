using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Logic.Data;
using Veterinaria.Logic.Models;

namespace Veterinaria.Web.Controllers
{
    public class DuenoesController : Controller
    {
        private readonly VeterinariaDbContext _context;

        public DuenoesController(VeterinariaDbContext context)
        {
            _context = context;
        }

        // GET: Duenoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Duenos.ToListAsync());
        }

        // GET: Duenoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Duenos
                .FirstOrDefaultAsync(m => m.DNI == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        // GET: Duenoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Duenoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,DNI")] Dueno dueno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dueno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dueno);
        }

        // GET: Duenoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Duenos.FindAsync(id);
            if (dueno == null)
            {
                return NotFound();
            }
            return View(dueno);
        }

        // POST: Duenoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nombre,Apellido,DNI")] Dueno dueno)
        {
            if (id != dueno.DNI)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dueno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuenoExists(dueno.DNI))
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
            return View(dueno);
        }

        // GET: Duenoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Duenos
                .FirstOrDefaultAsync(m => m.DNI == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        // POST: Duenoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dueno = await _context.Duenos.FindAsync(id);
            if (dueno != null)
            {
                _context.Duenos.Remove(dueno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuenoExists(string id)
        {
            return _context.Duenos.Any(e => e.DNI == id);
        }
    }
}
