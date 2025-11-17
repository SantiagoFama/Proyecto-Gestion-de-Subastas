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

        public void AgregarPostor(Postor postor)
        {
            context.Postores.Add(postor);
            context.SaveChanges();
        }

        public Postor ObtenerPorId(int dni)
        {
            return context.Postores.Find(dni);
        }

        public List<Postor> ObtenerTodos()
        {
            return context.Postores.ToList();
        }

        public void EliminarPostor(int dni)
        {
            Postor postorAEliminar = ObtenerPorId(dni);
            if (postorAEliminar != null)
            {
                context.Postores.Remove(postorAEliminar);
                context.SaveChanges();
            }
        }
    }
}