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

namespace Ming.Atf.Pictures
{
    public partial class PingStatisticsCluster : UserControl
    {

        #region Champs
        /* Acces au TabDocker de la fenetre principale */
        Psl.Controls.TabDocker pages = Registry.MainPages;

        /* Acces au StatusReporter de la fenetre principale */
        Psl.Controls.StatusReporter status = Registry.MainStatus as Psl.Controls.StatusReporter;

        /**/
        TableLayoutPanel panel;
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
        #endregion

        #region Methodes
        // Cree le panel et ouvre la carte
        private void ouvrirMap()
        {
            if (pages.Contains(panel))
                return;

            panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.AutoSize = true;

            PictureBox PicBox = new PictureBox();
            URLtoImage toimage = new URLtoImage();
            String url = "http://maps.google.com/maps/api/staticmap?center=Paris,France&zoom=12&size=1900x1080";
            ArrayList res = LocalDataBase.getStationsDetails();
            
            for (int i = 0; i < 25; i++)
            {
                Dictionary<string, string> temp = res[i] as Dictionary<string, string>;
                url += "&markers=color:purple|label:V|" + temp["lat"] + "," + temp["lng"];
            }
            url += "&sensor=false";
            Image img = toimage.getImageFromURL(url);
            PicBox.Image = img;
            PicBox.SizeMode = PictureBoxSizeMode.Zoom;
            PicBox.Size = img.Size;
            //PicBox.Region.IsVisible();
            PicBox.Tag = System.IO.Path.GetFileName("Map");
            panel.Controls.Add(PicBox);

            pages.ClientAdd(panel, "Map", null, true);
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
