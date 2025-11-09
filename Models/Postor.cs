using System.ComponentModel.DataAnnotations;

namespace ProyectoSubasta.Models
{
    public class Postor
    {
        public int dni;
        public string nombre;
        public string apellido;


        public Postor(int dni, string nombre, string apellido)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} (DNI: {Dni})";
        }

        [Key]
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
