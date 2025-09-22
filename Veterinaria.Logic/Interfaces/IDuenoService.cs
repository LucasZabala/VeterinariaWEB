using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Logic.Models;

namespace Veterinaria.Logic.Interfaces
{
    public interface IDuenoService
    {
        public Task<IEnumerable<Dueno>> GetDuenosAllAsync();
        public Task<Dueno> GetDuenoByDNIAsync(string dni);
        public Task<string> GetFirstLastNameDuenoByDNIAsync(string dni);
        public Task AddDuenoAsync(Dueno dueno);
        public Task UpdateDuenoAsync(Dueno dueno);
        public Task DeleteDuenoAsync(string dni);
    }
}
