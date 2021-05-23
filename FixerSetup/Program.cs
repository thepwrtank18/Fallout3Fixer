using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using FixerSetup.Properties;

namespace FixerSetup
{
    class Program
    {

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;


        static void Main(string[] args)
        {
            bool exists = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1;

            Console.Title = "Vault-Tec Automatic Unpacking System";
            Console.WriteLine("Vault-Tec Automatic Unpacking System (V.A.U.S.)");
            Console.WriteLine("Version 1.0");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("####@#@@###@#@@##@######@@###@##\r\n#W####@##@##@` ` ##@###@####W##@\r\n@###@#xnxxn.`i## `xnMnnW@##@##@#\r\n##@##+    ` @####.`     #@#@#@##\r\n#@###@#### ###`;## @############\r\n##@i` `  ` #@  `#@`  `    ####@#\r\n#@##,,:,,,`@#;` ## ,,,,:,:@#####\r\n#@##@##W@W `@@##@# @WW@@#@###@##\r\n###@#i   `` n#@#@`      ##@#####\r\nW##########@`  `` ############@@\r\n##@#@#@#######,*@#@#W##@#@#@@###\r\n@##@#######@####################");
            Console.WriteLine("----------------------------------------------------------------");

            if (exists == true)
            {
                Console.WriteLine("Only one instance can be running at a time.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Writing temporary files...");
                if (!Directory.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Fallout3Fixer"))
                {
                    Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Fallout3Fixer");
                }
                Directory.SetCurrentDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Fallout3Fixer");
                File.Create("Fallout3Fixer.exe").Dispose(); File.WriteAllBytes("Fallout3Fixer.exe", Resources.Fallout3Fixer);
                File.Create("Microsoft.Deployment.WindowsInstaller.dll").Dispose(); File.WriteAllBytes("Microsoft.Deployment.WindowsInstaller.dll", Resources.WindowsInstallerDll);
                File.Create("Microsoft.Deployment.WindowsInstaller.xml").Dispose(); File.WriteAllText("Microsoft.Deployment.WindowsInstaller.xml", Resources.WindowsInstallerXml);
                Console.WriteLine("Launching V.A.D...");
                ProcessStartInfo fixerProcessInfo = new ProcessStartInfo("Fallout3Fixer.exe");
                Process fixerProcess = new Process();
                fixerProcess.StartInfo = fixerProcessInfo;
                fixerProcess.Start();
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);
                fixerProcess.WaitForExit();
                Console.WriteLine("Deleting temporary files...");
                File.Delete("Fallout3Fixer.exe");
                File.Delete("Microsoft.Deployment.WindowsInstaller.dll");
                File.Delete("Microsoft.Deployment.WindowsInstaller.xml");
                Directory.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                Directory.Delete("Fallout3Fixer");
            }
        }
    }
}
