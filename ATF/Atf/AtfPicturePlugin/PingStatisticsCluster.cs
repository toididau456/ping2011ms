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

            /*PictureBox PicBox = new PictureBox();
            URLtoImage toimage = new URLtoImage();
            String url = "http://maps.google.com/maps/api/staticmap?center=48.857035,2.350988&zoom=12&size=650x650&sensor=false";
            ArrayList res = LocalDataBase.getStationsDetails();
            Image img = toimage.getImageFromURL(url);
            Bitmap imgRes = new Bitmap(img.Size.Width,img.Size.Height);
            Graphics g = Graphics.FromImage(imgRes);

            float facteurX = (float)img.Size.Width / (float)2;
            float facteurY = (float)img.Size.Height / (float)2;
            facteurX = (float)(48.857035) / facteurX;
            facteurY = (float)(2.350988) / facteurY;
            
            g.DrawImage(img, 0, 0);

            for (int i = 0; i < res.Count; i++)
            {
                Dictionary<string, string> temp = res[i] as Dictionary<string, string>;
                float lat = float.Parse(temp["lat"].Trim(), CultureInfo.InvariantCulture) / facteurX;
                float lng = float.Parse(temp["lng"].Trim(), CultureInfo.InvariantCulture) / facteurY;
                g.DrawString(i + "", new Font(this.Font, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(lat, lng));
            }
            g.Dispose();

            PicBox.Image = imgRes;
            PicBox.SizeMode = PictureBoxSizeMode.Zoom;
            PicBox.Size = img.Size;
            //PicBox.Region.IsVisible();
            PicBox.Tag = System.IO.Path.GetFileName("Map");
            */
            WebBrowser web = new WebBrowser();
            // La page doit contenir des morceaux propre a C# ^^
            web.Url = new Uri("http://undergroundprod1.free.fr/googlemap-velib/prototype/");

            // Fucking Important
            web.ObjectForScripting = this;
            //web.Size = new Size(650,650);
            web.Dock = DockStyle.Fill;
            panel.Controls.Add(web);

            pages.ClientAdd(panel, "Map", null, true);
        }

        // Test
        public void Test(string numStation)
        {
            MessageBox.Show(this, numStation);
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
