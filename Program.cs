using System;
using System.Windows.Forms;
using ProyectoSubasta.Views;
using ProyectoSubasta.Repository;

namespace ProyectoSubasta
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //SubastaContext db_context = new SubastaContext();
            Application.Run(new MenuPrincipal());
        }
    }
}
