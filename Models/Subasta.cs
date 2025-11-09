using System;
using System.Collections.Generic;

namespace ProyectoSubasta.Models
{
    public class Subasta
    {
        public int id;
        public string articulo;
        public Subastador subastador;
        public decimal precioInicial;
        public decimal precioPuja;
        public DateTime fecha;
        public DateTime horarioInicio;
        public decimal duracion;
        public int pujas = 0;
        public Postor? ganador;
        public List<Postor> postores;
        public bool finalizada;

        public Subasta(string articulo, Subastador subastador, decimal precioInicial, decimal precioPuja, DateTime fecha, DateTime horarioInicio, decimal duracion)
        {
            Articulo = articulo;
            Subastador = subastador;
            PrecioInicial = precioInicial;
            PrecioPuja = precioInicial;
            Fecha = fecha;
            HorarioInicio = horarioInicio;
            Duracion = duracion;
            Postores = new List<Postor>();
            Finalizada = false;
            //pujas = 0;
        }
        public Subasta()
        {

        }

        public decimal PrecioInicial
        {
            get => precioInicial;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El precio inicial no puede ser negativo.");
                precioInicial = value;
            }
        }
        public decimal PrecioPuja
        {
            get => precioPuja;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El precio de la puja no puede ser negativo.");
                precioPuja = value;
            }
        }

        public decimal Duracion
        {
            get => duracion;
            set
            {
                if (value < 0)
                    throw new ArgumentException("La duración no puede ser negativa.");
                duracion = value;
            }
        }
        public int Pujas
        {
            get => pujas;
            set
            { 
                { pujas = value; }
            }
        }
        public string Estado
        {
            get
            {
                if (Finalizada == false)
                {
                    return "Abierta";
                }
                else
                {
                    return "Cerrada";
                }
            }
        }
        public int Id { get; set; }
        public string Articulo { get; set; }
        public Subastador Subastador { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HorarioInicio { get; set; }
        public Postor? Ganador { get; set; }
        public List<Postor> Postores { get; set; }
        public bool Finalizada { get; set; }
    }
}