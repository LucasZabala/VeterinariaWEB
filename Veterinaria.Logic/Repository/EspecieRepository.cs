using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Logic.Data;
using Veterinaria.Logic.Interfaces;
using Veterinaria.Logic.Models;

namespace Veterinaria.Logic.Repository
{
    public class EspecieRepository : IEspecieRepository
    {
        private readonly VeterinariaDbContext _context;

        public EspecieRepository(VeterinariaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Especie>> GetEspeciesAllAsync()
        {
            return await _context.Especies.ToListAsync();
        }
        public async Task<Especie> GetEspecieByIdAsync(int id)
        {
            var especie = await _context.Especies.FirstOrDefaultAsync(e => e.Id == id);
            return especie;
        }
        public async Task AddEspecieAsync(Especie especie)
        {
            await _context.Especies.AddAsync(especie);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateEspecieAsync(Especie especie)
        {
            _context.Especies.Update(especie);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEspecieAsync(Especie especie)
        {
            _context.Especies.Remove(especie);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EspcieExistAsync(string nombre)
        {
            return await _context.Especies.AnyAsync(e => e.Nombre == nombre);
        }

    }
}
