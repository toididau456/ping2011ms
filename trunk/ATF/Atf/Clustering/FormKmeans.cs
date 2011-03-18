using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ming.Atf.Clustering
{
    public partial class FormKmeans : UserControl
    {
        // Constructeur
        public FormKmeans()
        {
            InitializeComponent();
        }

        #region Acces Infos
        // Acces au bouton d'execution
        public Button getExecuteButton()
        {
            return button1;
        }

        // Retourne la date de départ
        public DateTime getDateStart()
        {
            return dateTimePicker1.Value;
        }

        // Retourne la date de fin
        public DateTime getDateEnd()
        {
            return dateTimePicker2.Value;
        }

        // Retourne le type de vectorisation
        public int getSelectedVector()
        {
            if (comboBox1.SelectedItem == null)
                return 0;
            String type = comboBox1.SelectedItem as String;
            String[] res = type.Split('-');
            return int.Parse(res[0]);
        }

        // Retourne le type de distance
        public String getSelectedDistance()
        {
            if (comboBox2.SelectedItem == null)
                return "Euclidienne";
            return comboBox2.SelectedItem as String;
        }

        // Retourne le nombre de cluster
        public int getNbCluster()
        {
            if (comboBox3.SelectedItem == null)
                return 6;
            return int.Parse(comboBox3.SelectedItem as String);
        }

        // Retourne le codage a utiliser
        public string getCodage()
        {
            if (comboBox4.SelectedItem == null)
                return "Aucun";
            return comboBox4.SelectedItem as string;
        }

        // Ajoute un element dans le panel droit
        public void addControls(Control control)
        {
            if (splitContainer1.Panel2.Controls.Count > 0)
                splitContainer1.Panel2.Controls[0].Dispose();
            splitContainer1.Panel2.Controls.Add(control);
        }
        #endregion
    }
}
