using System.Collections.Generic;
using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using ProyectoSubasta.Services;


namespace ProyectoSubasta.Controllers
{
    public class PostorController
    {
        private readonly PostorService Service;

        public PostorController(DBcontext context)
        {
            Service = new PostorService(context);
        }

        public bool CrearPostor(int dni, string nombre, string apellido)
        {
            return Service.CrearPostor(new Postor(dni, nombre, apellido));
        }

        public List<Postor> ListarPostores()
        {
            return Service.ObtenerPostores();
        }

        public Postor ObtenerPostor(int dni)
        {
            return Service.ObtenerPostor(dni);
        }

        public bool EliminarPostor(int dni)
        {
            return Service.EliminarPostor(dni);
        }
        public List<Subasta> ListaSubastas()
        {
            // Implementación para obtener la lista de subastas disponibles para el postor
            // Esto puede implicar llamar a otro servicio o repositorio según la lógica de negocio
            return new List<Subasta>(); // Retorna una lista vacía como marcador de posición
        }
    }
}

