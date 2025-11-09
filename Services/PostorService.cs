using System.Collections.Generic;
using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;


namespace ProyectoSubasta.Services
{
    public class PostorService
    {
        private readonly PostorRepository repository;

        public PostorService(SubastaContext context)
        {
            repository = new PostorRepository(context);
        }

        public bool CrearPostor(Postor postor)
        {            
            Postor existe = repository.ObtenerPorId(postor.Dni);  
            if (existe != null)
            {
                return false;
            }
            repository.AgregarPostor(postor);
            return true;
        }

        public List<Postor> ObtenerPostores()
        {
            return repository.ObtenerTodos();
        }

        public Postor ObtenerPostor(int dni)
        {
            return repository.ObtenerPorId(dni);
        }

        public bool EliminarPostor(int dni)
        {
            Postor existe = repository.ObtenerPorId(dni);
            if (existe == null)
            {
                return false;
            }
            repository.EliminarPostor(dni);
            return true;
        }
    }
}
