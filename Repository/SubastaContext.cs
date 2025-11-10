using Microsoft.EntityFrameworkCore;
using ProyectoSubasta.Models; 

namespace ProyectoSubasta.Repository
{
    public class SubastaContext : DbContext
    {
        public DbSet<Subasta> Subastas { get; set; }
        public DbSet<Postor> Postores { get; set; }
        public DbSet<Subastador> Subastadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=subastas.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Define la relación Muchos-a-Muchos (Postores <-> Subastas)
            modelBuilder.Entity<Subasta>()
                .HasMany(s => s.Postores) // Una Subasta tiene muchos Postores
                .WithMany(p => p.Subastas); // Un Postor tiene muchas Subastas

            // 2. Define la relación del Ganador (Subasta -> Postor)
            modelBuilder.Entity<Subasta>()
                .HasOne(s => s.Ganador) // Una Subasta tiene un Ganador
                .WithMany() // Un Postor puede ganar muchas, pero no necesitamos una lista "SubastasGanadas"
                .HasForeignKey("GanadorDni") // Define la clave foránea
                .IsRequired(false); // El ganador puede ser nulo
        }
    }
}