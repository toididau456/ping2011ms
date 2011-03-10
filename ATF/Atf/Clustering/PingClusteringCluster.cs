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
using Ming.Atf.Pictures;

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

        /* Stations sous ArrayList*/
        List<int> stations = new List<int>();
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
            int keyTemp = -1;
            List<int> station = new List<int>();
            foreach (int key in data.Keys)
                if (!station.Contains(key))
                {
                    station.Add(key);
                    if (keyTemp == -1)
                        keyTemp = key;
                }

            stations = station;
            double[,] result = new double[data.Count, data[keyTemp].Keys.Count];
            
            foreach (int key in data.Keys)
                foreach (int val in data[key].Keys)
                {
                    //Console.WriteLine(key + " Key : " + station.IndexOf(key) + " - Val : " + val);
                    double res = data[key][val];
                    //Console.WriteLine("Key : " + key + " - Index : " + station.IndexOf(key));
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
            status.TextLeft = "K-Means";
            status.TextInfos = "Segmentation des stations";
        }

        // K-Means
        private void Kmeans(Dictionary<int, Dictionary<int, double>> data, int clusters,string type)
        {
            double[,] db = convertData(data);
            Console.WriteLine("Donnees convertie");

            ClusterCollection cluster = KMeans.ClusterDataSet(clusters,db,type);
            //MessageBox.Show(this,"Nombre de cluster : " + cluster.Count);
            Console.WriteLine("Kmeans calcule");
            Dictionary<int, int> stationCluster = new Dictionary<int, int>();
            for (int i = 0; i < cluster.Count; i++)
                //string s = "Cluster " + i + ", taille = " + cluster[i].getValues.Count + " : ";
                foreach (int z in cluster[i].getValues)
                {
                    Console.WriteLine(stations[z]);
                    int temp = stations[z];
                    stationCluster.Add(temp, i);
                    //string s = stations[z] + " : " + i ;
                }
            ScrollableMaps maps = new ScrollableMaps();
            maps.drawClusters(stationCluster);
            PictureBox map = maps.mapBox;
            panel.addControls(map);
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
            Dictionary<int, Dictionary<int, double>> data = new Dictionary<int,Dictionary<int,double>>();

            switch(vector)
            {
                case 1:
                    data = LocalDataBase.getRemplissageByHourOuvres(start, end);
                    break;
                case 2:
                    data = LocalDataBase.getRemplissageByHourWE(start, end);
                    break;
                case 3:
                    //data = LocalDataBase.getRemplissageByHalfHour(start, end);
                    break;
                case 4:
                    data = LocalDataBase.getRemplissageByDay(start, end);
                    break;
                default:
                    data = LocalDataBase.getRemplissageByHour(start, end);
                    break;
            }
            Console.WriteLine("J'ai les donnees");
            Kmeans(data, cluster, distance);
            MessageBox.Show(this,"Ok - Tout marche");
        }
        #endregion
    }
}
