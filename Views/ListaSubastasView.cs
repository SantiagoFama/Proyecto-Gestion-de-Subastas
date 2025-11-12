using ProyectoSubasta.Controllers;
using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoSubasta.Views
{
    public partial class ListaSubastasView : Form
    {
        private readonly SubastaController subastaController;
        private readonly int postorId;

        public ListaSubastasView(DBcontext context, int PostorId)
        {
            InitializeComponent();
            subastaController = new SubastaController(context);
            postorId = PostorId;
        }


        private void CargarSubastasGrid()
        {
            List<Subasta> lista = subastaController.ListaSubastas();
            dgvSubastas.DataSource = null;
            dgvSubastas.DataSource = lista;
            PersonalizarGrid();
        }


        private void PersonalizarGrid()
        {
            dgvSubastas.RowHeadersVisible = false;
            dgvSubastas.Columns["id"].Visible = false;
            dgvSubastas.Columns["Fecha"].Visible = false;
            dgvSubastas.Columns["HorarioInicio"].Visible = false;
            dgvSubastas.Columns["Duracion"].Visible = false;
            dgvSubastas.Columns["Ganador"].Visible = false;
            dgvSubastas.Columns["Finalizada"].Visible = false;
            dgvSubastas.Columns["Pujas"].Visible = false;

            dgvSubastas.Columns["PrecioInicial"].HeaderText = "Precio Inicial";
            dgvSubastas.Columns["PrecioPuja"].HeaderText = "Puja Actual";

            dgvSubastas.Columns["PrecioInicial"].DefaultCellStyle.Format = "C";
            dgvSubastas.Columns["PrecioPuja"].DefaultCellStyle.Format = "C";

            dgvSubastas.Columns["Estado"].DisplayIndex = 0;
            dgvSubastas.Columns["Articulo"].DisplayIndex = 1;
            dgvSubastas.Columns["PrecioPuja"].DisplayIndex = 2;
            dgvSubastas.Columns["PrecioInicial"].DisplayIndex = 3;
            dgvSubastas.Columns["Subastador"].DisplayIndex = 4;

            dgvSubastas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void btn_IngresarSubasta_Click(object sender, EventArgs e)
        {
            if (dgvSubastas.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una subasta de la grilla para Ingresar.");
                return;
            }

            var fila = dgvSubastas.CurrentRow;
            int id = (int)fila.Cells["id"].Value;

            bool ok = subastaController.IngresoPostor(id, postorId);
            if (ok) MessageBox.Show("Ingresaste Correctamente. Para interactuar ve a 'Mis Subastas'.");
            else MessageBox.Show("Ya ingresaste en esta subasta.");
        }

        private void ListaSubastasView_Load(object sender, EventArgs e)
        {
            CargarSubastasGrid();
        }
    }
}
