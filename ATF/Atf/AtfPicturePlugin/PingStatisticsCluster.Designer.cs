namespace Ming.Atf.Pictures
{
    partial class PingStatisticsCluster
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PingStatisticsCluster));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerTousLesOngletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tournerDroiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tournerGaucheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barresDoutilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.actionList = new Psl.Actions.ActionList(this.components);
            this.chargerImage = new Psl.Actions.Action(this.components);
            this.detruireOngletCourant = new Psl.Actions.Action(this.components);
            this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acChangerImage = new Psl.Actions.Action(this.components);
            this.proutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerTousOnglets = new Psl.Actions.Action(this.components);
            this.fermerSaufCourant = new Psl.Actions.Action(this.components);
            this.tournerSensHoraire = new Psl.Actions.Action(this.components);
            this.tournerSensAntiHoraire = new Psl.Actions.Action(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.applicationEvents = new Psl.Applications.ApplicationEvents(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.editionToolStripMenuItem,
            this.affichageToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(648, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ouToolStripMenuItem,
            this.fermerTousLesOngletsToolStripMenuItem,
            this.toolStripMenuItem2});
            this.fichierToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.fichierToolStripMenuItem.MergeIndex = 1;
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fichierToolStripMenuItem.Text = "&Fichier";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem1.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.toolStripMenuItem1.MergeIndex = 10;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeyDisplayString = "";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.toolStripMenuItem1.Text = "Charger une image";
            this.toolStripMenuItem1.ToolTipText = "Charge une nouvelle image";
            // 
            // ouToolStripMenuItem
            // 
            this.ouToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ouToolStripMenuItem.Image")));
            this.ouToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ouToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.ouToolStripMenuItem.MergeIndex = 10;
            this.ouToolStripMenuItem.Name = "ouToolStripMenuItem";
            this.ouToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.ouToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.ouToolStripMenuItem.Text = "Detruire Onglet Courant";
            this.ouToolStripMenuItem.ToolTipText = "Detruit l\'onglet sélectionné";
            // 
            // fermerTousLesOngletsToolStripMenuItem
            // 
            this.fermerTousLesOngletsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fermerTousLesOngletsToolStripMenuItem.Image")));
            this.fermerTousLesOngletsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.fermerTousLesOngletsToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.fermerTousLesOngletsToolStripMenuItem.MergeIndex = 10;
            this.fermerTousLesOngletsToolStripMenuItem.Name = "fermerTousLesOngletsToolStripMenuItem";
            this.fermerTousLesOngletsToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.fermerTousLesOngletsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.fermerTousLesOngletsToolStripMenuItem.Text = "Fermer tous les onglets";
            this.fermerTousLesOngletsToolStripMenuItem.ToolTipText = "Ferme tous les onglets ouverts";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem2.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.toolStripMenuItem2.MergeIndex = 10;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeyDisplayString = "";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(209, 22);
            this.toolStripMenuItem2.Text = "Fermer tous sauf Courant";
            this.toolStripMenuItem2.ToolTipText = "Ferme tous les onglets sauf le courant";
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tournerDroiteToolStripMenuItem,
            this.tournerGaucheToolStripMenuItem});
            this.editionToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.editionToolStripMenuItem.MergeIndex = 5;
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.editionToolStripMenuItem.Text = "&Edition";
            // 
            // tournerDroiteToolStripMenuItem
            // 
            this.tournerDroiteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tournerDroiteToolStripMenuItem.Image")));
            this.tournerDroiteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tournerDroiteToolStripMenuItem.Name = "tournerDroiteToolStripMenuItem";
            this.tournerDroiteToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.tournerDroiteToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.tournerDroiteToolStripMenuItem.Text = "Tourner dans le sens horaire";
            this.tournerDroiteToolStripMenuItem.ToolTipText = "Tourne l\'image de 90°";
            // 
            // tournerGaucheToolStripMenuItem
            // 
            this.tournerGaucheToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tournerGaucheToolStripMenuItem.Image")));
            this.tournerGaucheToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tournerGaucheToolStripMenuItem.Name = "tournerGaucheToolStripMenuItem";
            this.tournerGaucheToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.tournerGaucheToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.tournerGaucheToolStripMenuItem.Text = "Tourner l\'image dans le sens anti-horaire";
            this.tournerGaucheToolStripMenuItem.ToolTipText = "Tourner l\'image de -90°";
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barresDoutilsToolStripMenuItem});
            this.affichageToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.affichageToolStripMenuItem.MergeIndex = 10;
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.affichageToolStripMenuItem.Text = "&Affichage";
            // 
            // barresDoutilsToolStripMenuItem
            // 
            this.barresDoutilsToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.barresDoutilsToolStripMenuItem.Name = "barresDoutilsToolStripMenuItem";
            this.barresDoutilsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.barresDoutilsToolStripMenuItem.Text = "&Barres d\'outils";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(648, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Charger une image";
            this.toolStripButton1.ToolTipText = "Charge une nouvelle image";
            // 
            // toolStripButton
            // 
            this.toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton.Image")));
            this.toolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton.Name = "toolStripButton";
            this.toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton.Text = "Detruire Onglet Courant";
            this.toolStripButton.ToolTipText = "Detruit l\'onglet sélectionné";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Fermer tous les onglets";
            this.toolStripButton2.ToolTipText = "Ferme tous les onglets ouverts";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Fermer tous sauf Courant";
            this.toolStripButton3.ToolTipText = "Ferme tous les onglets sauf le courant";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Tourner dans le sens horaire";
            this.toolStripButton4.ToolTipText = "Tourne l\'image de 90°";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Tourner l\'image dans le sens anti-horaire";
            this.toolStripButton5.ToolTipText = "Tourner l\'image de -90°";
            // 
            // actionList
            // 
            this.actionList.Actions.Add(this.chargerImage);
            this.actionList.Actions.Add(this.detruireOngletCourant);
            this.actionList.Actions.Add(this.acChangerImage);
            this.actionList.Actions.Add(this.fermerTousOnglets);
            this.actionList.Actions.Add(this.fermerSaufCourant);
            this.actionList.Actions.Add(this.tournerSensHoraire);
            this.actionList.Actions.Add(this.tournerSensAntiHoraire);
            // 
            // chargerImage
            // 
            this.chargerImage.Image = ((System.Drawing.Image)(resources.GetObject("chargerImage.Image")));
            this.chargerImage.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.chargerImage.Targets.Add(this.toolStripButton1);
            this.chargerImage.Targets.Add(this.toolStripMenuItem1);
            this.chargerImage.Text = "Charger une image";
            this.chargerImage.ToolTipText = "Charge une nouvelle image";
            this.chargerImage.Execute += new System.EventHandler(this.chargerImage_Execute);
            // 
            // detruireOngletCourant
            // 
            this.detruireOngletCourant.Image = ((System.Drawing.Image)(resources.GetObject("detruireOngletCourant.Image")));
            this.detruireOngletCourant.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.detruireOngletCourant.Targets.Add(this.toolStripButton);
            this.detruireOngletCourant.Targets.Add(this.ouToolStripMenuItem);
            this.detruireOngletCourant.Targets.Add(this.fermerToolStripMenuItem);
            this.detruireOngletCourant.Text = "Detruire Onglet Courant";
            this.detruireOngletCourant.ToolTipText = "Detruit l\'onglet sélectionné";
            this.detruireOngletCourant.Execute += new System.EventHandler(this.detruireOngletCourant_Execute);
            // 
            // fermerToolStripMenuItem
            // 
            this.fermerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fermerToolStripMenuItem.Image")));
            this.fermerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
            this.fermerToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.fermerToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.fermerToolStripMenuItem.Text = "Detruire Onglet Courant";
            this.fermerToolStripMenuItem.ToolTipText = "Detruit l\'onglet sélectionné";
            // 
            // acChangerImage
            // 
            this.acChangerImage.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.acChangerImage.Targets.Add(this.proutToolStripMenuItem);
            this.acChangerImage.Text = "Changer Image";
            this.acChangerImage.ToolTipText = "Changer l\'image de l\'onglet";
            this.acChangerImage.Execute += new System.EventHandler(this.acChangerImage_Execute);
            // 
            // proutToolStripMenuItem
            // 
            this.proutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.proutToolStripMenuItem.Name = "proutToolStripMenuItem";
            this.proutToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.proutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.proutToolStripMenuItem.Text = "Changer Image";
            this.proutToolStripMenuItem.ToolTipText = "Changer l\'image de l\'onglet";
            // 
            // fermerTousOnglets
            // 
            this.fermerTousOnglets.Image = ((System.Drawing.Image)(resources.GetObject("fermerTousOnglets.Image")));
            this.fermerTousOnglets.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.fermerTousOnglets.Targets.Add(this.fermerTousLesOngletsToolStripMenuItem);
            this.fermerTousOnglets.Targets.Add(this.toolStripButton2);
            this.fermerTousOnglets.Text = "Fermer tous les onglets";
            this.fermerTousOnglets.ToolTipText = "Ferme tous les onglets ouverts";
            this.fermerTousOnglets.Execute += new System.EventHandler(this.closeAllTabs_Execute);
            // 
            // fermerSaufCourant
            // 
            this.fermerSaufCourant.Image = ((System.Drawing.Image)(resources.GetObject("fermerSaufCourant.Image")));
            this.fermerSaufCourant.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.fermerSaufCourant.Targets.Add(this.toolStripButton3);
            this.fermerSaufCourant.Targets.Add(this.toolStripMenuItem2);
            this.fermerSaufCourant.Text = "Fermer tous sauf Courant";
            this.fermerSaufCourant.ToolTipText = "Ferme tous les onglets sauf le courant";
            this.fermerSaufCourant.Execute += new System.EventHandler(this.fermerSaufCourant_Execute);
            // 
            // tournerSensHoraire
            // 
            this.tournerSensHoraire.Image = ((System.Drawing.Image)(resources.GetObject("tournerSensHoraire.Image")));
            this.tournerSensHoraire.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tournerSensHoraire.Targets.Add(this.toolStripButton4);
            this.tournerSensHoraire.Targets.Add(this.tournerDroiteToolStripMenuItem);
            this.tournerSensHoraire.Text = "Tourner dans le sens horaire";
            this.tournerSensHoraire.ToolTipText = "Tourne l\'image de 90°";
            this.tournerSensHoraire.Execute += new System.EventHandler(this.tournerSensHoraire_Execute);
            // 
            // tournerSensAntiHoraire
            // 
            this.tournerSensAntiHoraire.Image = ((System.Drawing.Image)(resources.GetObject("tournerSensAntiHoraire.Image")));
            this.tournerSensAntiHoraire.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tournerSensAntiHoraire.Targets.Add(this.toolStripButton5);
            this.tournerSensAntiHoraire.Targets.Add(this.tournerGaucheToolStripMenuItem);
            this.tournerSensAntiHoraire.Text = "Tourner l\'image dans le sens anti-horaire";
            this.tournerSensAntiHoraire.ToolTipText = "Tourner l\'image de -90°";
            this.tournerSensAntiHoraire.Execute += new System.EventHandler(this.tournerSensAntiHoraire_Execute);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Fichiers JPG|*.jpg|Fichiers PNG|*.png|Tous les fichiers|*.*";
            this.openFileDialog.Multiselect = true;
            // 
            // applicationEvents
            // 
            this.applicationEvents.ApplicationClosing += new System.Windows.Forms.FormClosingEventHandler(this.applicationEvents_ApplicationClosing);
            this.applicationEvents.ApplicationIdle += new System.EventHandler(this.applicationEvents_ApplicationIdle);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fermerToolStripMenuItem,
            this.proutToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(202, 48);
            // 
            // AtfPicturesCluster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Name = "AtfPicturesCluster";
            this.Size = new System.Drawing.Size(648, 373);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private Psl.Actions.ActionList actionList;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Psl.Actions.Action chargerImage;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private Psl.Actions.Action detruireOngletCourant;
        private System.Windows.Forms.ToolStripButton toolStripButton;
        private System.Windows.Forms.ToolStripMenuItem ouToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barresDoutilsToolStripMenuItem;
        private Psl.Applications.ApplicationEvents applicationEvents;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem;
        private Psl.Actions.Action acChangerImage;
        private System.Windows.Forms.ToolStripMenuItem proutToolStripMenuItem;
        private Psl.Actions.Action fermerTousOnglets;
        private System.Windows.Forms.ToolStripMenuItem fermerTousLesOngletsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private Psl.Actions.Action fermerSaufCourant;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private Psl.Actions.Action tournerSensHoraire;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private Psl.Actions.Action tournerSensAntiHoraire;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tournerDroiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tournerGaucheToolStripMenuItem;
    }
}
