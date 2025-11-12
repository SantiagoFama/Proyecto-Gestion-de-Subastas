using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoSubasta.Models
{
    public class Postor
    {
        private int _dni;
        private string _nombre;
        private string _apellido;
        private List<Subasta> _subastas;

        public Postor(int dni, string nombre, string apellido)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            Subastas = new List<Subasta>();
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} (DNI: {Dni})";
        }

        [Key]
        public int Dni
        {
            get => _dni;
            set
            {
                if (value <= 0) throw new ArgumentException("El DNI debe ser positivo.");
                _dni = value;
            }
        }
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("El nombre no puede estar vacío.");
                _nombre = value;
            }
        }

        public string Apellido
        {
            get => _apellido;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("El apellido no puede estar vacío.");
                _apellido = value;
            }
        }
        public List<Subasta> Subastas 
        { 
            get => _subastas; 
            set => _subastas = value;
        }
    }
}
