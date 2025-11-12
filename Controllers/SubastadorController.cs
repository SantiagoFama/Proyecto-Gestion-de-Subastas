using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using ProyectoSubasta.Services;
using System.Collections.Generic;


namespace ProyectoSubasta.Controllers
{
    public class SubastadorController
    {
        private readonly SubastadorService Service;

        public SubastadorController(DBcontext context)
        {
            Service = new SubastadorService(context);
        }

        public bool CrearSubastador(int dni, string nombre, string apellido)
        {
            return Service.CrearSubastador(new Subastador(dni, nombre, apellido));
        }

        public List<Subastador> ListarSubastadores()
        {
            return Service.ObtenerSubastadores();
        }

        public Subastador ObtenerSubastador(int dni)
        {
            return Service.ObtenerSubastador(dni);
        }

        public bool EliminarSubastador(int dni)
        {
            return Service.EliminarSubastador(dni);
        }
    }
}

