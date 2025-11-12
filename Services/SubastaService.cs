using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using System.Collections.Generic;
using System.Linq;


namespace ProyectoSubasta.Services
{
    public class SubastaService
    {
        private readonly SubastaRepository repository;
        private readonly SubastaContext _context;
        public SubastaService(SubastaContext context)
        {
            _context = context;
            repository = new SubastaRepository(_context);
        }

        public bool CrearSubasta(Subasta subasta)
        {
            Subasta existe = repository.ObtenerSubasta(subasta.Id);
            if (existe != null)
            {
                return false;
            }
            return repository.CrearSubasta(subasta);
        }

        public bool Pujar(int subastaId, Postor postor)
        {
            var subasta = repository.ObtenerSubasta(subastaId);
            if (subasta.Finalizada)
            {
                return false;
            }
            subasta.Ganador = postor;
            return repository.ActualizarSubasta(subasta);
        }

        public bool FinalizarSubasta(int subastaId)
        {
            var subasta = repository.ObtenerSubasta(subastaId);

            subasta.Finalizada = true;
            return repository.ActualizarSubasta(subasta);
        }

        public Postor ObtenerGanador(int subastaId)
        {
            var subasta = repository.ObtenerSubasta(subastaId);

            repository.ActualizarSubasta(subasta);
            return subasta.Ganador;
        }

        public bool IngresoPostor(int subastaId, int postorId)
        {
            var subasta = repository.ObtenerSubasta(subastaId);

            bool estaIngresado = subasta.Postores.Any(p => p.Dni == postorId);
            if (estaIngresado)
                return false;

            var postor = _context.Postores.Find(postorId);
            subasta.Postores.Add(postor);
            return repository.ActualizarSubasta(subasta);
        }

        public bool EgresoPostor(int subastaId, int postorId)
        {
            var subasta = repository.ObtenerSubasta(subastaId);

            bool estaIngresado = subasta.Postores.Any(p => p.Dni == postorId);
            if (!estaIngresado)
                return false;

            var postor = _context.Postores.Find(postorId);
            subasta.Postores.Remove(postor);
            return repository.ActualizarSubasta(subasta);
        }

        public bool EliminarSubasta(int subastaId)
        {
            var subasta = repository.ObtenerSubasta(subastaId);
            
            if (subasta == null)
                return false;

            return repository.EliminarSubasta(subastaId);
        }
        public List<Subasta> ListaSubastas()
        {
            return repository.ListaSubastas();
        }

        public Subasta ObtenerSubasta(int subastaId)
        {
            return repository.ObtenerSubasta(subastaId);
        }

        public List<Subasta> ListaSubastasPorPostor(int dni)
        {
            return repository.ListaSubastasPorPostor(dni);
        }
    }
}
