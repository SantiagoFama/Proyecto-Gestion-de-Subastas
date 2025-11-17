using ProyectoSubasta.Controllers;
using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoSubasta.Views
{
    public partial class ListaSubastas : Form
    {
        private readonly SubastaController subastaController;
        private readonly int postorId;

        public ListaSubastas(DBcontext context, int PostorId)
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


        private void btn_IngresarSubasta_Click(object sender, EventArgs e)
        {
            if (dgvSubastas.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una subasta de la grilla para Ingresar.");
                return;
            }

            var fila = dgvSubastas.CurrentRow;
            int subastaId = (int)fila.Cells["Id"].Value;

            bool ok = subastaController.IngresoPostor(subastaId, postorId);
            if (ok) MessageBox.Show("Ingresaste Correctamente. Para interactuar ve a 'Mis Subastas'.");
            else MessageBox.Show("Error al ingresar a la subasta");
        }

        private void ListaSubastasView_Load(object sender, EventArgs e)
        {
            CargarSubastasGrid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CargarSubastasGrid();
        }
    }
}
