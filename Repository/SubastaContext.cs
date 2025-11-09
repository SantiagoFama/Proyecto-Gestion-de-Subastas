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
    }
}