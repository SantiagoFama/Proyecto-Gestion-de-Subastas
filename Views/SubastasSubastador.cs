using System;
using System.Collections.Generic;
using ProyectoSubasta.Controllers;
using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using System.Windows.Forms;


namespace ProyectoSubasta.Views
{
    public partial class SubastasSubastador : Form
    {
        private readonly SubastaController controller;
        private readonly int subastadorId;

        public SubastasSubastador(DBcontext context, int SubastadorId)
        {
            InitializeComponent();
            controller = new SubastaController(context);
            subastadorId = SubastadorId;
            CargarSubastasGrid();
        }

        private void CargarSubastasGrid()
        {
            List<Subasta> lista = controller.FiltrarSubastasPorSubastador(subastadorId);
            dgvSubastas.DataSource = null;
            dgvSubastas.DataSource = lista;
            PersonalizarGrid();
        }


        private void PersonalizarGrid()
        {
            // ocultar columnas 
            dgvSubastas.RowHeadersVisible = false;
            dgvSubastas.Columns["Id"].Visible = false;
            dgvSubastas.Columns["Fecha"].Visible = false;
            dgvSubastas.Columns["Duracion"].Visible = false;
            dgvSubastas.Columns["Ganador"].Visible = false;
            dgvSubastas.Columns["Pujas"].Visible = false;
            dgvSubastas.Columns["PrecioPuja"].Visible = false;

            // corregir nombre
            dgvSubastas.Columns["PrecioInicial"].HeaderText = "Precio Inicial";
            dgvSubastas.Columns["HorarioInicio"].HeaderText = "Fecha Inicio";
            dgvSubastas.Columns["FechaFin"].HeaderText = "Fecha Cierre";
            dgvSubastas.Columns["PrecioActual"].HeaderText = "Precio Actual";

            // ordenar columnas
            dgvSubastas.Columns["Estado"].DisplayIndex = 0;
            dgvSubastas.Columns["Articulo"].DisplayIndex = 1;
            dgvSubastas.Columns["PrecioActual"].DisplayIndex = 2;
            dgvSubastas.Columns["PrecioInicial"].DisplayIndex = 3;
            dgvSubastas.Columns["Subastador"].DisplayIndex = 4;
            dgvSubastas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (dgvSubastas.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una subasta de la grilla para Finalizar.");
                return;
            }
            var fila = dgvSubastas.CurrentRow;
            int subastaId = (int)fila.Cells["Id"].Value;
            
            bool ok = controller.FinalizarSubasta(subastaId);
            if(ok)
                MessageBox.Show("Subasta finalizada con éxito.");
            else
                MessageBox.Show("No se pudo finalizar la subasta. Verifique que esté abierta.");
            
            CargarSubastasGrid();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSubastas.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una subasta de la grilla para Eliminar.");
                return;
            }

            var fila = dgvSubastas.CurrentRow;
            int subastaId = (int)fila.Cells["Id"].Value;

            bool ok = controller.EliminarSubasta(subastaId);
            if (ok)
                MessageBox.Show("Subasta eliminada con éxito.");
            else
                MessageBox.Show("No se pudo eliminar la subasta. Verifique que esté cerrada.");
           
            CargarSubastasGrid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CargarSubastasGrid();
        }
    }
}
