using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Logic.Interfaces;
using Veterinaria.Logic.Models;

namespace Veterinaria.Logic.Services
{
    public class DuenoService : IDuenoService
    {
        private readonly IDuenoRepository _duenoRepository;

        public DuenoService(IDuenoRepository duenoRepository)
        {
            _duenoRepository = duenoRepository;
        }

        public async Task<IEnumerable<Dueno>> GetDuenosAllAsync()
        {
            var duenos = await _duenoRepository.GetDuenosAllAsync();
            return duenos;
        }

        public async Task<Dueno> GetDuenoByDNIAsync(string dni)
        {
            var dueno = await _duenoRepository.GetDuenoByDNIAsync(dni);
            return dueno;
        }

        public async Task<string> GetFirstLastNameDuenoByDNIAsync(string dni)
        {
            string namesDueno = await _duenoRepository.GetFirstLastNameDuenoByDNIAsync(dni);
            return namesDueno;
        }

        public async Task AddDuenoAsync(Dueno dueno)
        {
            await _duenoRepository.AddDuenoAsync(dueno);
        }

        public async Task UpdateDuenoAsync(Dueno dueno)
        {
            await _duenoRepository.UpdateDuenoAsync(dueno);
        }

        public async Task DeleteDuenoAsync(string dni)
        {
            var dueno = await _duenoRepository.GetDuenoByDNIAsync(dni);
            await _duenoRepository.DeleteDuenoAsync(dueno);
        }

    }
}
