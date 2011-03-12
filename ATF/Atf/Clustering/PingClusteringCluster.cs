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

            cluster = KMeans.ClusterDataSet(clusters,db,type);
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
            map.SizeMode = PictureBoxSizeMode.Zoom;
            map.Dock = DockStyle.Fill;
            Panel tempPanel = new Panel();
            tempPanel.Dock = DockStyle.Fill;
            
            combo1 = new ComboBox();
            for (int i = 0; i < cluster.Count; i++)
                combo1.Items.Add(i);
            combo1.SelectedIndexChanged += changeCluster;
            combo1.Dock = DockStyle.Top;

            tempPanel.Controls.Add(combo1);
            tempPanel.Controls.Add(map);

            panel.addControls(tempPanel);
            /*chart = new StatsChartsVelib();
            SplitContainer tempPanel = new SplitContainer();
            tempPanel.Orientation = Orientation.Horizontal;
            Chart myChart = chart.createChartCentroides(cluster[0].ClusterMean, 0, "Dunno");
            tempPanel.Panel1.Controls.Add(myChart);
            combo1 = new ComboBox();

            for (int i = 0; i < cluster.Count; i++)
                combo1.Items.Add(i);
            combo1.SelectedIndexChanged += changeCluster;
            
            tempPanel.Panel2.Controls.Add(combo1);
            tempPanel.Dock = DockStyle.Fill;
            panel.addChart(tempPanel);*/
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

        // Changement de cluster
        private void changeCluster(object sender, EventArgs args)
        {
            //MessageBox.Show(this,"Selected : " + combo1.SelectedItem);
            chart = new StatsChartsVelib();
            //String s = combo1.SelectedItem as String;
            int selected = combo1.SelectedIndex;
            Chart myChart = chart.createChartCentroides(cluster[selected].ClusterMean, selected, "");
            Form frame = new Form();
            myChart.Dock = DockStyle.Fill;
            frame.Text = "Cluster " + selected;
            frame.Controls.Add(myChart);
            frame.Show();
        }
        #endregion
    }
}
