using System.Collections.Generic;
using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;


namespace ProyectoSubasta.Services
{
    public class SubastadorService
    {
        private readonly SubastadorRepository repository;

        public SubastadorService(DBcontext context)
        {
            repository = new SubastadorRepository(context);
        }

        public bool CrearSubastador(Subastador subastador)
        {
            Subastador? existe = repository.ObtenerPorId(subastador.Dni);
            if (existe != null)
            {
                return false;
            }
            return repository.AgregarSubastador(subastador);
        }

        public List<Subastador> ObtenerSubastadores()
        {                                                                                                               
            return repository.ObtenerTodos();
        }

        public Subastador ObtenerSubastador(int dni)
        {
            return repository.ObtenerPorId(dni);
        }

        public bool EliminarSubastador(int dni)
        {
            Subastador? subastador = repository.ObtenerPorId(dni);
            if (subastador == null)
            {
                return false;
            }
            return repository.EliminarSubastador(subastador);
        }
    }
}

