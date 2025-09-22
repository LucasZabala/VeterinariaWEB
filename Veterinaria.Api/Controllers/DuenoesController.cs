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
    public class DuenoesController : Controller
    {
        private readonly VeterinariaDbContext _context;
        private readonly IDuenoService _duenoService;

        public DuenoesController(VeterinariaDbContext context, IDuenoService duenoService)
        {
            _context = context;
            _duenoService = duenoService;
        }

        // GET: Duenoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Duenos.ToListAsync());
        }

        // GET: Duenoes/Details/5
        public async Task<IActionResult> Details(string dni)
        {
            try
            {
                var dueno = await _duenoService.GetDuenoByDNIAsync(dni);
                return View(dueno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
                try
                {
                    await _duenoService.AddDuenoAsync(dueno);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return View(dueno);
        }

        // GET: Duenoes/Edit/5
        public async Task<IActionResult> Edit(string dni)
        {
            try
            {
                var dueno = await _duenoService.GetDuenoByDNIAsync(dni);
                return View(dueno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
                    await _duenoService.UpdateDuenoAsync(dueno);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dueno);
        }

        // GET: Duenoes/Delete/5
        public async Task<IActionResult> Delete(string dni)
        {
            try
            {
                var dueno = await _duenoService.GetDuenoByDNIAsync(dni);
                return View(dueno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Duenoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string dni)
        {
            await _duenoService.DeleteDuenoAsync(dni);
            return RedirectToAction(nameof(Index));
        }

    }
}
