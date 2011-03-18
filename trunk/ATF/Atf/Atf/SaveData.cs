using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Ming.Atf
{
    public partial class SaveData : UserControl
    {
        public SaveData()
        {
            InitializeComponent();
        }

        #region Méthodes
        // Ecrit dans un fichier l'integralite de la base
        private void writeOnFileData()
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

        // Ecrit dans un fichier l'integralite des informations sur les stations
        private void writeOnFileStations()
        {
            DialogResult result = saveFileDialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK || saveFileDialog.FileName == "")
                return;
            ArrayList res = LocalDataBase.getStationsDetails();

            StreamWriter sw = new StreamWriter(saveFileDialog.FileName);//création du fichier
            foreach (Dictionary<string,string> key in res)
            {
                string text = string.Empty;

                foreach (string value in key.Keys)
                    text += key[value] + " ";

                sw.WriteLine("{0}", text + "\n");//enregistrement du message dans le fichier
            }
            sw.Close();
        }
        #endregion

        #region Actions
        // Action pour recuperer les informations sur les stations
        private void button1_Click(object sender, EventArgs e)
        {
            writeOnFileStations();
        }
        
        // Actions pour recuperer l'integralite de la base
        private void button2_Click(object sender, EventArgs e)
        {
            writeOnFileData();
        }
        #endregion
    }
}
