using ProyectoSubasta.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoSubasta.Repository
{
    public class PostorRepository
    {
        private readonly DBcontext context;

        public PostorRepository(DBcontext _context)
        {
            context = _context;
        }

        public bool AgregarPostor(Postor postor)
        {
            context.Postores.Add(postor);
            context.SaveChanges();
            return true;
        }

        public Postor ObtenerPorId(int dni)
        {
            return context.Postores.Find(dni);
        }

        public List<Postor> ObtenerTodos()
        {
            return context.Postores.ToList();
        }

        public bool EliminarPostor(Postor postor)
        {
            context.Postores.Remove(postor);
            context.SaveChanges();
            return true;
        }
    }
}