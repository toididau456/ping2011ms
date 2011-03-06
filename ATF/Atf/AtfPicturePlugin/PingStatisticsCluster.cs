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
using System.Globalization;
using System.Security.Permissions;
using System.Windows.Forms.DataVisualization.Charting;



namespace Ming.Atf.Pictures
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class PingStatisticsCluster : UserControl
    {

        #region Champs
        /* Acces au TabDocker de la fenetre principale */
        Psl.Controls.TabDocker pages = Registry.MainPages;

        /* Acces au StatusReporter de la fenetre principale */
        Psl.Controls.StatusReporter status = Registry.MainStatus as Psl.Controls.StatusReporter;

        /**/
        SplitContainer panel;

        #endregion

        // Constructeur
        public PingStatisticsCluster()
        {
            InitializeComponent();
            Registry.MergeInMainMenu(this.menuStrip);
            Registry.MergeInMainTools(this.toolStrip);
            Registry.MainPages.ContextMenuStrip = this.contextMenuStrip;
            Registry.MainPages.SelectedIndexChanged += changeStatus;

        }

        #region Actions
        // Ouvrir la carte
        private void acOpenMap_Execute(object sender, EventArgs e)
        {
            ouvrirMap();
        }

        // Ouvrir la carte scrollable
        private void acOpenScrollMap_Execute(object sender, EventArgs e)
        {
            ouvrirScrollMap();
        }

        // Fermer l'onglet courant
        private void acCloseCurrentTab_Execute(object sender, EventArgs e)
        {
            if(pages.TabCount > 0)
                pages.SelectedDockerClient.Dispose();
        }
        #endregion

        #region Methodes
        // Cree le panel et ouvre la carte
        private void ouvrirMap()
        {
            if (pages.Contains(panel))
                return;

            panel = new SplitContainer();
            panel.Dock = DockStyle.Fill;
            //panel.AutoSize = true;

            WebBrowser web = new WebBrowser();
            // La page doit contenir des morceaux propre a C# ^^
            web.Url = new Uri("http://undergroundprod1.free.fr/googlemap-velib/prototype/");

            // Very Important
            web.ObjectForScripting = this;
            web.Dock = DockStyle.Fill;
            web.AllowNavigation = false;
            web.ScriptErrorsSuppressed = true;
            panel.Panel1.Controls.Add(web);
            panel.Panel1MinSize = panel.Size.Width / 2;
            status.TextLeft = "Map";
            status.TextInfos = "Visualisation";
            pages.ClientAdd(panel, "Map", null, true);
        }

        // Cree un onglet avec la carte scrollable
        private void ouvrirScrollMap()
        {
            if (pages.TabCount >= 1)
                for (int i = 0; i < pages.TabCount; i++ )
                    if (pages.TabPages[i].Text.Equals("Carte Scrollable"))
                        return;

            ScrollableMaps mapScroll = new ScrollableMaps("staticmapbigRoad.png", true);
            /* if ( LocalDataBase.hour == null ) {
               LocalDataBase.hour = mapScroll.createDicoStationParHeure();
               LocalDataBase.day = mapScroll.createDicoStationParJour();
             }
             else {
               mapScroll.StatsTabHeure = LocalDataBase.hour;
               mapScroll.StatsTabJour = LocalDataBase.day;
             }
               */
            mapScroll.drawAllPoints();

            // Ici, tu decommentes pour ajouter un nouvel onglet
            pages.ClientAdd(mapScroll.mapBox, "Carte Scrollable", null, true);
        }

        // Test
        public void Test(string numStation)
        {
            StatsChartsVelib stats = new StatsChartsVelib(false);
            /*
             if ( LocalDataBase.hour.Count == null ) {
               LocalDataBase.hour = stats.StatsTabHeure;
               LocalDataBase.day = stats.StatsTabJour;
             }  */

            if (panel.Panel2.Controls.Count > 0)
                panel.Panel2.Controls[0].Dispose();
            panel.Panel2.Controls.Add(stats.initSplitPanel(int.Parse(numStation)));
        }
        #endregion

        #region Events

        /* Mets a jour la barre de status */
        private void changeStatus(object sender, EventArgs args)
        {
            doUpdateState();
        }

        /* Permet de rendre active (ou inactive) les actions*/
        private void applicationEvents_ApplicationIdle(object sender, EventArgs e)
        {
            doUpdateState();
        }

        /* Propose a l'utilisateur de confirmer la fermeture en cas d'onglet encore ouverts*/
        private void applicationEvents_ApplicationClosing(object sender, FormClosingEventArgs e)
        {
        }

        /* Mise a jour de divers elements */
        private void doUpdateState()
        {
            /* if (pages.TabCount < 1)
             {
                 status.TextRight = "";

                 for (int i = 0; i < this.actionList.Actions.Count(); i++)
                     if (this.actionList.Actions.ElementAt(i).Text != "Charger une image")
                         this.actionList.Actions.ElementAt(i).Enabled = false;
             }
             else
             {
                 for (int i = 0; i < this.actionList.Actions.Count(); i++)
                     this.actionList.Actions.ElementAt(i).Enabled = true;

                 status.TextRight = pages.SelectedDockerClient.Tag.ToString();
             }*/
        }
        #endregion
    }
}