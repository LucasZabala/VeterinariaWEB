using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Logic.Models
{
    public class Mascota
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public int Edad { get; set; }
        [Required, Column(TypeName = "decimal(10,2)")]
        public double Peso { get; set; }
        [Required, NotNull]
        public Dueno? Dueno { get; set; }
        [Required, NotNull]
        public Especie? Especie { get; set; }

    }
}
