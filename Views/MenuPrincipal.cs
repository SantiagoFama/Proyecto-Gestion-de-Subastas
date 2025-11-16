using ProyectoSubasta.Repository;
using System;
using System.Linq;
using System.Threading; // <-- Para el Lock
using System.Timers; // <-- Usamos System.Timers
using System.Windows.Forms;

namespace ProyectoSubasta.Views
{
    public partial class MenuPrincipal : Form
    {
        private CrearUser crearuserView;
        private CrearSubasta crearSubastaView;
        private readonly DBcontext context;
        private int dniUsuario;
        private string rolUsuario;

        private System.Timers.Timer subastaTimer;
        private static readonly object _timerLock = new object();

        public MenuPrincipal()
        {
            InitializeComponent();

            context = new DBcontext();
            crearuserView = new CrearUser(context);
            crearSubastaView = new CrearSubasta(context);

            InicializarTimerDeSubastas();
        }

        private void InicializarTimerDeSubastas()
        {
            subastaTimer = new System.Timers.Timer(10000); // 30 segundos
            subastaTimer.Elapsed += VerificarSubastas;
            subastaTimer.AutoReset = true; // Se reinicia solo
            subastaTimer.Enabled = true;   // Inicia el timer
            subastaTimer.Start();
        }

        // --- 3. EVENTO DEL TIMER (EJECUTADO EN OTRO HILO) ---
        private void VerificarSubastas(object sender, ElapsedEventArgs e)
        {
            // Evita que el timer se ejecute de nuevo si el anterior no ha terminado
            if (!Monitor.TryEnter(_timerLock))
            {
                return;
            }

            try
            {
                // Usamos un DbContext NUEVO y TEMPORAL
                using (var db = new DBcontext())
                {
                    var ahora = DateTime.Now;

                    // 1. Buscar subastas "Programadas" que deben iniciar
                    var paraIniciar = db.Subastas.Where(s => s.Estado == "Programada" &&
                                    s.HorarioInicio <= ahora &&
                                    s.FechaFin > ahora) // Asegurarse que no haya terminado ya
                        .ToList();

                    // 2. Buscar subastas "Abiertas" que deben finalizar
                    var paraFinalizar = db.Subastas
                        .Where(s => s.Estado == "Abierta" && s.FechaFin <= ahora)
                        .ToList();

                    foreach (var s in paraIniciar)
                    {
                        s.Estado = "Abierta";
                    }

                    foreach (var s in paraFinalizar)
                    {
                        s.Estado = "Cerrada";
                    }

                    // 3. Guardar cambios si hay algo que cambiar
                    if (paraIniciar.Any() || paraFinalizar.Any())
                    {
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Timer: {ex.Message}");
            }
            finally
            {
                Monitor.Exit(_timerLock); // Liberar el bloqueo
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
            CargarVista(crearSubastaView);
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
