using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Logic.Interfaces;
using Veterinaria.Logic.Models;

namespace Veterinaria.Logic.Services
{
    public class EspecieService : IEspecieService
    {
        private readonly IEspecieRepository _especieRepository;

        public EspecieService(IEspecieRepository especieRepository)
        {
            _especieRepository = especieRepository;
        }

        public async Task<IEnumerable<Especie>> GetEspeciesAllAsync()
        {
            return await _especieRepository.GetEspeciesAllAsync();
        }

        public async Task<Especie> GetEspecieByIdAsync(int id)
        {
            var especie = await _especieRepository.GetEspecieByIdAsync(id);
            return especie;
        }
        public async Task AddEspecieAsync(Especie especie)
        {
            if(await _especieRepository.EspcieExistAsync(especie.Nombre))
            {
                throw new Exception("Nombre de Especie existente");
            }
            await _especieRepository.AddEspecieAsync(especie);
        }
        public async Task UpdateEspecieAsync(Especie especie)
        {
            if (await _especieRepository.EspcieExistAsync(especie.Nombre))
            {
                throw new Exception("Nombre de Especie existente");
            }
            await _especieRepository.UpdateEspecieAsync(especie);
        }
        public async Task DeleteEspecieAsync(int id)
        {
            var especie = await _especieRepository.GetEspecieByIdAsync(id);
            await _especieRepository.DeleteEspecieAsync(especie);
        }        

    }
}
