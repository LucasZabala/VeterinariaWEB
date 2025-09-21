using Microsoft.EntityFrameworkCore;
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
    public class Especie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Display(Name = "Nombre de Especie"), MaxLength(50), Unicode, NotNull]
        public string? Nombre { get; set; }
        [JsonIgnore]
        public ICollection<Mascota>? Mascotas { get; set; }
    }
}
