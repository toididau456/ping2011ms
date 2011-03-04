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
        Button button;
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
            double[,] result = new double[data.Count , data[20020].Keys.Count];
            ArrayList station = new ArrayList();
            foreach (int key in data.Keys)
                if(!station.Contains(key))
                    station.Add(key);

            foreach (int key in data.Keys)
                foreach (int val in data[key].Keys)
                {
                    //Console.WriteLine(key + " Key : " + station.IndexOf(key) + " - Val : " + val);
                    double res = data[key][val];
                    result[station.IndexOf(key) , val] = res;
                }
            //MessageBox.Show(this,"Conversion - ok");
            return result;
        }

        // Init. le panel
        private void initPanel()
        {
            panel = new FormKmeans();
            button = panel.getExecuteButton();
            button.Click += execution;
        }

        // K-Means
        private void Kmeans(Dictionary<int, Dictionary<int, double>> data, int clusters,string type)
        {
            double[,] db = convertData(data);
            ClusterCollection cluster = KMeans.ClusterDataSet(clusters,db,type);
            //MessageBox.Show(this,"Nombre de cluster : " + cluster.Count);
            for (int i = 0; i < cluster.Count; i++)
            {
                string s = "Cluster " + i + " : ";
                foreach (double z in cluster[i].ClusterMean)
                    s += (int)(z*100) + " ";

                Label label = new Label();
                label.Size = new Size(600, 15);
                label.Anchor = AnchorStyles.Right;
                label.Text = s;
                panel.addControls(label);
            }
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

        #region Events
        // Click pour execution
        private void execution(object sender, EventArgs args)
        {
            // Dates 
            DateTime start = panel.getDateStart();
            DateTime end = panel.getDateEnd();
            // Type de vector
            int vector = panel.getSelectedVector();
            // Type de distance
            String distance = panel.getSelectedDistance();
            // Nombre de cluster
            int cluster = panel.getNbCluster();
            Dictionary<int, Dictionary<int, double>> data = LocalDataBase.getRemplissageByHour(start, end);
            //MessageBox.Show(this,"Remplissage - ok");
            Kmeans(data, cluster, distance);
            MessageBox.Show(this,"Ok - Tout marche");
        }
        #endregion
    }
}
