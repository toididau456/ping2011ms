using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ming.Atf.Pictures {
  class StatsChartsVelib {
    #region champs
    //private ArrayList dataVelib;
    private Dictionary<String, int> dayToInt;
    private Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> memberDataMap;
    private Dictionary<int, String> intToEchelle;
    private Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> statsTabStation;
    private Dictionary<int, KeyValuePair<double, double>> statsTabArrondissement;
    private Dictionary<int, KeyValuePair<double, double>> statsTabParis;
    private SplitContainer leftPanel;
    #endregion

    #region Constructeur
    /*
     * Constructeur
     */
    public StatsChartsVelib() {
      dayToInt = new Dictionary<String, int>();
      intToEchelle = new Dictionary<int, String>();
      intToEchelle.Add( 0, "Par Heures" );
      intToEchelle.Add( 1, "Par jour de la semaine" );
      intToEchelle.Add( 2, "Par semaines" );
      dayToInt.Add( "Monday", 0 );
      dayToInt.Add( "Tuesday", 1 );
      dayToInt.Add( "Wednesday", 2 );
      dayToInt.Add( "Thursday", 3 );
      dayToInt.Add( "Friday", 4 );
      dayToInt.Add( "Saturday", 5 );
      dayToInt.Add( "Sunday", 6 );
      statsTabStation =(Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>) MySerializer.DeSerializeObject( "tabdonneestation" );
      //statsTabArrondissement = (Dictionary<int, KeyValuePair<double, double>>) MySerializer.DeSerializeObject( "tabdonneeArron" );
      //statsTabParis = ( Dictionary<int, KeyValuePair<double, double>>) MySerializer.DeSerializeObject( "tabdonneeParis" );
    }

    #endregion

    #region méthodes

    public Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> createDicoStationParHeure() {
      Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> res = new Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>();
      DateTime time = new DateTime(1970,1,1);
      DateTime timeS = new DateTime( 1970, 1, 2 );
      Dictionary<int, KeyValuePair<double, double>> tempdico = null ;
      for ( int k = 0 ; k < 12 ; k++ ) {   
        Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> receivedData = LocalDataBase.getLinesByDateHours(timeS,time, k);
        foreach ( int station in receivedData.Keys ) {
         /* foreach ( int cledemerde in receivedData[ station ].Keys ) {
            MessageBox.Show( "cle = " + cledemerde + " ici ==>" + receivedData[ station ][ k ] );
          }  */
          if ( k == 0 ) {
            tempdico = new Dictionary<int, KeyValuePair<double, double>>();
            tempdico[ k ] = new KeyValuePair<double, double>( receivedData[ station ][ k ].Key, receivedData[ station ][ k ].Value );
            res[ station ] = tempdico;
           // MessageBox.Show(k + "  " + station + "   " +receivedData[ station ][ k ].Key );
          }
          else {
            res[ station ][ k ] = new KeyValuePair<double, double>( receivedData[ station ][ k ].Key, receivedData[ station ][ k ].Value );
          }
        }
      }
      MySerializer.SerializeObject( "tabdonnee", res );
      return res;
    }

    public Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> createDicoStationParJour() {
      Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> res = new Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>();
      DateTime time = new DateTime(1970,1,1);
      for ( int i = 0 ; i < 7 ; i++ ) {
        Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> receivedData = LocalDataBase.getLinesByDateDays( time, time, i );
        foreach ( int station in receivedData.Keys ) {
          res[ station ][ i ] = receivedData[ station ][ i ];
        }
      }
      return res;
    }

    public Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> createDicoStationParSemaine() {
      Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> res = new Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>();
      DateTime time = new DateTime( 1, 1, 1970 );
      for ( int i = 0 ; i < 7 ; i++ ) {
        Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> receivedData = LocalDataBase.getLinesByDateWeeks( time, time, i );
        foreach ( int station in receivedData.Keys ) {
          res[ station ][ i ] = receivedData[ station ][ i ];
        }
      }
      return res;
    }

    public Dictionary<int, KeyValuePair<double, double>> StatistiquesParis( Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> dataMap, int echelle = 0 ) {
      Dictionary<int, KeyValuePair<double, double>> res = new Dictionary<int, KeyValuePair<double, double>>();
      Dictionary<int, int> resCount = new Dictionary<int, int>();
      foreach ( int borne in dataMap.Keys ) {
        //Calculer la moyenne de dispo par heure sur toute la période de la dataMap
          foreach ( int temps in dataMap[ borne ].Keys ) {
            if ( res.ContainsKey( temps ) ) {
              KeyValuePair<double, double> kvp = new KeyValuePair<double, double>( res[ temps ].Key + dataMap[ borne ][ temps ].Key, res[ temps ].Value + dataMap[ borne ][ temps ].Value );
              res[ temps ] = kvp;
              resCount[ temps ] = resCount[temps] + 1;
            }
            else {
              KeyValuePair<double, double> kvp = new KeyValuePair<double, double>( dataMap[ borne ][ temps ].Key, dataMap[ borne ][ temps ].Value );
              res[ temps ] = kvp;
              resCount[ temps ] = 1;
            }
          }
        }

      foreach ( int cpt in resCount.Keys ) {
        res[ cpt ] = new KeyValuePair<double, double>( res[ cpt ].Key / resCount[cpt], res[ cpt ].Value / resCount[cpt] ); 
      }
      return res;
    }

    public Dictionary<int, KeyValuePair<double, double>> StatistiquesArrondissement( Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> dataMap, int Arrondissement, int echelle = 0 ) {
      Dictionary<int, KeyValuePair<double, double>> res = new Dictionary<int, KeyValuePair<double, double>>();
      Dictionary<int, int> resCount = new Dictionary<int, int>();
      foreach ( int borne in dataMap.Keys ) {
        //Calculer la moyenne de dispo par heure sur toute la période de la dataMap
        if ( convertStationToDistrict( borne ) == Arrondissement ) {
          foreach ( int temps in dataMap[ borne ].Keys ) {
            if ( res.ContainsKey( temps ) ) {
              KeyValuePair<double, double> kvp = new KeyValuePair<double, double>( res[ temps ].Key + dataMap[ borne ][ temps ].Key, res[ temps ].Value + dataMap[ borne ][ temps ].Value );
              res[ temps ] = kvp;
              resCount[ temps ] = resCount[ temps ] + 1;
            }
            else {
              KeyValuePair<double, double> kvp = new KeyValuePair<double, double>( dataMap[ borne ][ temps ].Key, dataMap[ borne ][ temps ].Value );
              res[ temps ] = kvp;
              resCount[ temps ] = 1;
            }
          }
        }
      }
      foreach ( int cpt in resCount.Keys ) {
        res[ cpt ] = new KeyValuePair<double, double>( res[ cpt ].Key / resCount[ cpt ], res[ cpt ].Value / resCount[ cpt ] );
      }
      MySerializer.SerializeObject( "tabdonneeArron", res );
       
      return res;
    }



    public Chart createChartStation( int station, int echelle, String type ) {
      //Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> statsTab = this.createDicoStationParHeure();
      Dictionary<int, KeyValuePair<double, double>> statsTab;
      if ( type == "Arrondissement" ) {
        statsTab = this.StatistiquesArrondissement( statsTabStation, convertStationToDistrict( station ) );
      }
      else if ( type == "Paris" ) {
        statsTab = this.statsTabParis;
      }
      else {
        statsTab = statsTabStation[station];
      }
      MessageBox.Show( type + " "+ convertStationToDistrict( station ) );
      Chart chartStat;
      ChartArea meanArea = new ChartArea();
      Series plusEcart = new Series("EcartType");
      //Series moinsEcart = new Series("EcartType - ");

      meanArea.AxisY.Title = "Moyenne disponibilité";
      meanArea.AxisX.Title = this.intToEchelle[ echelle ];
      meanArea.AxisX.TitleFont = new System.Drawing.Font( "Helvetica", 10, System.Drawing.FontStyle.Bold );
      meanArea.AxisY.TitleFont = new System.Drawing.Font( "Helvetica", 10, System.Drawing.FontStyle.Bold );
      meanArea.Name = "StatArea";
      meanArea.AxisX.MajorGrid.Enabled = false;
      Legend legendStat = new Legend();
      Series seriesStat = new Series( "Moyenne disponibilité " + this.intToEchelle[ echelle ] );



      chartStat = new System.Windows.Forms.DataVisualization.Charting.Chart();
      ((System.ComponentModel.ISupportInitialize) (chartStat)).BeginInit();
      
      
      foreach(int temps in statsTab.Keys){
        seriesStat.Points.AddXY(temps,statsTab[ temps ].Key );
        
      }
      foreach ( int temps in statsTabStation[ station ].Keys ) {
        double[] dataD = new double[] { statsTab[ temps ].Key ,statsTab[ temps ].Key - Math.Sqrt(statsTab[ temps ].Value), statsTab[ temps ].Key + Math.Sqrt(statsTab[ temps ].Value)};
        DataPoint point = new DataPoint(temps,dataD);
        plusEcart.Points.Add(point); 
      }

      /*foreach ( int temps in statsTab[ station ].Keys ) {
        moinsEcart.Points.AddXY( temps, statsTab[ station ][ temps ].Key - Math.Sqrt( statsTab[ station ][ temps ].Value ) );
      }   */

      seriesStat.Sort( PointSortOrder.Ascending, "X" );
      seriesStat.Color = System.Drawing.Color.Purple;
      plusEcart.Color = System.Drawing.Color.RoyalBlue;
      seriesStat.BorderWidth = 2;
      plusEcart.BorderWidth = 2;
      plusEcart.Sort( PointSortOrder.Ascending, "X" );
      //moinsEcart.Sort( PointSortOrder.Ascending, "X" );
      chartStat.Series.Add( seriesStat );
      chartStat.Series.Add( plusEcart );
      //chartStat.Series.Add( moinsEcart );

      chartStat.ChartAreas.Add( meanArea );
      chartStat.BackColor = System.Drawing.Color.Silver;
      meanArea.BackColor = System.Drawing.Color.LightGray;
      legendStat.Name = "legend";
      legendStat.DockedToChartArea = "StatArea";
      //legendStat.Alignment 
      Title titre;
      chartStat.Legends.Add( legendStat );
      if ( type == "Arrondissement" ) {
        titre = new Title( type + " " + convertStationToDistrict( station ));
      }
      else if ( type == "Paris" ) {
        titre = new Title( type + " " + convertStationToDistrict( station ) );
      }
      else {
        titre = new Title( type + " " +  station );
      }
      
      titre.Font = new System.Drawing.Font( "Helvetica", 10, System.Drawing.FontStyle.Bold );

      chartStat.Titles.Add( titre );
      chartStat.Size = new System.Drawing.Size( 500, 300 );
      seriesStat.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      plusEcart.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.ErrorBar;
      //moinsEcart.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

      ((System.ComponentModel.ISupportInitialize) (chartStat)).EndInit();

      return chartStat;

    }


    public SplitContainer initSplitPanel(int station) {
      SplitContainer resPanel = new SplitContainer();
      resPanel.Size = new System.Drawing.Size( 500, 800 );
      resPanel.Panel1.MinimumSize = new System.Drawing.Size( 500, 350 ); 
      resPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
      Panel top = creatLeftTopPanel( station );
      Panel bot = creatLeftBotPanel( station );
      resPanel.Panel1.Controls.Add( top );
      resPanel.Panel2.Controls.Add( bot );
      top.Padding = new Padding( 15 );
      bot.Padding = new Padding( 15 );
      return resPanel;
    }


    public Panel creatLeftTopPanel(int station) {
      Panel panTop = new Panel();
      panTop.BorderStyle = BorderStyle.FixedSingle;
      panTop.Size = new System.Drawing.Size( 500, 330 );
      Chart chartStation =  createChartStation( station, 0, "Station" );
      panTop.Controls.Add( chartStation );

      ComboBox choiceTime = createChoiceTimeList();
      ComboBox choiceGeo = createChoiceGeoList();
      panTop.Controls.Add( choiceTime );
      panTop.Controls.Add( choiceGeo );
      choiceTime.Location = new System.Drawing.Point( 5, 302 );
      choiceGeo.Location = new System.Drawing.Point( 130, 302 );
      return panTop;
    
    }


    public Panel creatLeftBotPanel( int station ) {
      Panel panBottom = new Panel();
      panBottom.Size = new System.Drawing.Size( 500, 330 );
      panBottom.BorderStyle = BorderStyle.FixedSingle;
      Chart chartStation = createChartStation( station, 0, "Arrondissement" );
      panBottom.Controls.Add( chartStation );

      ComboBox choiceTime = createChoiceTimeList();
      ComboBox choiceGeo = createChoiceGeoList();
      panBottom.Controls.Add( choiceTime );
      panBottom.Controls.Add( choiceGeo );
      choiceTime.Location = new System.Drawing.Point( 5, 302 );
      choiceGeo.Location = new System.Drawing.Point( 130, 302 );
      return panBottom;

    }


    public ComboBox createChoiceTimeList() {
      ComboBox listeRes = new ComboBox();
      listeRes.Items.Add("Heure");
      listeRes.Items.Add("Jour" );
      listeRes.Items.Add("Semaine");
      return listeRes;
    }


    public ComboBox createChoiceGeoList() {
      ComboBox listeRes = new ComboBox();
      listeRes.Items.Add( "Station" );
      listeRes.Items.Add( "Arrondissement" );
      listeRes.Items.Add( "Paris" );
      return listeRes;
    }


    #endregion

    #region méthodes de service
    /*
     * Convertion de timestamp en DateTime
     */
    private static DateTime ConvertFromUnixTimestamp( double timestamp ) {
      DateTime origin = new DateTime( 1970, 1, 1, 0, 0, 0, 0 );

      return origin.AddSeconds( timestamp );
    }

    /*
     * Converti un numéro de station en arrondissemen
     */
    private static int convertStationToDistrict( int station ) {
      int district = 0;
      String stration = station.ToString();
      int longueur = stration.Length;
      if ( longueur == 5 ) {
        stration = stration.Substring( 0, 2 );
      }
      if ( longueur == 4 ) {
        stration = stration.Substring( 0, 1 );
      }
      district = int.Parse( stration );
      return district;
    }

    #endregion
  }
}