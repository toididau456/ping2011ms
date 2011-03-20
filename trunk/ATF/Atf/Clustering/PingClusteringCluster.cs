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
using System.Windows.Forms.DataVisualization.Charting;

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
        ComboBox combo1;

        /* Stations sous ArrayList*/
        List<int> stations = new List<int>();

        /* Clusters */
        ClusterCollection cluster;

        /* Station cluster */
        Dictionary<int, int> stationCluster;

        /* Chart */
        StatsChartsVelib chart;
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
        private double[,] convertData(Dictionary<int, Dictionary<int, double>> data)
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
            {
                foreach (int val in data[key].Keys)
                {
                    //Console.WriteLine(key + " Key : " + station.IndexOf(key) + " - Val : " + val);
                    double res = data[key][val];
                    //Console.WriteLine("Cle : " + key + " - Valeur : " + val);
                    //Console.WriteLine("Key : " + key + " - Index : " + station.IndexOf(key));
                    result[station.IndexOf(key), val] = res;
                }
            }
            //MessageBox.Show(this,"Conversion - ok");
            return result;
        }

        // Convert Dictionary to array
        private double[,] convertDataBin(Dictionary<int, Dictionary<int, double>> data)
        {
            Console.WriteLine("Bin convertion");
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
            {
                double toBin = 0;
                double toStock = 0;
                foreach (int val in data[key].Keys)
                {
                    //Console.WriteLine(key + " Key : " + station.IndexOf(key) + " - Val : " + val);
                    double res = data[key][val];
                    if (res > toBin)
                        toStock = 1.0;
                    else
                        toStock = 0.0;

                    toBin = res;
                    //Console.WriteLine("Key : " + key + " - Index : " + station.IndexOf(key));
                    result[station.IndexOf(key), val] = toStock;
                }
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
        private void Kmeans(Dictionary<int, Dictionary<int, double>> data, int clusters, string type, string codage)
        {

            double[,] db = null;
            if (data.Count > 1)
                if (codage != "Binaire")
                    db = convertData(data);
                else
                    db = convertDataBin(data);
            else
                return;

            Console.WriteLine("Donnees convertie");

            cluster = KMeans.ClusterDataSet(clusters, db, type);
            //MessageBox.Show(this,"Nombre de cluster : " + cluster.Count);
            Console.WriteLine("Kmeans calcule");
            //Dictionary<int, int> stationCluster = new Dictionary<int, int>();
            stationCluster = new Dictionary<int, int>();
            for (int i = 0; i < cluster.Count; i++)
            {
                Console.WriteLine("Cluster : " + i + " - Taille : " + cluster[i].Count);
                //string s = "Cluster " + i + ", taille = " + cluster[i].getValues.Count + " : ";
                foreach (int z in cluster[i].getValues)
                {
                    //Console.WriteLine(stations[z]);
                    int temp = stations[z];
                    stationCluster.Add(temp, i);
                    //string s = stations[z] + " : " + i ;
                }
            }
            ScrollableMaps maps = new ScrollableMaps();
            maps.drawClusters(stationCluster);
            PictureBox map = maps.mapBox;
            map.SizeMode = PictureBoxSizeMode.Zoom;
            map.Dock = DockStyle.Fill;
            Panel tempPanel = new Panel();
            tempPanel.Dock = DockStyle.Fill;

            combo1 = new ComboBox();
            combo1.Text = "Affichage des statistiques pour les clusters";
            combo1.Items.Add("Tous les clusters");
            combo1.Items.Add("Altitudes");
            combo1.Items.Add("Point of Interest");
            for (int i = 0; i < cluster.Count; i++)
                combo1.Items.Add(i);
            combo1.SelectedIndexChanged += changeCluster;
            combo1.Dock = DockStyle.Top;

            tempPanel.Controls.Add(combo1);
            tempPanel.Controls.Add(map);

            panel.addControls(tempPanel);
        }
        #endregion

        #region Actions
        // Ouverture
        private void acOpen_Execute(object sender, EventArgs e)
        {
            if (pages.Contains(panel))
                return;

            initPanel();
            pages.ClientAdd(panel, "K-Means", null, true);
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
            // Type de codage
            string codage = panel.getCodage();
            Dictionary<int, Dictionary<int, double>> data = new Dictionary<int, Dictionary<int, double>>();

            switch (vector)
            {
                case 1:
                    data = LocalDataBase.getRemplissageByHourOuvres(start, end);
                    break;
                case 2:
                    data = LocalDataBase.getRemplissageByHourWE(start, end);
                    break;
                case 3:
                    data = LocalDataBase.getRemplissageByHalfHour(start, end);
                    break;
                case 4:
                    data = LocalDataBase.getRemplissageByDay(start, end);
                    break;
                case 5:
                    data = LocalDataBase.getVarianceByHour(start, end);
                    break;
                default:
                    data = LocalDataBase.getRemplissageByHour(start, end);
                    break;
            }
            Console.WriteLine("J'ai les donnees");
            Kmeans(data, cluster, distance, codage);
        }

        // Changement de cluster dans combo1
        private void changeCluster(object sender, EventArgs args)
        {
            //MessageBox.Show(this,"Selected : " + combo1.SelectedItem);
            chart = new StatsChartsVelib();
            //String s = combo1.SelectedItem as String;
            int selected = combo1.SelectedIndex;
            Chart myChart = null;
            Form frame = null;
            switch (selected)
            {
                case 0:
                    Dictionary<int, double[]> temp = new Dictionary<int, double[]>();
                    for (int i = 0; i < cluster.Count; i++)
                        temp.Add(i, cluster[i].ClusterMean);

                    myChart = chart.createChartAllCentroides(temp, "");
                    //myChart = chart.createChartAltitude( stationCluster, cluster.Count );
                    frame = new Form();
                    myChart.Dock = DockStyle.Fill;
                    frame.Text = "Cluster " + selected;
                    frame.Controls.Add(myChart);
                    frame.Show();
                    break;
                case 1:
                    myChart = chart.createChartAltitude(stationCluster, cluster.Count);
                    frame = new Form();
                    myChart.Dock = DockStyle.Fill;
                    frame.Text = "Cluster " + selected;
                    frame.Controls.Add(myChart);
                    frame.Show();
                    break;
                case 2:
                    myChart = chart.createChartPOIs(stationCluster, cluster.Count);
                    frame = new Form();
                    myChart.Dock = DockStyle.Fill;
                    frame.Text = "Cluster " + selected;
                    frame.Controls.Add(myChart);
                    frame.Show();
                    break;
                default:
                    myChart = chart.createChartCentroides(cluster[selected - 3].ClusterMean, selected - 3, "");
                    frame = new Form();
                    myChart.Dock = DockStyle.Fill;
                    frame.Text = "Cluster " + selected;
                    frame.Controls.Add(myChart);
                    frame.Show();
                    break;
            }
        }
        #endregion
    }
}
