using ProyectoSubasta.Repository;
using System;
using System.Windows.Forms;

namespace ProyectoSubasta.Views
{
    public partial class MenuView : Form
    {
        private CrearUserView crearuserView;
        private CrearSubasta crearSubastaView;
        private readonly SubastaContext context;

        private int dniUsuario;
        private string rolUsuario;

        public MenuView()
        {
            InitializeComponent();
            //subastaView = new SubastaView();
            //listaSubastasView = new ListaSubastasView(context);
            context = new SubastaContext();
            crearuserView = new CrearUserView(context);
            crearSubastaView = new CrearSubasta(context);
        }

        private void CargarVista(Form vista)
        {
            if (panel_contenedor.Controls.Count > 0)
                panel_contenedor.Controls.RemoveAt(0);

            vista.TopLevel = false;
            vista.FormBorderStyle = FormBorderStyle.None;
            vista.Dock = DockStyle.Fill;

            panel_contenedor.Controls.Add(vista);
            panel_contenedor.Tag = vista;
            vista.Show();
        }

        private void btnVerSubastas_Click(object sender, EventArgs e)
        {
            CargarVista(new ListaSubastasView(context, dniUsuario));
        }

        private void btnMisSubastasPostor_Click(object sender, EventArgs e)
        {
            CargarVista(new SubastaView(context, dniUsuario));
        }

        private void btnCrearSubasta_Click(object sender, EventArgs e)
        {
            CargarVista(crearSubastaView);
        }

        private void MenuView_Load(object sender, EventArgs e)
        {
            crearuserView.ShowDialog();

            dniUsuario = crearuserView.DniUsuarioLogueado;
            rolUsuario = crearuserView.RolUsuarioLogueado;

            if (rolUsuario == "Postor")
            {
                //btnCrearSubasta.Visible = false;
                btnMisSubastasSubastador.Visible = false;
            }
            else if (rolUsuario == "Subastador")
            {
                btnVerSubastas.Visible = false;
                btnMisSubastasPostor.Visible = false;
            }

            return;
        }

        
    }
}
