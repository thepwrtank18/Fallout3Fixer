﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Fallout3Fixer.Properties;
using Microsoft.Deployment.WindowsInstaller;
using FileAttributes = System.IO.FileAttributes;

namespace Fallout3Fixer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (Directory.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Fallout 3 goty"))
            {
                falloutDir.Text = @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 3 goty";
            }
        }

        private void useFOSE_CheckedChanged(object sender, EventArgs e)
        {
            if (useLIVE.Checked == true)
            {
                useFOSE.Checked = false;
                falloutDir.ReadOnly = true;
                falloutDir.Enabled = false;
                falloutSearch.Enabled = false;
                patchButton.Enabled = true;
            }
            else if (useFOSE.Checked == true)
            {
                useLIVE.Checked = false;
                falloutDir.ReadOnly = true;
                falloutDir.Enabled = false;
                falloutSearch.Enabled = false;
                patchButton.Enabled = true;
            }
            else
            {
                falloutDir.ReadOnly = false;
                falloutDir.Enabled = true;
                falloutSearch.Enabled = true;
                patchButton.Enabled = false;
            }
        }

        private void useLIVE_CheckedChanged(object sender, EventArgs e)
        {
            if (useLIVE.Checked == true)
            {
                useFOSE.Checked = false;
                falloutDir.ReadOnly = true;
                falloutDir.Enabled = false;
                falloutSearch.Enabled = false;
                patchButton.Enabled = true;
            }
            else if (useFOSE.Checked == true)
            {
                useLIVE.Checked = false;
                falloutDir.ReadOnly = true;
                falloutDir.Enabled = false;
                falloutSearch.Enabled = false;
                patchButton.Enabled = true;
            }
            else
            {
                falloutDir.ReadOnly = false;
                falloutDir.Enabled = true;
                falloutSearch.Enabled = true;
                patchButton.Enabled = false;
            }
        }

        private void falloutDir_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(falloutDir.Text))
            {
                if (File.Exists($@"{falloutDir.Text}\Fallout3.exe"))
                {
                    if (File.Exists($@"{falloutDir.Text}\gog.ico"))
                    {
                        MessageBox.Show("As this is a GOG copy, the fix is not needed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        useFOSE.Enabled = false;
                        useLIVE.Enabled = false;
                    }
                    else
                    {
                        useFOSE.Enabled = true;
                        useLIVE.Enabled = true;
                    }
                }
                else
                {
                    useFOSE.Enabled = false;
                    useLIVE.Enabled = false;
                }

            }
            else
            {
                useFOSE.Enabled = false;
                useLIVE.Enabled = false;

            }

        }

        private void falloutSearch_Click(object sender, EventArgs e)
        {
            falloutSearch.Enabled = false;
            falloutDir.ReadOnly = true;
            falloutDir.Enabled = false;

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Fallout 3|Fallout3.exe";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    falloutDir.Text = Path.GetDirectoryName(openFile.FileName);
                }
            }

            falloutSearch.Enabled = true;
            falloutDir.ReadOnly = false;
            falloutDir.Enabled = true;
        }

        private void patchButton_Click(object sender, EventArgs e)
        {
            patchButton.Enabled = false;
            useFOSE.Enabled = false;
            useLIVE.Enabled = false;

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (useFOSE.Checked)
            {

                if (!Directory.Exists($@"{documentsPath}\My Games\Fallout3"))
                {
                    Directory.CreateDirectory($@"{documentsPath}\My Games\Fallout3");
                }

                if (!File.Exists($@"{documentsPath}\My Games\Fallout3\fallout.ini"))
                {
                    File.Copy($@"{falloutDir.Text}\Fallout_default.ini", $@"{documentsPath}\My Games\Fallout3\Fallout.ini");
                }

                File.Create($@"{falloutDir.Text}\winlivedisable.exe").Dispose();
                File.WriteAllBytes($@"{falloutDir.Text}\winlivedisable.exe", Resources.winlivedisable);
                if (MessageBox.Show("To continue, say yes to the UAC prompt, then press \"Disable G4WL\". Close the window after that. (Press \"No\" to continue, and \"Yes\" to continue and visit the Disabler's nexus page.)", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    ProcessStartInfo g4wldisable = new ProcessStartInfo($@"{falloutDir.Text}\winlivedisable.exe");
                    Process g4wlprocess = new Process();
                    g4wlprocess.StartInfo = g4wldisable;
                    g4wlprocess.Start();
                    g4wlprocess.WaitForExit();
                    if (MessageBox.Show("Done. Press \"OK\" to exit.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        File.Create($@"{falloutDir.Text}\fixer-do-not-delete");
                        string path = $@"{falloutDir.Text}\fixer-do-not-delete";
                        File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Process.Start("explorer", "https://www.nexusmods.com/fallout3/mods/1086");
                    ProcessStartInfo g4wldisable = new ProcessStartInfo($@"{falloutDir.Text}\winlivedisable.exe");
                    Process g4wlprocess = new Process();
                    g4wlprocess.StartInfo = g4wldisable;
                    g4wlprocess.Start();
                    g4wlprocess.WaitForExit();
                    if (MessageBox.Show("Done. Press \"OK\" to exit.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else if (useLIVE.Checked)
            {
                Directory.CreateDirectory($@"{falloutDir.Text}\temporary");
                File.Create($@"{falloutDir.Text}\temporary\gfwlclient.msi").Dispose(); File.WriteAllBytes($@"{falloutDir.Text}\temporary\gfwlclient.msi", Resources.gfwlclient);
                File.Create($@"{falloutDir.Text}\temporary\xliveredist.msi").Dispose(); File.WriteAllBytes($@"{falloutDir.Text}\temporary\xliveredist.msi", Resources.xliveredist);
                File.Create($@"{falloutDir.Text}\temporary\registrymod.reg").Dispose(); File.WriteAllText($@"{falloutDir.Text}\temporary\registrymod.reg", Resources.registrymod);

                Installer.SetInternalUI(InstallUIOptions.HideCancel);
                Installer.InstallProduct($@"{falloutDir.Text}\temporary\gfwlclient.msi", "ACTION=INSTALL ALLUSERS=2 MSIINSTALLPERUSER=");
                Installer.InstallProduct($@"{falloutDir.Text}\temporary\xliveredist.msi", "ACTION=INSTALL ALLUSERS=2 MSIINSTALLPERUSER=");

                
                {
                    if (!Directory.Exists($@"{documentsPath}\My Games\Fallout3"))
                    {
                        Directory.CreateDirectory($@"{documentsPath}\My Games\Fallout3");
                    }

                    if (!File.Exists($@"{documentsPath}\My Games\Fallout3\fallout.ini"))
                    {
                        File.Copy($@"{falloutDir.Text}\Fallout_default.ini", $@"{documentsPath}\My Games\Fallout3\Fallout.ini");
                    }

                    Process regeditProcess = Process.Start("regedit.exe", $"/s \"{falloutDir.Text}\\temporary\\registrymod.reg\"");
                    regeditProcess.WaitForExit();

                    if (!File.Exists($@"{documentsPath}\My Games\Fallout3\FalloutPrefs.ini"))
                    {
                        if (MessageBox.Show("The launcher is going to open. After it determines your graphics settings, close it.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            ProcessStartInfo launcherProcessInfo = new ProcessStartInfo($@"{falloutDir.Text}\FalloutLauncher.exe");
                            Process launcherProcess = new Process();
                            launcherProcess.StartInfo = launcherProcessInfo;
                            launcherProcess.Start();
                            launcherProcess.WaitForExit();
                        }
                    }


                    if (MessageBox.Show("Fallout 3 is going to open. Sign into your Microsoft Account via the LIVE menu, then press Ctrl+V when asked for a product key. Press \"yes\" to the update. (If the product key fails, try again).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        Clipboard.Clear();
                        Clipboard.SetText("VB8DC-VYVGG-F8K78-7TJRF-7CVCT");

                        var MyIni = new IniFile($@"{documentsPath}\My Games\Fallout3\FalloutPrefs.ini");
                        MyIni.Write("iSize W", Screen.PrimaryScreen.Bounds.Width.ToString(), "Display");
                        MyIni.Write("iSize H", Screen.PrimaryScreen.Bounds.Height.ToString(), "Display");

                        Process.Start($@"{falloutDir.Text}\FalloutLauncher.exe");
                        if (MessageBox.Show("Click the \"OK\" button when the update has completed.", "Info", MessageBoxButtons.OK) == DialogResult.OK)
                        {
                            if (MessageBox.Show("Fallout 3 will open again. Press \"OK\" to start and to exit the fixer program. Sign into your Microsoft Account again.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                Process.Start($@"{falloutDir.Text}\FalloutLauncher.exe");
                                File.Delete($@"{falloutDir.Text}\temporary\gfwlclient.msi");
                                File.Delete($@"{falloutDir.Text}\temporary\xliveredist.msi");
                                File.Delete($@"{falloutDir.Text}\temporary\registrymod.reg");
                                Directory.Delete($@"{falloutDir.Text}\temporary");
                                Environment.Exit(0);
                            }
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select an option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                patchButton.Enabled = false;
                useFOSE.Enabled = true;
                useLIVE.Enabled = true;
            }
        }
    }
}
