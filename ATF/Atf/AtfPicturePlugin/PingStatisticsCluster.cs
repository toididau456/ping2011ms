using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Psl.Applications;

namespace Ming.Atf.Pictures
{
    public partial class PingStatisticsCluster : UserControl
    {
        public PingStatisticsCluster()
        {
            InitializeComponent();
            Registry.MergeInMainMenu(this.menuStrip);
            Registry.MergeInMainTools(this.toolStrip);
            Registry.MainPages.ContextMenuStrip = this.contextMenuStrip;
            Registry.MainPages.SelectedIndexChanged += changeStatus;
        }

        #region Champs
        /* Acces au TabDocker de la fenetre principale */
        Psl.Controls.TabDocker pages = Registry.MainPages;

        /* Acces au StatusReporter de la fenetre principale */
        Psl.Controls.StatusReporter status = Registry.MainStatus as Psl.Controls.StatusReporter;
        #endregion

        #region Actions
        private void chargerImage_Execute(object sender, EventArgs e)
        {
                chargerImages();
        }

        private void detruireOngletCourant_Execute(object sender, EventArgs e)
        {
            fermerOngletCourant();
        }

        private void acChangerImage_Execute(object sender, EventArgs e)
        {
            changerImage();
        }

        private void fermerSaufCourant_Execute(object sender, EventArgs e)
        {
            this.fermerTousSaufCourant();
        }

        private void closeAllTabs_Execute(object sender, EventArgs e)
        {
            fermerTous();
        }

        private void tournerSensHoraire_Execute(object sender, EventArgs e)
        {
            tournerImageCourante(1);
        }

        private void tournerSensAntiHoraire_Execute(object sender, EventArgs e)
        {
            tournerImageCourante(-1);
        }
        #endregion

        #region Methodes
        /* Changer l'image de l'onglet courant*/
        private void changerImage()
        {
            this.openFileDialog.Multiselect = false;

            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
                throw new ECancelled();

            /*PictureBox picture = pages.SelectedDockerClient as PictureBox;
            picture.Image = new Bitmap(this.openFileDialog.FileName);
            picture.Tag = System.IO.Path.GetFileName(this.openFileDialog.FileName);

            pages.SelectedDockerTab.Text = picture.Tag as string;
            this.openFileDialog.Multiselect = true;
            */
        }

        /* Ferme l'onglet courant */
        private void fermerOngletCourant()
        {
            /*PictureBox picture = pages.SelectedDockerClient as PictureBox;
            if (picture != null)
            {
                picture.Image.Dispose();
                picture.Dispose();
            }*/
        }

        /* Charge une ou plusieurs nouvelles images */
        private void chargerImages()
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
                throw new ECancelled();

            for (int i = 0; i < this.openFileDialog.FileNames.Length; i++)
            {
                ajouterImage(this.openFileDialog.FileNames[i]);
            }
        }

        /* Ajoute une image a pages*/
        private void ajouterImage(string name)
        {
            PictureBox PicBox = new PictureBox();
            PicBox.SizeMode = PictureBoxSizeMode.Zoom;
            PicBox.Image = new Bitmap(name);
            PicBox.Tag = System.IO.Path.GetFileName(name);
            PicBox.Dock = DockStyle.Fill;
            //pages.Controls.Add(PicBox);
            pages.ClientAdd(PicBox, PicBox.Tag.ToString(), null, true);
        }

        /* Fermer tous les onglets */
        private void fermerTous()
        {
            /*for (int i = pages.TabCount - 1; i >= 0; i--)
                fermerOngletCourant();
             */
        }

        /* Fermer tous sauf courant */
        private void fermerTousSaufCourant()
        {
            /*int position = pages.SelectedIndex;
            for (int i = pages.TabCount - 1; i >= 0; i--)
                if (i != position)
                {
                    pages.SelectTab(i);
                    fermerOngletCourant();
                }*/
        }

        /* Rotation de l'image*/
        private void tournerImageCourante(int sens)
        {
            /*PictureBox picture = pages.SelectedDockerClient as PictureBox;

            if (sens > 0)
            {
                picture.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else
                picture.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);

            pages.SelectedDockerClient.Refresh();*/
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
            /*if (pages.TabCount == 0) return;
            DialogResult result = MessageBox.Show(null, "Voulez vous réellement fermer l'application", "", MessageBoxButtons.YesNo);
            e.Cancel = result != DialogResult.Yes;*/
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
