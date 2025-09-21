using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Logic.Models;

namespace Veterinaria.Logic.Data
{
    public class VeterinariaDbContext : DbContext
    {
        public VeterinariaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Dueno> Duenos { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mascota>()
                .HasOne(m => m.Dueno)
                .WithMany(d => d.Mascotas)
                .HasForeignKey(m => m.DuenoDNI);

            modelBuilder.Entity<Mascota>()
                 .HasOne(m => m.Especie)
                 .WithMany(e => e.Mascotas)
                 .HasForeignKey(m => m.EspecieId);

        }
    }
}
