using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace Ming.Atf.Pictures {
  class StatsChartsVelib {
    #region champs
    private ArrayList dataVelib;
    private Dictionary<String, int> dayToInt;
    private Dictionary<int, Dictionary<DateTime, KeyValuePair<int, double>>> memberDataMap;
    private Dictionary<int, String> intToEchelle;
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
    }

    #endregion

    #region méthodes

    public Dictionary<int, Dictionary<DateTime, KeyValuePair<int, double>>> createDicoStationParHeure( ArrayList receivedData ) {
      Dictionary<int, Dictionary<DateTime, KeyValuePair<int, double>>> res = new Dictionary<int, Dictionary<DateTime, KeyValuePair<int, double>>>();

      for ( int i = 0 ; i < receivedData.Count ; i++ ) {
        Dictionary<String, int> dico = (Dictionary<String, int>) receivedData[ i ];
        int station = dico[ "station" ];
        DateTime dateI = ConvertFromUnixTimestamp( dico[ "date" ] );
        if ( dico.ContainsKey( "available" ) ) {
          int available = dico[ "available" ];
          if ( res.ContainsKey( station ) ) {
            if ( res[ station ].ContainsKey( dateI ) ) {
              double toInsert = res[ station ][ dateI ].Value + available;
              int count = res[ station ][ dateI ].Key + 1;
              KeyValuePair<int, double> pairToAdd = new KeyValuePair<int, double>( count, toInsert );
              res[ station ][ dateI ] = pairToAdd;
            }
            else {
              KeyValuePair<int, double> pairToAdd = new KeyValuePair<int, double>( 1, available );
              res[ station ][ dateI ] = pairToAdd;
            }
          }
          else {
            KeyValuePair<int, double> pairToAdd = new KeyValuePair<int, double>( 1, available );
            Dictionary<DateTime, KeyValuePair<int, double>> temp = new Dictionary<DateTime, KeyValuePair<int, double>>();
            temp.Add( dateI, pairToAdd );
            res.Add( station, temp );
          }
        }
      }

      return res;
    }

    public Dictionary<int, double> StatistiquesParis( Dictionary<int, Dictionary<DateTime, KeyValuePair<int, double>>> dataMap, int echelle = 0 ) {
      Dictionary<int, double> res = new Dictionary<int, double>();
      Dictionary<int, int> div = new Dictionary<int, int>();
      foreach ( int borne in dataMap.Keys ) {
        //Calculer la moyenne de dispo par heure sur toute la période de la dataMap
        if ( echelle == 0 ) {
          foreach ( DateTime date in dataMap[ borne ].Keys ) {
            if ( res.ContainsKey( date.Hour ) ) {
              double toInsert = dataMap[ borne ][ date ].Value + res[ date.Hour ];
              res[ date.Hour ] = toInsert;
              div[ date.Hour ] = div[ date.Hour ] + dataMap[ borne ][ date ].Key;
            }
            else {
              res.Add( date.Hour, dataMap[ borne ][ date ].Value );
              div.Add( date.Hour, dataMap[ borne ][ date ].Key );
            }
          }
        }
        //Calculer la moyenne de dispo par jour de la semaine sur toute la période de la dataMap
        if ( echelle == 1 ) {
          foreach ( DateTime date in dataMap[ borne ].Keys ) {
            int dateInt = dayToInt[ date.DayOfWeek.ToString() ];
            if ( res.ContainsKey( dateInt ) ) {
              double toInsert = dataMap[ borne ][ date ].Value + res[ dateInt ];
              res[ dateInt ] = toInsert;
              div[ dateInt ] = div[ dateInt ] + dataMap[ borne ][ date ].Key;
            }
            else {
              res.Add( dateInt, dataMap[ borne ][ date ].Value );
              div.Add( dateInt, dataMap[ borne ][ date ].Key );
            }
          }
        }
      }

      //Calcul de la moyenne
      foreach ( int key in res.Keys ) {
        //res[ key ] = res[ key ] / div[ key ];
      }
      return res;
    }

    public Dictionary<int, double> StatistiquesArrondissement( Dictionary<int, Dictionary<DateTime, KeyValuePair<int, double>>> dataMap, int Arrondissement, int echelle = 0 ) {
      Dictionary<int, double> res = new Dictionary<int, double>();
      Dictionary<int, int> div = new Dictionary<int, int>();
      foreach ( int borne in dataMap.Keys ) {
        //Calculer la moyenne de dispo par heure sur toute la période de la dataMap
        if ( echelle == 0 ) {
          foreach ( DateTime date in dataMap[ borne ].Keys ) {
            if(convertStationToDistrict(borne) == Arrondissement){
              if ( res.ContainsKey( date.Hour ) ) {
                double toInsert = dataMap[ borne ][ date ].Value + res[ date.Hour ];
                res[ date.Hour ] = toInsert;
                div[ date.Hour ] = div[ date.Hour ] + dataMap[ borne ][ date ].Key;
              }
              else {
                res.Add( date.Hour, dataMap[ borne ][ date ].Value );
                div.Add( date.Hour, dataMap[ borne ][ date ].Key );
              }
            }
          }
        }
        //Calculer la moyenne de dispo par jour de la semaine sur toute la période de la dataMap
        if ( echelle == 1 ) {
          foreach ( DateTime date in dataMap[ borne ].Keys ) {
            if ( convertStationToDistrict( borne ) == Arrondissement ){
              int dateInt = dayToInt[ date.DayOfWeek.ToString() ];
              if ( res.ContainsKey( dateInt ) ) {
                double toInsert = dataMap[ borne ][ date ].Value + res[ dateInt ];
                res[ dateInt ] = toInsert;
                div[ dateInt ] = div[ dateInt ] + dataMap[ borne ][ date ].Key;
              }
              else {
                res.Add( dateInt, dataMap[ borne ][ date ].Value );
                div.Add( dateInt, dataMap[ borne ][ date ].Key );
              }
            }
          }
        }
      }

      //Calcul de la moyenne
      foreach ( int key in res.Keys ) {
        res[ key ] = res[ key ] / div[ key ];
      }
      return res;
    }

    public Dictionary<int, double> StatistiquesStation( Dictionary<int, Dictionary<DateTime, KeyValuePair<int, double>>> dataMap, int station, int echelle = 0 ) {
      Dictionary<int, double> res = new Dictionary<int, double>();
      Dictionary<int, int> div = new Dictionary<int, int>();
      foreach ( int borne in dataMap.Keys ) {
        //Calculer la moyenne de dispo par heure sur toute la période de la dataMap
        if ( echelle == 0 ) {
          foreach ( DateTime date in dataMap[ borne ].Keys ) {
            if ( borne == station ) {
              if ( res.ContainsKey( date.Hour ) ) {
                double toInsert = dataMap[ borne ][ date ].Value + res[ date.Hour ];
                res[ date.Hour ] = toInsert;
                div[ date.Hour ] = div[ date.Hour ] + dataMap[ borne ][ date ].Key;
              }
              else {
                res.Add( date.Hour, dataMap[ borne ][ date ].Value );
                div.Add( date.Hour, dataMap[ borne ][ date ].Key );
              }
            }
          }
        }
        //Calculer la moyenne de dispo par jour de la semaine sur toute la période de la dataMap
        if ( echelle == 1 ) {
          foreach ( DateTime date in dataMap[ borne ].Keys ) {
            if ( borne  == station ) {
              int dateInt = dayToInt[ date.DayOfWeek.ToString() ];
              if ( res.ContainsKey( dateInt ) ) {
                double toInsert = dataMap[ borne ][ date ].Value + res[ dateInt ];
                res[ dateInt ] = toInsert;
                div[ dateInt ] = div[ dateInt ] + dataMap[ borne ][ date ].Key;
              }
              else {
                res.Add( dateInt, dataMap[ borne ][ date ].Value );
                div.Add( dateInt, dataMap[ borne ][ date ].Key );
              }
            }
          }
        }
      }
       
      //Calcul de la moyenne
      foreach ( int cle in div.Keys ) {
        res[ cle ] = res[ cle ] / div[ cle ];
      }            
      return res;
    }
    
    public Chart createChartStation(int station,int echelle ){
      Dictionary<int, double> statsTab =  StatistiquesStation(memberDataMap,20020,echelle);
      Chart chartStat;
      ChartArea statArea = new ChartArea();
      statArea.AxisY.Title = "Moyenne disponibilité";
      statArea.AxisX.Title = this.intToEchelle[ echelle ];
      statArea.AxisX.TitleFont = new System.Drawing.Font( "Helvetica", 10, System.Drawing.FontStyle.Bold );
      statArea.AxisY.TitleFont = new System.Drawing.Font( "Helvetica", 10, System.Drawing.FontStyle.Bold );
      statArea.Name = "StatArea";
      Legend legendStat = new Legend();
      Series seriesStat = new Series("Moyenne disponibilité " + this.intToEchelle[echelle]);
      


      chartStat = new System.Windows.Forms.DataVisualization.Charting.Chart();
      ((System.ComponentModel.ISupportInitialize) (chartStat)).BeginInit(); 
      seriesStat.Points.DataBindXY(statsTab.Keys,statsTab.Values);
      seriesStat.Sort( PointSortOrder.Ascending, "X" ); 
      chartStat.Series.Add(seriesStat);
      chartStat.ChartAreas.Add(statArea);
      legendStat.Name ="legend";
      //legendStat.Alignment 
      
      chartStat.Legends.Add(legendStat);
      Title titre = new Title( "Station " + station);
      titre.Font = new System.Drawing.Font("Helvetica",10,System.Drawing.FontStyle.Bold);

      chartStat.Titles.Add(titre);
      chartStat.Size = new System.Drawing.Size( 600, 400 );
      seriesStat.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
      
      ((System.ComponentModel.ISupportInitialize) (chartStat)).EndInit();
      
      return chartStat;
      
    }
    
    

    public void setMemberDataMap(Dictionary<int, Dictionary<DateTime, KeyValuePair<int, double>>> arg){
      this.memberDataMap = arg;
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