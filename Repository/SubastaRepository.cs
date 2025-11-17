using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoSubasta.Models;

namespace ProyectoSubasta.Repository
{
    public class SubastaRepository
    {
        private readonly DBcontext context;

        public SubastaRepository(DBcontext _context)
        {
            context = _context;
        }

        public bool CrearSubasta(Subasta subasta)
        {
            context.Subastas.Add(subasta);
            context.SaveChanges();
            return true;
        }

        public bool ActualizarSubasta(Subasta subasta)
        {
            context.Entry(subasta).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }
        
        public bool EliminarSubasta(int subastaId)
        {
            var subasta = context.Subastas.Find(subastaId);
            if (subasta == null)
            {
                return false;
            }
            context.Subastas.Remove(subasta);
            context.SaveChanges();
            return true;
        }


        public Subasta? ObtenerSubasta(int subastaId)
        {
            return context.Subastas.FirstOrDefault(s => s.Id == subastaId);
        }

        public Subasta? ObtenerSubastaCompleta(int subastaId)
        {
            return context.Subastas.Include(s => s.Subastador).Include(s => s.Ganador)
                .Include(s => s.Postores)
                .FirstOrDefault(s => s.Id == subastaId);
        }

        public List<Subasta> ListaSubastas()
        {
            return context.Subastas.Include(s => s.Subastador).AsNoTracking().ToList();
        }

        public List<Subasta> FiltrarSubastasPorPostor(int postorId)
        {
            // Usé el AsNoTracking porque si no los DataGrid no se actualizan correctamente al 
            // estar actualizandose cada 5 segundos
            return context.Subastas.Include(s => s.Postores).Include(s => s.Subastador).AsNoTracking()
                .Where(s => s.Postores.Any(p => p.Dni == postorId)).ToList();
        }

        public List<Subasta> FiltrarSubastasPorSubastador(int subastadorId)
        {
            return context.Subastas.Include(s => s.Subastador).AsNoTracking().
                Where(s => s.Subastador.Dni == subastadorId).ToList();
        }

        public Postor? ObtenerPostor(int postorId)
        {
            return context.Postores.Find(postorId);
        }
    }
}