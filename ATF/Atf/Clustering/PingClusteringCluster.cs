using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Psl.Applications;
using System.Collections;
using ats.KMeans;

namespace Ming.Atf.Clustering
{
    public partial class PingClusteringCluster : UserControl
    {
        #region Champs
        /* Acces au TabDocker de la fenetre principale */
        Psl.Controls.TabDocker pages = Registry.MainPages;

        /* Acces au StatusReporter de la fenetre principale */
        Psl.Controls.StatusReporter status = Registry.MainStatus as Psl.Controls.StatusReporter;

        /* Conteneur */
        FormKmeans panel;
        #endregion

        // Constructeur
        public PingClusteringCluster()
        {
            InitializeComponent();
            Registry.MergeInMainMenu(this.menuStrip);
            Registry.MergeInMainTools(this.toolStrip);
        }

        #region Methodes
        // Convert Dictionary to array
        private double[,] convertData(Dictionary<int,Dictionary<int, double>> data)
        {
            double[,] result = new double[data.Count,data.Keys.Count / data.Count];
            ArrayList station = new ArrayList();
            foreach (int key in data.Keys)
                if(!station.Contains(key))
                    station.Add(key);

            foreach (int key in data.Keys)
                foreach(int val in data[key].Keys)
                    result[station.IndexOf(key,0),val] = data[key][val];
            
            return result;
        }

        // Init. le panel
        private void initPanel()
        {
            panel = new FormKmeans();
        }

        // K-Means
        private void Kmeans(Dictionary<int, Dictionary<int, double>> data, int clusters)
        {
            double[,] db = convertData(data);
            ClusterCollection cluster = KMeans.ClusterDataSet(clusters,db);

        }
        #endregion

        #region Actions
        // Ouverture
        private void acOpen_Execute(object sender, EventArgs e)
        {
            if (pages.Contains(panel))
                return;

            initPanel();
            pages.ClientAdd(panel,"K-Means",null,true);
        }
        #endregion
    }
}
