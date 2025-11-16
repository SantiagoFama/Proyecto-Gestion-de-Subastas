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
            Application.Run(new MenuPrincipal());
        }
    }
}
