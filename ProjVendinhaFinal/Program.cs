using ProjVendinhaFinal;
using ProjVendinhaFinal.Contexts;
using ProjVendinhaFinal.Screens;
using System;
using System.Windows.Forms;


namespace Vendinha.Desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            VendinhaDbContext.InicializarBanco();

            ApplicationConfiguration.Initialize();
            Application.Run(new FormPrincipal());
        }
    }
}
