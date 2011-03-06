namespace Ming.Atf
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.applicationEvents = new Psl.Applications.ApplicationEvents(this.components);
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barreDoutilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tools = new Psl.Controls.ToolStripPanelEnh();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.status = new Psl.Controls.StatusReporter();
            this.actionList = new Psl.Actions.ActionList(this.components);
            this.acQuit = new Psl.Actions.Action(this.components);
            this.acShowTools = new Psl.Actions.Action(this.components);
            this.pages = new Psl.Controls.TabDocker();
            this.acToFile = new Psl.Actions.Action(this.components);
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menu.SuspendLayout();
            this.tools.SuspendLayout();
            this.toolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).BeginInit();
            this.SuspendLayout();
            // 
            // applicationEvents
            // 
            this.applicationEvents.ApplicationIdle += new System.EventHandler(this.applicationEvents_ApplicationIdle);
            this.applicationEvents.Archive += new Psl.Applications.ArchiverEventHandler(this.applicationEvents_Archive);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.editionToolStripMenuItem,
            this.affichageToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1046, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripMenuItem2});
            this.fichierToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.fichierToolStripMenuItem.MergeIndex = 1;
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "&Fichier";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.toolStripSeparator1.MergeIndex = 9998;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem2.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.toolStripMenuItem2.MergeIndex = 9999;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeyDisplayString = "";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem2.Text = "Quitter";
            this.toolStripMenuItem2.ToolTipText = "Quitter";
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barreDoutilsToolStripMenuItem});
            this.affichageToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.affichageToolStripMenuItem.MergeIndex = 10;
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.affichageToolStripMenuItem.Text = "&Affichage";
            // 
            // barreDoutilsToolStripMenuItem
            // 
            this.barreDoutilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.barreDoutilsToolStripMenuItem.Name = "barreDoutilsToolStripMenuItem";
            this.barreDoutilsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.barreDoutilsToolStripMenuItem.Text = "&Barres d\'outils";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.CheckOnClick = true;
            this.toolStripMenuItem3.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeyDisplayString = "";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem3.Text = "Fenêtre principale ";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "&?";
            // 
            // tools
            // 
            this.tools.Controls.Add(this.toolBar);
            this.tools.Dock = System.Windows.Forms.DockStyle.Top;
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.tools.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tools.Size = new System.Drawing.Size(1046, 25);
            // 
            // toolBar
            // 
            this.toolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolBar.Location = new System.Drawing.Point(3, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(58, 25);
            this.toolBar.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Quitter";
            this.toolStripButton1.ToolTipText = "Quitter";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 630);
            this.status.MinimumSize = new System.Drawing.Size(0, 25);
            this.status.Name = "status";
            this.status.ShowItemToolTips = true;
            this.status.Size = new System.Drawing.Size(1046, 25);
            // 
            // 
            // 
            this.status.StatusInfos.Size = new System.Drawing.Size(891, 20);
            this.status.StatusInfos.Spring = true;
            this.status.StatusInfos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 
            // 
            this.status.StatusLeft.AutoSize = false;
            this.status.StatusLeft.Size = new System.Drawing.Size(70, 20);
            // 
            // 
            // 
            this.status.StatusMiddle.AutoSize = false;
            this.status.StatusMiddle.Size = new System.Drawing.Size(70, 20);
            // 
            // 
            // 
            this.status.StatusProgress.AutoSize = false;
            this.status.StatusProgress.Margin = new System.Windows.Forms.Padding(4, 6, 1, 6);
            this.status.StatusProgress.Size = new System.Drawing.Size(80, 12);
            this.status.StatusProgress.Visible = false;
            // 
            // 
            // 
            this.status.StatusRight.Size = new System.Drawing.Size(4, 4);
            this.status.StatusRight.Visible = false;
            this.status.TabIndex = 2;
            this.status.Text = "statusReporter1";
            this.status.ZDisplayed.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status.StatusLeft,
            this.status.StatusMiddle,
            this.status.StatusRight,
            this.status.StatusInfos,
            this.status.StatusProgress});
            // 
            // actionList
            // 
            this.actionList.Actions.Add(this.acQuit);
            this.actionList.Actions.Add(this.acShowTools);
            this.actionList.Actions.Add(this.acToFile);
            // 
            // acQuit
            // 
            this.acQuit.Image = ((System.Drawing.Image)(resources.GetObject("acQuit.Image")));
            this.acQuit.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.acQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.acQuit.Targets.Add(this.toolStripMenuItem2);
            this.acQuit.Targets.Add(this.toolStripButton1);
            this.acQuit.Text = "Quitter";
            this.acQuit.ToolTipText = "Quitter";
            this.acQuit.Execute += new System.EventHandler(this.acQuit_Execute);
            // 
            // acShowTools
            // 
            this.acShowTools.CheckOnClick = true;
            this.acShowTools.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.acShowTools.Targets.Add(this.toolStripMenuItem3);
            this.acShowTools.Text = "Fenêtre principale ";
            // 
            // pages
            // 
            this.pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pages.ItemSize = new System.Drawing.Size(50, 21);
            this.pages.Location = new System.Drawing.Point(0, 49);
            this.pages.Name = "pages";
            this.pages.Padding = new System.Drawing.Point(4, 4);
            this.pages.ShowToolTips = true;
            this.pages.Size = new System.Drawing.Size(1046, 581);
            this.pages.TabIndex = 7;
            // 
            // acToFile
            // 
            this.acToFile.Image = global::Ming.Atf.Properties.Resources.save;
            this.acToFile.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.acToFile.Targets.Add(this.exporterToolStripMenuItem);
            this.acToFile.Targets.Add(this.toolStripButton2);
            this.acToFile.Text = "Exporter";
            this.acToFile.ToolTipText = "Exporter pour pour MatLab ou Octave";
            this.acToFile.Execute += new System.EventHandler(this.acToFile_Execute);
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exporterToolStripMenuItem});
            this.editionToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.editionToolStripMenuItem.MergeIndex = 5;
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editionToolStripMenuItem.Text = "Edition";
            // 
            // exporterToolStripMenuItem
            // 
            this.exporterToolStripMenuItem.Image = global::Ming.Atf.Properties.Resources.save;
            this.exporterToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.exporterToolStripMenuItem.Name = "exporterToolStripMenuItem";
            this.exporterToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.exporterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exporterToolStripMenuItem.Text = "Exporter";
            this.exporterToolStripMenuItem.ToolTipText = "Exporter pour pour MatLab ou Octave";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Ming.Atf.Properties.Resources.save;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Exporter";
            this.toolStripButton2.ToolTipText = "Exporter pour pour MatLab ou Octave";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 655);
            this.Controls.Add(this.pages);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.Text = "PING";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Psl.Applications.ApplicationEvents applicationEvents;
        private System.Windows.Forms.MenuStrip menu;
        private Psl.Controls.ToolStripPanelEnh tools;
        private System.Windows.Forms.ToolStrip toolBar;
        private Psl.Controls.StatusReporter status;
        private Psl.Actions.ActionList actionList;
        private Psl.Actions.Action acQuit;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barreDoutilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private Psl.Actions.Action acShowTools;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Psl.Controls.TabDocker pages;
        private Psl.Actions.Action acToFile;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

