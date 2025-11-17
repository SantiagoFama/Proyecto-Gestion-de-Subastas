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
            
        public void Agregar(Subastador subastador)
        {
            context.Subastadores.Add(subastador);
            context.SaveChanges();
        }

        public List<Subastador> ObtenerTodos()
        {
            return context.Subastadores.ToList();
        }

        public Subastador? ObtenerPorId(int dni)
        {
            return context.Subastadores.Find(dni);
        }

        public bool Eliminar(int dni)
        {
            Subastador? subastador = ObtenerPorId(dni);
            if (subastador == null)
                return false;

            context.Subastadores.Remove(subastador);
            context.SaveChanges();
            return true;
        }
    }
}