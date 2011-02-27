using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Psl.Applications;

namespace Ming.Atf.Clustering
{

    // Germe statique d'installation du plugin Xxx
    [PslPluginInstaller]
    class ClusteringPlugin
    {

        // Installation du plugin Xxx 
        public static void Install()
        {
            // ici : code d'installation du plugin
            PingClusteringCluster cluster = new PingClusteringCluster();
        }
    }
}