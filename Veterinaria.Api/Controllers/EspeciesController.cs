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
    public class EspeciesController : Controller
    {
        private readonly VeterinariaDbContext _context;
        private readonly IEspecieService _especieService;

        public EspeciesController(VeterinariaDbContext context, IEspecieService especieService)
        {
            _context = context;
            _especieService = especieService;
        }

        // GET: Especies
        public async Task<IActionResult> Index()
        {
            var especies = await _especieService.GetEspeciesAllAsync();
            return View(especies);
        }

        // GET: Especies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var especie = await _especieService.GetEspecieByIdAsync(id);
            return View(especie);
        }

        // GET: Especies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _especieService.AddEspecieAsync(especie);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
            return View(especie);
        }

        // GET: Especies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var especie = await _especieService.GetEspecieByIdAsync(id);
            return View(especie);
        }

        // POST: Especies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Especie especie)
        {
            if (id != especie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _especieService.UpdateEspecieAsync(especie);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
            return View(especie);
        }

        // GET: Especies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var especie = await _especieService.GetEspecieByIdAsync(id);
            return View(especie);
        }

        // POST: Especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _especieService.DeleteEspecieAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
