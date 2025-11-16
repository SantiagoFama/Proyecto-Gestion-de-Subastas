using ProyectoSubasta.Controllers;
using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using System;
using System.Windows.Forms;

namespace ProyectoSubasta.Views
{
    public partial class VerDetalle : Form
    {
        private readonly SubastaController controller;
        private readonly int subastaId;
        private readonly int postorId;

        public VerDetalle(DBcontext context, int SubastaId, int PostorId)
        {
            InitializeComponent();
            controller = new SubastaController(context);
            subastaId = SubastaId;
            postorId = PostorId;
        }

        private void VerDetalle_Load(object sender, EventArgs e)
        {
            CargarDetalles();
        }

        private void CargarDetalles()
        {
            Subasta subasta = controller.ObtenerSubasta(subastaId);
            if (subasta == null)
            {
                MessageBox.Show("Error al cargar la subasta.");
                Close();
                return;
            }

            

            if (subasta.Estado == "Abierta")
            {
                //btnPujar.Enabled = false;
                //btnPujar.Text = "Subasta Finalizada";
            }
        }

        private void btnPujar_Click(object sender, EventArgs e)
        {
            try
            {
                bool ok = controller.Pujar(subastaId, postorId);
                if (ok)
                {
                    MessageBox.Show("¡Puja realizada con éxito!");
                    CargarDetalles(); 
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la puja. Es posible que la subasta haya finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al pujar: {ex.Message}");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
