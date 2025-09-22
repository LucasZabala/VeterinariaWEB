using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Logic.Models;

namespace Veterinaria.Logic.Interfaces
{
    public interface IEspecieService
    {
        public Task<IEnumerable<Especie>> GetEspeciesAllAsync();
        public Task<Especie> GetEspecieByIdAsync(int id);
        public Task AddEspecieAsync(Especie especie);
        public Task UpdateEspecieAsync(Especie especie);
        public Task DeleteEspecieAsync(int id);
        public Task<bool> EspcieExistAsync(Especie especie);
    }
}
