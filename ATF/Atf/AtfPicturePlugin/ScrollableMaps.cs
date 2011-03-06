using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace Ming.Atf.Pictures
{
    class ScrollableMaps
    {

     public PictureBox mapBox;
     private Image map;
     private Dictionary<int, KeyValuePair<double, double>> coordonnees;
     private Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> statsTabSemaine;
     private Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> statsTabHeure;
     private Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> statsTabJour;

     private int largeurPixel;
     private int hauteurPixel;
     private double bordDroit = 2.4757003784179688;
     private double bordGauche = 2.211170196533203;
     private double bordHaut = 48.914715793068105;
     private double bordBas = 48.80330206852624;
     private double HauteurGPS;
     private double LargeurGPS;
     private double origineImgGPSX = 2.211170196533203;
     private double origineImgGPSY = 48.914715793068105;
     private double correspondanceGpsPixelX;
     private double correspondanceGpsPixelY;
     private Graphics graphMap;

     public ScrollableMaps(String path,Boolean files) {
       map = Properties.Resources.staticmapterrainBig;
       
       HauteurGPS = Math.Abs( bordBas - bordHaut );
       LargeurGPS = Math.Abs( bordGauche - bordDroit );
       correspondanceGpsPixelX = LargeurGPS / largeurPixel;
       correspondanceGpsPixelY = HauteurGPS  / hauteurPixel;
       this.fillStationCoordonates();
       if ( files ) {
         statsTabHeure = (Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>) MySerializer.DeSerializeObject( "tabStationParHeure" );
         statsTabJour = (Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>) MySerializer.DeSerializeObject( "tabStationParJour" );
         //statsTabSemaine = (Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>) MySerializer.DeSerializeObject( "tabStationParSemaine" );
       }
       else {
         //statsTabSemaine = createDicoStationParSemaine();
         statsTabHeure = createDicoStationParHeure();
         statsTabJour = createDicoStationParJour();
       }
       initPictureOfMap();
     }

      private void initPictureOfMap() {
        mapBox = new PictureBox();
        mapBox.SizeMode = PictureBoxSizeMode.Zoom;

        mapBox.Image = map;
        
        graphMap =  Graphics.FromImage(map);
      }


      public void drawAllPoints() {
        //int echelle, int cran
        largeurPixel = map.Width;
        hauteurPixel = map.Height;
        MessageBox.Show("largeur"+ largeurPixel );
        MessageBox.Show( "hauteur" +hauteurPixel );
        Pen stylo = new Pen(Color.Tomato);
        stylo.Width = 4.0F;
        SolidBrush solidBrush = new SolidBrush( Color.FromArgb(120,Color.Red));
        //SolidBrush solidGradiant = new SolidBrush( Color.FromArgb( 0x7800FF00 ) );
        
        KeyValuePair<int,int> tempCoor;
        foreach(int station in coordonnees.Keys){
          
            tempCoor = convertFromGPStoPixel( coordonnees[ station ] );

            //graphMap.DrawEllipse( stylo, tempCoor.Key, tempCoor.Value,1,1 );
            //graphMap.FillEllipse( solidBrush, (float)tempCoor.Key, (float)tempCoor.Value, (float)1,(float) 1 );
            graphMap.FillEllipse( solidBrush, (float) tempCoor.Key, (float) tempCoor.Value, 10.0F, 10.0F );
          
          
        }
        
      }

      private void fillStationCoordonates(){
        coordonnees = new Dictionary<int, KeyValuePair<double, double>>();
        ArrayList donneesStation = LocalDataBase.getStationsDetails();
        Dictionary<String,String> tempLine ;
        for ( int i = 0 ; i < donneesStation.Count ; i++ ) {
          tempLine = (Dictionary<String,String>) donneesStation[i];
          coordonnees[int.Parse(tempLine[ "id" ])] = new KeyValuePair<double, double>( double.Parse(tempLine[ "lng" ].Replace(".",",")), double.Parse(tempLine[ "lat" ].Replace(".",",")));
        }
      }


      private KeyValuePair<int, int> convertFromGPStoPixel( KeyValuePair<double, double> coorStationGps ) {
        double xgps = coorStationGps.Key;
        double ygps = coorStationGps.Value;
        double diffXGps = Math.Abs(origineImgGPSX - xgps);
        double diffYGps = Math.Abs(origineImgGPSY - ygps);
        double tempX = (diffXGps * largeurPixel) / LargeurGPS;
        double tempY = (diffYGps * hauteurPixel) / HauteurGPS;
        return new KeyValuePair<int,int>((int) tempX,(int) tempY);
      }


      public Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> StatsTabSemaine {
        get { return statsTabSemaine; }
        set { statsTabSemaine = value; }
      }

      public Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> StatsTabHeure {
        get { return statsTabHeure; }
        set { statsTabHeure = value; }
      }


      public Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> StatsTabJour {
        get { return statsTabJour; }
        set { statsTabJour = value; }
      }


      public Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> createDicoStationParHeure() {
        Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> res = new Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>();
        DateTime time = new DateTime( 1970, 1, 1 );
        DateTime timeS = new DateTime( 1970, 1, 2 );
        Dictionary<int, KeyValuePair<double, double>> tempdico = null;
        for ( int k = 0 ; k < 24 ; k++ ) {
          Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> receivedData = LocalDataBase.getLinesByDateHours( timeS, time, k );
          foreach ( int station in receivedData.Keys ) {
            if ( k == 0 ) {
              tempdico = new Dictionary<int, KeyValuePair<double, double>>();
              tempdico[ k ] = new KeyValuePair<double, double>( receivedData[ station ][ k ].Key, receivedData[ station ][ k ].Value );
              res[ station ] = tempdico;
            }
            else {
              res[ station ][ k ] = new KeyValuePair<double, double>( receivedData[ station ][ k ].Key, receivedData[ station ][ k ].Value );
            }
          }
        }
        MySerializer.SerializeObject( "tabStationParHeure", res );
        return res;
      }

      public Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> createDicoStationParJour() {
        Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> res = new Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>();
        DateTime time = new DateTime( 1970, 1, 1 );
        DateTime timeS = new DateTime( 1970, 1, 2 );
        Dictionary<int, KeyValuePair<double, double>> tempdico = null;

        for ( int k = 1 ; k < 8 ; k++ ) {
          Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> receivedData = LocalDataBase.getLinesByDateDays( timeS, time, k );
          foreach ( int station in receivedData.Keys ) {
            if ( k == 1 ) {
              tempdico = new Dictionary<int, KeyValuePair<double, double>>();
              tempdico[ k ] = new KeyValuePair<double, double>( receivedData[ station ][ k ].Key, receivedData[ station ][ k ].Value );
              res[ station ] = tempdico;
            }
            else {
              res[ station ][ k ] = new KeyValuePair<double, double>( receivedData[ station ][ k ].Key, receivedData[ station ][ k ].Value );
            }
          }
        }
        MySerializer.SerializeObject( "tabStationParJour", res );
        return res;
      }



      public Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> createDicoStationParSemaine() {
        Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> res = new Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>();
        DateTime time = new DateTime( 1970, 1, 1 );
        DateTime timeS = new DateTime( 1970, 1, 2 );
        Dictionary<int, KeyValuePair<double, double>> tempdico = null;
        for ( int k = 0 ; k < 4 ; k++ ) {
          Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> receivedData = LocalDataBase.getLinesByDateWeeks( timeS, time, k );
          foreach ( int station in receivedData.Keys ) {
            if ( k == 0 ) {
              tempdico = new Dictionary<int, KeyValuePair<double, double>>();
              tempdico[ k ] = new KeyValuePair<double, double>( receivedData[ station ][ k ].Key, receivedData[ station ][ k ].Value );
              res[ station ] = tempdico;
            }
            else {
              res[ station ][ k ] = new KeyValuePair<double, double>( receivedData[ station ][ k ].Key, receivedData[ station ][ k ].Value );
            }
          }
        }
        MySerializer.SerializeObject( "tabStationParSemaine", res );
        return res;
      }



    }
}
