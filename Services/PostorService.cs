using System.Collections.Generic;
using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;


namespace ProyectoSubasta.Services
{
    public class PostorService
    {
        private readonly PostorRepository repository;

        public PostorService(DBcontext context)
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
            return repository.AgregarPostor(postor);
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
            Postor postor = repository.ObtenerPorId(dni);
            if (postor == null)
            {
                return false;
            }
            return repository.EliminarPostor(postor);
        }
    }
}
