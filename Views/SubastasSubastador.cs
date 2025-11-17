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
            dgvSubastas.Columns["id"].Visible = false;
            dgvSubastas.Columns["Fecha"].Visible = false;
            dgvSubastas.Columns["HorarioInicio"].Visible = false;
            dgvSubastas.Columns["Duracion"].Visible = false;
            dgvSubastas.Columns["Ganador"].Visible = false;
            dgvSubastas.Columns["Pujas"].Visible = false;
            dgvSubastas.RowHeadersVisible = false;

            dgvSubastas.Columns["PrecioInicial"].DefaultCellStyle.Format = "C";
            dgvSubastas.Columns["PrecioPuja"].DefaultCellStyle.Format = "C";

            dgvSubastas.Columns["Estado"].DisplayIndex = 0;
            dgvSubastas.Columns["Articulo"].DisplayIndex = 1;
            dgvSubastas.Columns["PrecioPuja"].DisplayIndex = 2;
            dgvSubastas.Columns["PrecioInicial"].DisplayIndex = 3;
            dgvSubastas.Columns["Subastador"].DisplayIndex = 4;
            dgvSubastas.Columns["PrecioActual"].DisplayIndex = 5;

            dgvSubastas.Columns["PrecioInicial"].HeaderText = "Precio Inicial";
            dgvSubastas.Columns["PrecioPuja"].HeaderText = "Precio Puja";
            dgvSubastas.Columns["PrecioActual"].HeaderText = "Precio Actual";

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
            controller.FinalizarSubasta(subastaId);
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
            controller.EliminarSubasta(subastaId);
            CargarSubastasGrid();
        }
    }
}
