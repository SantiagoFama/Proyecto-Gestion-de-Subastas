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
            Subasta existe = repository.ObtenerSubasta(subasta.id);
            if (existe != null)
            {
                return false;
            }
            return repository.CrearSubasta(subasta);
        }

        public bool Pujar(int subastaId, Postor postor)
        {
            var subasta = repository.ObtenerSubasta(subastaId);
            if (subasta.finalizada)
            {
                return false;
            }
            subasta.Ganador = postor;
            return repository.ActualizarSubasta(subasta);
        }

        public bool FinalizarSubasta(int subastaId)
        {
            var subasta = repository.ObtenerSubasta(subastaId);

            subasta.finalizada = true;
            return repository.ActualizarSubasta(subasta);
        }

        public Postor ObtenerGanador(int subastaId)
        {
            var subasta = repository.ObtenerSubasta(subastaId);

            repository.ActualizarSubasta(subasta);
            return subasta.Ganador;
        }

        public bool IngresoPostor2(int subastaId, int postorId)
        {
            var subasta = repository.ObtenerSubasta(subastaId);

            var existe = subasta.Postores.Any(p => p.Dni == postorId);
            if (!existe)
            {
                
                //subasta.Postores.Add();
                return repository.ActualizarSubasta(subasta);
            }
            return false;
        }
        public bool IngresoPostor(int subastaId, int postorId)
        {
            var subasta = repository.ObtenerSubasta(subastaId);

            bool yaEstaUnido = subasta.Postores.Any(p => p.Dni == postorId);
            if (yaEstaUnido)
            {
                return false;
            }

            // --- AQUÍ ESTÁ LA RESPUESTA ---
            // No "creas" un postor, lo "buscas" en la base de datos
            // usando el ID que recibiste.
            var postorAAgregar = _context.Postores.Find(postorId);
            // --- --- --- --- --- --- --- ---

            // Si el postor no existe en la BD, no puedes agregarlo
            if (postorAAgregar == null)
            {
                return false;
            }

            // 5. Ahora sí, unes los dos objetos y guardas
            subasta.Postores.Add(postorAAgregar);
            return repository.ActualizarSubasta(subasta);
        }

        public bool EgresoPostor(int subastaId, Postor postor)
        {
            var subasta = repository.ObtenerSubasta(subastaId);

            subasta.postores.Remove(postor);
            return repository.ActualizarSubasta(subasta);
        }

        public bool EliminarSubasta(int subastaId)
        {
            var subasta = repository.ObtenerSubasta(subastaId);
            if (subasta == null)
            {
                return false;
            }
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
