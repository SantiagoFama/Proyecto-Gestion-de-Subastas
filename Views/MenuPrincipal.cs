using ProyectoSubasta.Models;
using ProyectoSubasta.Repository;
using System;
using System.Linq;
using System.Timers; 
using System.Windows.Forms;

namespace ProyectoSubasta.Views
{
    public partial class MenuPrincipal : Form
    {
        private CrearUser crearuserView;
        private readonly DBcontext context;
        private int dniUsuario;
        private string rolUsuario;

        private System.Timers.Timer subastaTimer;

        public MenuPrincipal()
        {
            InitializeComponent();
            context = new DBcontext();
            crearuserView = new CrearUser(context);

            InicializarTimerDeSubastas();
        }

        private void InicializarTimerDeSubastas()
        {
            subastaTimer = new System.Timers.Timer(5000);
            subastaTimer.Elapsed += VerificarSubastas;
            subastaTimer.AutoReset = true;
            subastaTimer.Enabled = true;  
            subastaTimer.Start();
        }


        private void VerificarSubastas(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (var context = new DBcontext())
                {
                    var ahora = DateTime.Now;
                    //
                    // Acá tuve que usar -HorarioInicio.AddMinutes((double)s.Duracion- porque EF no me 
                    // reconocía la propiedad FechaFin
                    //
                    var paraIniciar = context.Subastas.Where(s => s.Estado == "Programada" && 
                    s.HorarioInicio <= ahora && s.HorarioInicio.AddMinutes((double)s.Duracion) > ahora).ToList();

                    var paraFinalizar = context.Subastas.Where(s => s.Estado == "Abierta" && 
                    s.HorarioInicio.AddMinutes((double)s.Duracion) <= ahora).ToList();

                    foreach (Subasta s in paraIniciar)
                    {
                        s.Estado = "Abierta";
                    }

                    foreach (Subasta s in paraFinalizar)
                    {
                        s.Estado = "Cerrada";
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
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
            CargarVista(new ListaSubastas(context, dniUsuario));
        }

        private void btnMisSubastasPostor_Click(object sender, EventArgs e)
        {
            CargarVista(new SubastasPostor(context, dniUsuario));
        }

        private void btnCrearSubasta_Click(object sender, EventArgs e)
        {
            CargarVista(new CrearSubasta(context));
        }

        private void btnMisSubastasSubastador_Click(object sender, EventArgs e)
        {
            CargarVista(new SubastasSubastador(context, dniUsuario));
        }

        private void MenuView_Load(object sender, EventArgs e)
        {
            crearuserView.ShowDialog();

            dniUsuario = crearuserView.DniUsuarioLogueado;
            rolUsuario = crearuserView.RolUsuarioLogueado;

            if (rolUsuario == "Postor")
            {
                btnCrearSubasta.Visible = false;
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
