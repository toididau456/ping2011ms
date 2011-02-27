using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Psl.Applications;

namespace Ming.Atf.Clustering
{
    public partial class PingClusteringCluster : UserControl
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
        public PingClusteringCluster()
        {
            InitializeComponent();
            Registry.MergeInMainMenu(this.menuStrip);
            Registry.MergeInMainTools(this.toolStrip);
        }


    }
}
