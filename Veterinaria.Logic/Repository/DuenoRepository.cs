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
    public class DuenoRepository : IDuenoRepository
    {
        private readonly VeterinariaDbContext _context;

        public DuenoRepository(VeterinariaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dueno>> GetDuenosAllAsync()
        {
            return await _context.Duenos.ToListAsync();
        }

        public async Task<Dueno> GetDuenoByDNIAsync(string dni)
        {
            var dueno = await _context.Duenos.FirstOrDefaultAsync(d => d.DNI == dni);
            return dueno;
        }

        public async Task<string> GetFirstLastNameDuenoByDNIAsync(string dni)
        {
            var dueno = await _context.Duenos.FirstOrDefaultAsync(d => d.DNI == dni);
            var names = $"{dueno.Nombre} {dueno.Apellido}";
            return names;
        }

        public async Task AddDuenoAsync(Dueno dueno)
        {
            await _context.AddAsync(dueno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDuenoAsync(Dueno dueno)
        {
            _context.Update(dueno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDuenoAsync(Dueno dueno)
        {
            _context.Remove(dueno);
            await _context.SaveChangesAsync();
        }

    }
}
