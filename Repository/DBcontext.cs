using Microsoft.EntityFrameworkCore;
using ProyectoSubasta.Models;
using System;     
using System.IO;  

namespace ProyectoSubasta.Repository
{
    public class DBcontext : DbContext
    {
        public DbSet<Subasta> Subastas { get; set; }
        public DbSet<Postor> Postores { get; set; }
        public DbSet<Subastador> Subastadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            var dbPath = Path.Combine(path, "subastas_proyecto.db");

            options.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subasta>().HasMany(s => s.Postores).WithMany(p => p.Subastas);
            modelBuilder.Entity<Subasta>().HasOne(s => s.Ganador).WithMany().HasForeignKey("GanadorDni").IsRequired(false);
        }
    }
}