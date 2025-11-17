using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoSubasta.Models;

namespace ProyectoSubasta.Repository
{
    public class SubastaRepository
    {
        private readonly DBcontext _context;

        public SubastaRepository(DBcontext context)
        {
            _context = context;
        }

        public bool CrearSubasta(Subasta subasta)
        {
            _context.Subastas.Add(subasta);
            _context.SaveChanges();
            return true;
        }

        public bool ActualizarSubasta(Subasta subasta)
        {
            _context.Entry(subasta).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
        
        public bool EliminarSubasta(int subastaId)
        {
            var subasta = _context.Subastas.Find(subastaId);
            if (subasta == null)
            {
                return false;
            }
            _context.Subastas.Remove(subasta);
            _context.SaveChanges();
            return true;
        }


        public Subasta? ObtenerSubasta(int subastaId)
        {
            return _context.Subastas.FirstOrDefault(s => s.Id == subastaId);
        }

        public Subasta? ObtenerSubastaCompleta(int subastaId)
        {
            return _context.Subastas.Include(s => s.Subastador).Include(s => s.Ganador)
                .FirstOrDefault(s => s.Id == subastaId);
        }

        public List<Subasta> ListaSubastas()
        {
            return _context.Subastas.Include(s => s.Subastador).AsNoTracking().ToList();
        }

        public List<Subasta> FiltrarSubastasPorPostor(int dni)
        {
            return _context.Subastas.Include(s => s.Postores).Include(s => s.Subastador).AsNoTracking()
                .Where(s => s.Postores.Any(p => p.Dni == dni)).ToList();
        }

        public List<Subasta> FiltrarSubastasPorSubastador(int subastadorId)
        {
            return _context.Subastas.Include(s => s.Subastador).AsNoTracking().
                Where(s => s.Subastador.Dni == subastadorId).ToList();
        }

        public Postor? ObtenerPostor(int postorId)
        {
            return _context.Postores.Find(postorId);
        }
    }
}