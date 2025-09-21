using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.Logic.Models
{
    public class Dueno
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(50), NotNull]
        public string? Nombre { get; set; }
        [Required, MaxLength(50), NotNull]
        public string? Apellido { get; set; }
        [Key, Required, MaxLength(50), NotNull]
        public string? DNI { get; set; }
        [JsonIgnore]
        public ICollection<Mascota>? Mascotas { get; set; }
    }
}
