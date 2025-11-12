using Microsoft.EntityFrameworkCore;
using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using ProyectoSubasta.Services;
using System;
using System.Collections.Generic;

namespace ProyectoSubasta.Controllers
{
    public class SubastaController
    {
        private readonly SubastaService service;

        public SubastaController(SubastaContext context)
        {
            service = new SubastaService(context);
        }

        public bool CrearSubasta(string articulo, Subastador subastador, decimal precioInicial, decimal precioPuja, DateTime fecha, DateTime horarioInicio, decimal duracion)
        {
            return service.CrearSubasta(new Subasta(articulo, subastador, precioInicial, precioPuja, fecha, horarioInicio, duracion));
        }

        public bool Pujar(int subastaId, int postorId)
        {
            return service.Pujar(subastaId, postorId);
        }

        public bool FinalizarSubasta(int subastaId)
        {
            return service.FinalizarSubasta(subastaId);

        }
        public Postor ObtenerGanador(int subastaId)
        {
            return service.ObtenerGanador(subastaId);
        }

        public bool EgresoPostor(int subastaId, int postorId)
        {
            return service.EgresoPostor(subastaId, postorId);
        }

        public bool IngresoPostor(int subastaId, int postorId)
        {
            return service.IngresoPostor(subastaId, postorId);
        }

        public bool EliminarSubasta(int subastaId)
        {
            return service.EliminarSubasta(subastaId);
        }

        public List<Subasta> ListaSubastas()
        {
            return service.ListaSubastas();
        }

        public Subasta ObtenerSubasta(int subastaId)
        {
            return service.ObtenerSubasta(subastaId);
        }

        public List<Subasta> ListaSubastasPorPostor(int dni)
        {
            return service.ListaSubastasPorPostor(dni);
        }

        public List<Subasta> ListaSubastasPorSubastador(int subastadorId)
        {
            return service.ListaSubastasPorSubastador(subastadorId);
        }
    }
}


