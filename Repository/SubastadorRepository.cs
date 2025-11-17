using ProyectoSubasta.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoSubasta.Repository
{
    public class SubastadorRepository
    {
        private readonly DBcontext context;

        public SubastadorRepository(DBcontext _context)
        {
            context = _context;
        }
            
        public bool AgregarSubastador(Subastador subastador)
        {
            context.Subastadores.Add(subastador);
            context.SaveChanges();
            return true;
        }

        public List<Subastador> ObtenerTodos()
        {
            return context.Subastadores.ToList();
        }

        public Subastador? ObtenerPorId(int dni)
        {
            return context.Subastadores.Find(dni);
        }

        public bool EliminarSubastador(Subastador subastador)
        {
            context.Subastadores.Remove(subastador);
            context.SaveChanges();
            return true;
        }
    }
}