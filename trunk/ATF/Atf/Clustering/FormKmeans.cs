using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ming.Atf.Clustering
{
    public partial class FormKmeans : UserControl
    {
        public FormKmeans()
        {
            InitializeComponent();
        }

        // Acces au bouton d'execution
        public Button getExecuteButton()
        {
            return button1;
        }
    }
}
