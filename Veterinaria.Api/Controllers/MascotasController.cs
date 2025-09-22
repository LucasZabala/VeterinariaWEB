using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Logic.Data;
using Veterinaria.Logic.Interfaces;
using Veterinaria.Logic.Models;

namespace Veterinaria.Web.Controllers
{
    public class MascotasController : Controller
    {
        private readonly VeterinariaDbContext _context;
        private readonly IDuenoService _duenoService;

        public MascotasController(VeterinariaDbContext context, IDuenoService duenoService)
        {
            _context = context;
            _duenoService = duenoService;
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
            var veterinariaDbContext = _context.Mascotas.Include(m => m.Dueno).Include(m => m.Especie);
            return View(await veterinariaDbContext.ToListAsync());
        }

        // GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.Dueno)
                .Include(m => m.Especie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // GET: Mascotas/Create
        public IActionResult Create()
        {
            ViewData["DuenoDNI"] = new SelectList(_context.Duenos, "DNI", "DNI");
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Nombre");
            return View();
        }

        // POST: Mascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,Peso,DuenoDNI,NombreApellidoDueno,EspecieId")] Mascota mascota)
        {
            mascota.NombreApellidoDueno = await _duenoService.GetFirstLastNameDuenoByDNIAsync(mascota.DuenoDNI);
            if (ModelState.IsValid)
            {
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DuenoDNI"] = new SelectList(_context.Duenos, "DNI", "DNI", mascota.DuenoDNI);
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Nombre", mascota.EspecieId);
            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            ViewData["DuenoDNI"] = new SelectList(_context.Duenos, "DNI", "DNI", mascota.DuenoDNI);
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Nombre", mascota.EspecieId);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,Peso,DuenoDNI,NombreApellidoDueno,EspecieId,Registrado")] Mascota mascota)
        {
            if (id != mascota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    mascota.NombreApellidoDueno = await _duenoService.GetFirstLastNameDuenoByDNIAsync(mascota.DuenoDNI);
                    _context.Update(mascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaExists(mascota.Id))
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
            ViewData["DuenoDNI"] = new SelectList(_context.Duenos, "DNI", "DNI", mascota.DuenoDNI);
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Nombre", mascota.EspecieId);
            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.Dueno)
                .Include(m => m.Especie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota != null)
            {
                _context.Mascotas.Remove(mascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotaExists(int id)
        {
            return _context.Mascotas.Any(e => e.Id == id);
        }
    }
}
