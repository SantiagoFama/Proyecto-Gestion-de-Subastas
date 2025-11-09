using ProyectoSubasta.Controllers;
using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using System;
using System.Windows.Forms;

namespace ProyectoSubasta.Views
{
    public partial class CrearSubasta : Form
    {
        private readonly SubastaController subastaController;
        private readonly SubastadorController subastadorController;

        public CrearSubasta(SubastaContext context)
        {
            InitializeComponent();

            subastaController = new SubastaController(context);
            subastadorController = new SubastadorController(context);
        }

        private void crear_Click(object sender, EventArgs e)
        {
            string articulo = text_Articulo.Text;
            Subastador subastador = (Subastador)boxSubastadores.SelectedItem;
            decimal precioInicial = num_PrecioInicial.Value;
            decimal precioPuja = num_PrecioPuja.Value;
            DateTime fecha = date_Fecha.Value.Date;
            DateTime hora = date_Hora.Value;
            decimal duracion = numDuracion.Value;

            bool ok = subastaController.CrearSubasta(articulo, subastador, precioInicial, precioPuja, fecha, hora, duracion);
            if (ok) MessageBox.Show("Subasta creada con exito.");
        }

        private void CrearSubasta_Load(object sender, EventArgs e)
        {
            boxSubastadores.Items.Clear();
            boxSubastadores.DataSource = subastadorController.ListarSubastadores();
        }
    }
}
