using ProyectoSubasta.Controllers;
using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProyectoSubasta.Views
{
    public partial class SubastasPostor : Form
    {
        private readonly SubastaController controller;
        private readonly int postorId;

        public SubastasPostor(SubastaContext context,int PostorId)
        {
            InitializeComponent();
            controller = new SubastaController(context);
            postorId = PostorId;
            CargarSubastasGrid();
        }

        private void CargarSubastasGrid()
        {
            List<Subasta> lista = controller.ListaSubastasPorPostor(postorId);
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
            dgvSubastas.Columns["Finalizada"].Visible = false;
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

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {

        }

        private void btnSalirSubasta_Click(object sender, EventArgs e)
        {   
            if (dgvSubastas.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una subasta de la grilla para salir.");
                return;
            }

            var fila = dgvSubastas.CurrentRow;
            int id = (int)fila.Cells["id"].Value;

            bool ok = controller.EgresoPostor(id, postorId);
            if (ok) MessageBox.Show("Saliste Correctamente de la Subasta.");
            CargarSubastasGrid();
        }
    }
}
