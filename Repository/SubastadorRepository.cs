using ProyectoSubasta.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSubasta.Repository
{
    public class SubastadorRepository(SubastaContext context)
    {
        public void Agregar(Subastador subastador)
        {
            context.Subastadores.Add(subastador);
            context.SaveChanges();
        }

        public List<Subastador> ObtenerTodos()
        {
            return context.Subastadores.ToList();
        }

        public Subastador? ObtenerPorId(int dni)
        {
            return context.Subastadores.Find(dni);
        }

        public bool Eliminar(int dni)
        {
            var subastador = ObtenerPorId(dni);
            if (subastador != null)
            {
                context.Subastadores.Remove(subastador);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}