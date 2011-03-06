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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barresDoutilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.actionList = new Psl.Actions.ActionList(this.components);
            this.acOpenMap = new Psl.Actions.Action(this.components);
            this.acOpenScrollMap = new Psl.Actions.Action(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.applicationEvents = new Psl.Applications.ApplicationEvents(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acCloseCurrentTab = new Psl.Actions.Action(this.components);
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
            this.ouvrirMapToolStripMenuItem});
            this.fichierToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.fichierToolStripMenuItem.MergeIndex = 1;
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "&Fichier";
            // 
            // ouvrirMapToolStripMenuItem
            // 
            this.ouvrirMapToolStripMenuItem.Image = global::Ming.Atf.Pictures.Properties.Resources.maps;
            this.ouvrirMapToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ouvrirMapToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.ouvrirMapToolStripMenuItem.MergeIndex = 1;
            this.ouvrirMapToolStripMenuItem.Name = "ouvrirMapToolStripMenuItem";
            this.ouvrirMapToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.ouvrirMapToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ouvrirMapToolStripMenuItem.Text = "Afficher la carte";
            this.ouvrirMapToolStripMenuItem.ToolTipText = "Affiche la carte";
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.editionToolStripMenuItem.MergeIndex = 5;
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editionToolStripMenuItem.Text = "&Edition";
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barresDoutilsToolStripMenuItem});
            this.affichageToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.affichageToolStripMenuItem.MergeIndex = 10;
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.affichageToolStripMenuItem.Text = "&Affichage";
            // 
            // barresDoutilsToolStripMenuItem
            // 
            this.barresDoutilsToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.barresDoutilsToolStripMenuItem.Name = "barresDoutilsToolStripMenuItem";
            this.barresDoutilsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.barresDoutilsToolStripMenuItem.Text = "&Barres d\'outils";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(648, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Ming.Atf.Pictures.Properties.Resources.maps;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Afficher la carte";
            this.toolStripButton1.ToolTipText = "Affiche la carte";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Ming.Atf.Pictures.Properties.Resources.google_maps_icon;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Carte Scrollable";
            this.toolStripButton2.ToolTipText = "Carte modulaire";
            // 
            // actionList
            // 
            this.actionList.Actions.Add(this.acOpenMap);
            this.actionList.Actions.Add(this.acOpenScrollMap);
            this.actionList.Actions.Add(this.acCloseCurrentTab);
            // 
            // acOpenMap
            // 
            this.acOpenMap.Image = global::Ming.Atf.Pictures.Properties.Resources.maps;
            this.acOpenMap.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.acOpenMap.Targets.Add(this.toolStripButton1);
            this.acOpenMap.Targets.Add(this.ouvrirMapToolStripMenuItem);
            this.acOpenMap.Text = "Afficher la carte";
            this.acOpenMap.ToolTipText = "Affiche la carte";
            this.acOpenMap.Execute += new System.EventHandler(this.acOpenMap_Execute);
            // 
            // acOpenScrollMap
            // 
            this.acOpenScrollMap.Image = global::Ming.Atf.Pictures.Properties.Resources.google_maps_icon;
            this.acOpenScrollMap.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.acOpenScrollMap.Targets.Add(this.toolStripButton2);
            this.acOpenScrollMap.Text = "Carte Scrollable";
            this.acOpenScrollMap.ToolTipText = "Carte modulaire";
            this.acOpenScrollMap.Execute += new System.EventHandler(this.acOpenScrollMap_Execute);
            // 
            // openFileDialog
            // 
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
            this.fermerToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(199, 26);
            // 
            // fermerToolStripMenuItem
            // 
            this.fermerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
            this.fermerToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.fermerToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.fermerToolStripMenuItem.Text = "Fermer l\'onglet courant";
            this.fermerToolStripMenuItem.ToolTipText = "Fermer l\'onglet courant";
            // 
            // acCloseCurrentTab
            // 
            this.acCloseCurrentTab.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.acCloseCurrentTab.Targets.Add(this.fermerToolStripMenuItem);
            this.acCloseCurrentTab.Text = "Fermer l\'onglet courant";
            this.acCloseCurrentTab.ToolTipText = "Fermer l\'onglet courant";
            this.acCloseCurrentTab.Execute += new System.EventHandler(this.acCloseCurrentTab_Execute);
            // 
            // PingStatisticsCluster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Name = "PingStatisticsCluster";
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
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barresDoutilsToolStripMenuItem;
        private Psl.Applications.ApplicationEvents applicationEvents;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private Psl.Actions.Action acOpenMap;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem ouvrirMapToolStripMenuItem;
        private Psl.Actions.Action acOpenScrollMap;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private Psl.Actions.Action acCloseCurrentTab;
    }
}
