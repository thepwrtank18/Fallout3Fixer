using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

namespace Fallout3Fixer
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var exists =
                Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location))
                    .Length > 1;

            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                MessageBox.Show("Please run this as an administrator.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (exists)
            {
                MessageBox.Show("Only one instance can be running at a time.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }
}