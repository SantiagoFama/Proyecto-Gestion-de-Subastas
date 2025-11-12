using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace ProyectoSubasta.Services
{
    public class SubastaService
    {
        private readonly SubastaRepository repository;

        public SubastaService(SubastaContext context)
        {
            repository = new SubastaRepository(context);
        }


        public bool CrearSubasta(Subasta subasta)
        {
            var existe = repository.ObtenerSubasta(subasta.Id);
            if (existe != null)
                return false;

            return repository.CrearSubasta(subasta);
        }


        public bool Pujar(int subastaId, Postor postor)
        {
            var subasta = repository.ObtenerSubasta(subastaId);
            if (subasta.Finalizada)
                return false;
            
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

            var postor = repository.ObtenerPostor(postorId);
            subasta.Postores.Add(postor);
            return repository.ActualizarSubasta(subasta);
        }


        public bool EgresoPostor(int subastaId, int postorId)
        {
            Subasta subasta = repository.ObtenerSubasta(subastaId);

            bool estaIngresado = subasta.Postores.Any(p => p.Dni == postorId);
            if (!estaIngresado)
                return false;

            Postor postor = repository.ObtenerPostor(postorId);
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
