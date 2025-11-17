using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using System.Collections.Generic;
using System.Linq;


namespace ProyectoSubasta.Services
{
    public class SubastaService
    {
        private readonly SubastaRepository repository;

        public SubastaService(DBcontext context)
        {
            repository = new SubastaRepository(context);
        }


        public bool CrearSubasta(Subasta subasta)
        {
            Subasta? existe = repository.ObtenerSubasta(subasta.Id);
            if (existe != null)
                return false;

            return repository.CrearSubasta(subasta);
        }


        public bool Pujar(int subastaId, int postorId)
        {
            Subasta? subasta = repository.ObtenerSubasta(subastaId);
            if (subasta == null || subasta.Estado == "Cerrada")
                return false;

            Postor? postor = repository.ObtenerPostor(postorId);
            subasta.Ganador = postor;
            return repository.ActualizarSubasta(subasta);
        }


        public bool FinalizarSubasta(int subastaId)
        {
            Subasta? subasta = repository.ObtenerSubasta(subastaId);
            if (subasta == null)
                return false;

            if (subasta.Estado == "Cerrada" || subasta.Estado == "Programada")
            {
                return false; 
            }

            subasta.Estado = "Cerrada";
            return repository.ActualizarSubasta(subasta);
        }


        public Postor ObtenerGanador(int subastaId)
        {
            Subasta? subasta = repository.ObtenerSubasta(subastaId);

            return subasta.Ganador;
        }


        public bool IngresoPostor(int subastaId, int postorId)
        {
            Subasta? subasta = repository.ObtenerSubasta(subastaId);
            if (subasta == null || subasta.Estado == "Cerrada")
                return false;

            bool estaIngresado = subasta.Postores.Any(p => p.Dni == postorId);
            if (estaIngresado)
                return false;

            Postor? postor = repository.ObtenerPostor(postorId);
            subasta.Postores.Add(postor);
            return repository.ActualizarSubasta(subasta);
        }


        public bool EgresoPostor(int subastaId, int postorId)
        {
            Subasta? subasta = repository.ObtenerSubasta(subastaId);
            if (subasta == null || subasta.Estado =="Cerrada")
                return false;

            bool estaIngresado = subasta.Postores.Any(p => p.Dni == postorId);
            if (!estaIngresado)
                return false;

            Postor? postor = repository.ObtenerPostor(postorId);
            subasta.Postores.Remove(postor);
            return repository.ActualizarSubasta(subasta);
        }


        public bool EliminarSubasta(int subastaId)
        {
            Subasta subasta = repository.ObtenerSubasta(subastaId);
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


        public List<Subasta> FiltrarSubastasPorPostor(int dni)
        {
            return repository.FiltrarSubastasPorPostor(dni);
        }

        public List<Subasta> FiltrarSubastasPorSubastador(int subastadorId)
        {
            return repository.FiltrarSubastasPorSubastador(subastadorId);
        }
    }
}
