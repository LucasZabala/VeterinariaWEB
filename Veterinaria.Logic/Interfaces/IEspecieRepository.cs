using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Logic.Models;

namespace Veterinaria.Logic.Interfaces
{
    public interface IEspecieRepository
    {
        public Task<IEnumerable<Especie>> GetEspeciesAllAsync();
        public Task<Especie> GetEspecieByIdAsync(int id);
        public Task AddEspecieAsync(Especie especie);
        public Task UpdateEspecieAsync(Especie especie);
        public Task DeleteEspecieAsync(Especie especie);
        public Task<bool> EspcieExistAsync(string nombre);
    }
}
