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
        private readonly DBcontext context;
        private readonly VerDetalle verDetalle;

        public SubastasPostor(DBcontext _context, int PostorId)
        {
            InitializeComponent();
            context = _context;
            controller = new SubastaController(context);
            postorId = PostorId;
            CargarSubastasGrid();
        }

        private void CargarSubastasGrid()
        {
            List<Subasta> lista = controller.FiltrarSubastasPorPostor(postorId);
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

            // agregar espacio en medio
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

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvSubastas.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una subasta de la grilla para ver los detalles.");
                return;
            }

            var fila = dgvSubastas.CurrentRow;
            int id = (int)fila.Cells["Id"].Value;
            VerDetalle verDetalle = new VerDetalle(context, id, postorId);
            verDetalle.ShowDialog();
        }

        private void btnSalirSubasta_Click(object sender, EventArgs e)
        {
            if (dgvSubastas.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una subasta de la grilla para salir.");
                return;
            }

            var fila = dgvSubastas.CurrentRow;
            int id = (int)fila.Cells["Id"].Value;

            bool ok = controller.EgresoPostor(id, postorId);
            if (ok) MessageBox.Show("Saliste Correctamente de la Subasta.");
            CargarSubastasGrid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CargarSubastasGrid();
        }
    }
}
