using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Psl.Applications;

namespace Ming.Atf.Pictures
{

    // Germe statique d'installation du plugin Xxx
    [PslPluginInstaller]
    class PingStatisticsPlugin
    {

        // Installation du plugin Xxx 
        public static void Install()
        {
            // ici : code d'installation du plugin
            PingStatisticsCluster cluster = new PingStatisticsCluster();
          /// CACA PROUT TEST
        }
    }
}
