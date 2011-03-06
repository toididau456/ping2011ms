using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Psl.Applications;
using System.IO;
using System.Collections;

namespace Ming.Atf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Registre 
            Registry.Add(Psl.Applications.MainKeys.KeyMainMenu, menu);
            Registry.Add(Psl.Applications.MainKeys.KeyMainStatus, status);
            Registry.Add(Psl.Applications.MainKeys.KeyMainTools, tools);
            Registry.Add(Psl.Applications.MainKeys.KeyMainContent, this);
            Registry.Add(Psl.Applications.MainKeys.KeyMainPages, pages);

            // Installation du plugin d’archivage
            ArchiverPlugin.Install(true);

            // Chargement des plugins 
            PluginManager.LoadPlugins();


            // ici : enregistrement des éléments fournis par MainForm
            // ici : création de tous les éléments de l’application
            ApplicationState.OnOpen(this, EventArgs.Empty);
        }

        #region MainForm
        // Demande de fermeture de l’application
        private void MainForm_FormClosing(object source, FormClosingEventArgs e)
        {
            ApplicationState.OnClosing(this, e);
        }

        // Notification de la fermeture effective de l’application
        private void MainForm_FormClosed(object source, FormClosedEventArgs e)
        {
            ApplicationState.OnClose(this, e);
        }
        #endregion

        #region Events
        private void applicationEvents_Archive(IArchiver sender)
        {
            sender.PushSection("main.form");
            try
            {
                sender.ArchiveProperty("Top", this, 50);
                sender.ArchiveProperty("Left", this, 50);
                sender.ArchiveProperty("Width", this, 500);
                sender.ArchiveProperty("Height", this, 500);
                sender.ArchiveProperty("Checked", this.acShowTools, true);
                tools.Archive(sender, "Tools");
            }
            finally { sender.PopSection(); }
        }

        private void applicationEvents_ApplicationIdle(object sender, EventArgs e)
        {
            this.toolBar.Visible = acShowTools.Checked;
        }
        #endregion

        #region Methodes
        // Ecrit dans un fichier l'integralite de la base
        private void writeOnFile()
        {
            DialogResult result = saveFileDialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK || saveFileDialog.FileName == "")
                return;
            Dictionary<int, ArrayList> res = LocalDataBase.getAllToFile();

            StreamWriter sw = new StreamWriter(saveFileDialog.FileName);//création du fichier
            foreach (int key in res.Keys)
            {
                string text = string.Empty;

                foreach (int value in res[key])
                    text += value + " ";

                sw.WriteLine("{0}", text + "\n");//enregistrement du message dans le fichier
            }
            sw.Close();
        }
        #endregion

        #region Actions
        private void acQuit_Execute(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acToFile_Execute(object sender, EventArgs e)
        {
            writeOnFile();
        }
        #endregion
    }
}
