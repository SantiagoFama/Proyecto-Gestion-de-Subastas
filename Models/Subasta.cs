using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ProyectoSubasta.Models
{
    public class Subasta
    {
        private int _id;
        private string _articulo;
        private Subastador _subastador;
        private decimal _precioInicial;
        private decimal _precioPuja;
        private DateTime _fecha;
        private DateTime _horarioInicio;
        private decimal _duracion;
        private int _pujas;
        private Postor? _ganador;
        private List<Postor> _postores;
        private bool _finalizada;

        public Subasta(string articulo, Subastador subastador, decimal precioInicial, decimal precioPuja, DateTime fecha, DateTime horarioInicio, decimal duracion)
        {
            Articulo = articulo;
            Subastador = subastador;
            PrecioInicial = precioInicial;
            PrecioPuja = precioPuja;
            Fecha = fecha;
            HorarioInicio = horarioInicio;
            Duracion = duracion;
            Postores = new List<Postor>();
            Finalizada = false;
            Pujas = 0;
        }
        public Subasta()
        {

        }

        public decimal PrecioInicial
        {
            get => _precioInicial;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio inicial no puede ser menor que 0.");
                _precioInicial = value;
            }
        }
        public decimal PrecioPuja
        {
            get => _precioPuja;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio de la puja no puede ser menor que 0.");
                _precioPuja = value;
            }
        }

        public decimal Duracion
        {
            get => _duracion;
            set
            {
                if (value < 30)
                    throw new ArgumentException("La duración no puede ser menor a 30 minutos.");
                _duracion = value;
            }
        }
        public int Pujas
        {
            get => _pujas;
            set => _pujas = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Articulo
        {
            get => _articulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El artículo no puede estar vacío.");
                _articulo = value;
            }
        }

        public Subastador Subastador
        {
            get => _subastador;
            set => _subastador = value;
        }

        public DateTime Fecha
        {
            get => _fecha;
            set => _fecha = value;
        }

        public DateTime HorarioInicio
        {
            get => _horarioInicio;
            set => _horarioInicio = value;
        }

        public Postor? Ganador
        {
            get => _ganador;
            set => _ganador = value;
        }

        public List<Postor> Postores
        {
            get => _postores;
            set => _postores = value;
        }

        public bool Finalizada
        {
            get => _finalizada;
            set => _finalizada = value;
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
        public decimal PrecioActual
        {
            get
            {
                if (Pujas > 0)
                {
                    return ((PrecioPuja * Pujas) + PrecioInicial);
                }
                else
                {
                    return PrecioInicial;
                }
            }
        }
    }
}