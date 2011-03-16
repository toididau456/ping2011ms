using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace Ming.Atf.Pictures
{
    public class ScrollableMaps
    {
     #region Champs
     public PictureBox mapBox;
     private Button typeButton;
     private Image map;
     private Boolean type = true;
     private ComboBox choiceTime;
     private Dictionary<int, KeyValuePair<double, double>> coordonnees;
     private Dictionary<int, String> dayToInt;
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
     private Graphics graphMap;
     //private Graphics graphBox;
     private List<string> colorList;

     
     private TrackBar trackBar ;
     private String echelle = "Heure";
#endregion

     #region Constructeur
     public ScrollableMaps(Boolean files) {
       HauteurGPS = Math.Abs( bordBas - bordHaut );
       LargeurGPS = Math.Abs( bordGauche - bordDroit );
       dayToInt = new Dictionary< int,String>();
       this.fillStationCoordonates();
       colorList = GetAllColors();
       dayToInt.Add(  1, "Monday");
       dayToInt.Add(  2, "Tuesday");
       dayToInt.Add(  3,"Wednesday" );
       dayToInt.Add(  4 ,"Thursday");
       dayToInt.Add(  5 ,"Friday");
       dayToInt.Add( 6, "Saturday" );
       dayToInt.Add(  7,"Sunday" );
       initPictureOfMap();
       createChoiceTimeList();
       createChangeTypeButton();
       DateTime time = new DateTime( 2025, 1, 1 );
       DateTime timeS = new DateTime( 1970, 1, 2 );
       if ( LocalDataBase.statsTabHeure == null ) {
         LocalDataBase.getRemplissageByDayHisto( timeS, time );
         LocalDataBase.getRemplissageByHourHisto( timeS, time );
         LocalDataBase.getRemplissageByHourOuvresHisto( timeS, time );
       }
       this.legend();
     }



     public ScrollableMaps() {
       HauteurGPS = Math.Abs( bordBas - bordHaut );
       LargeurGPS = Math.Abs( bordGauche - bordDroit );
       dayToInt = new Dictionary<int, String>();
       this.fillStationCoordonates();
       colorList = GetAllColors();
       dayToInt.Add( 1, "Monday" );
       dayToInt.Add( 2, "Tuesday" );
       dayToInt.Add( 3, "Wednesday" );
       dayToInt.Add( 4, "Thursday" );
       dayToInt.Add( 5, "Friday" );
       dayToInt.Add( 6, "Saturday" );
       dayToInt.Add( 7, "Sunday" );
       
       initPictureOfMap();
       
     }


#endregion

     #region Graphisme
     private void initPictureOfMap() {
        map = Properties.Resources.staticmapterrainBig;
        mapBox = new PictureBox();
        mapBox.Name = "ScrollMap";
        mapBox.SizeMode = PictureBoxSizeMode.Zoom;
        //mapBox.MouseClick += mapClicked;
        mapBox.Image = map;
        mapBox.MouseClick += ReloadMap;
        graphMap = Graphics.FromImage( map );
        mapBox.Padding = new Padding( 0 );
        mapBox.Margin = new Padding( 0 );  
      }


      public void drawAllPoints( String echelle, int cran ) {

        largeurPixel = map.Width;
        hauteurPixel = map.Height;
        Pen stylo = new Pen(Color.Black);
        stylo.Width = 1.0F;
        SolidBrush solidBrush  = new SolidBrush( Color.FromArgb(255,Color.Gray));

        //SolidBrush solidGradiant = new SolidBrush( Color.FromArgb( 0x7800FF00 ) );
        Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> datas;
        String label = "";
        KeyValuePair<int,int> tempCoor;
        if ( echelle == "Heure" ) {
          datas = LocalDataBase.statsTabHeure;
          label = cran + " heures";
        }
        else if ( echelle == "Jour" ) {
          datas = LocalDataBase.statsTabJour;
          cran++;
          label = dayToInt[cran];
          
        }
        else {
          datas = LocalDataBase.statsTabSemaine;
        }
       
        foreach(int station in coordonnees.Keys){
          double mean = datas[ station ][ cran ].Key;
          //MessageBox.Show( "VAL" + val );
          if ( mean < 0.33 ) {
               int val = (int) Math.Floor( (mean / 0.33) * 255 );
               solidBrush  = new SolidBrush( Color.FromArgb(val,Color.Yellow));

               
          }

          if ( mean > 0.33 && mean < 0.66) {
              int val = (int) Math.Floor( (mean / 0.66) * 255 ); 
              solidBrush  = new SolidBrush( Color.FromArgb(val,Color.Orange));
              
          }

          if ( mean > 0.66 && mean < 1 ) {
            int val = (int) Math.Floor( mean  * 255 );
               solidBrush  = new SolidBrush( Color.FromArgb(val,Color.Red));
              
          }

          if ( mean == 0.0 ) {
              solidBrush = new SolidBrush( Color.FromArgb( 255, Color.Black ) );
              }

            tempCoor = convertFromGPStoPixel( coordonnees[ station ] );

            graphMap.DrawEllipse( stylo, (float) tempCoor.Key, (float) tempCoor.Value, 10, 10 );
            
            graphMap.FillEllipse( solidBrush, (float) tempCoor.Key, (float) tempCoor.Value, 10.0F, 10.0F );
            
            solidBrush = new SolidBrush( Color.FromArgb( 255, Color.White ) );
            graphMap.FillRectangle( solidBrush,(cran * 55), 0,100,25 );
            
            solidBrush = new SolidBrush( Color.FromArgb( 255, Color.Black ) );
            graphMap.DrawString(label, new System.Drawing.Font( " Helvetica", 20 , System.Drawing.FontStyle.Bold ), solidBrush, (cran * 55), 0 );   
        }
        
      }


      public void drawClusters( Dictionary<int, int> clusters ) {
          
        largeurPixel = map.Width;
        hauteurPixel = map.Height;
        Pen stylo = new Pen( Color.Black );
        stylo.Width = 1.0F;
        SolidBrush solidBrush;
        
        KeyValuePair<int, int> tempCoor;


        foreach ( int station in clusters.Keys ) {
          solidBrush = new SolidBrush( Color.FromArgb( 255, Color.FromName(colorList[clusters[station]] )));
          tempCoor = convertFromGPStoPixel( coordonnees[ station ] );

          graphMap.DrawEllipse( stylo, (float) tempCoor.Key, (float) tempCoor.Value, 17, 17 );
          graphMap.FillEllipse( solidBrush, (float) tempCoor.Key, (float) tempCoor.Value, 17.0F, 17.0F );
          SolidBrush StringBrush = new SolidBrush( Color.FromArgb( 255, Color.Black ) );
          String clust = clusters[ station ].ToString();
          graphMap.DrawString(clust, new System.Drawing.Font( "Helvetica", 15, System.Drawing.FontStyle.Bold ), StringBrush, (float) tempCoor.Key, (float) tempCoor.Value );
          
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

      public TrackBar initTrackBar(){
        this.trackBar = new TrackBar();
        this.trackBar.Location = new System.Drawing.Point( 50, 200 );
        this.trackBar.Name = "Cran";
        this.trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
        this.trackBar.Size = new System.Drawing.Size( 45, 300 );
        this.trackBar.TabIndex = 1;
        this.trackBar.Maximum = 23;
        this.trackBar.ValueChanged += ReloadMap;        
        return trackBar;
      }

      private void changeType( object sender, EventArgs args ) {
        
        map.Dispose();
        graphMap.Dispose();
        if ( type ) {
          map = Properties.Resources.staticmapbigRoad;
        }
        else {
          map = Properties.Resources.staticmapterrainBig;
        }
        type = !type;
        mapBox.Image = map;
        graphMap = Graphics.FromImage( map );
        //this.drawAllPoints( echelle, trackBar.Value );
        //mapBox.Refresh();
      }

      private void ReloadMap( object sender, EventArgs args ) {        
        map.Dispose();
        graphMap.Dispose();
        //map = Properties.Resources.staticmapterrainBig;
        if ( !type ) {
          map = Properties.Resources.staticmapbigRoad;
        }
        else {
          map = Properties.Resources.staticmapterrainBig;
        }
        mapBox.Image = map;
        graphMap = Graphics.FromImage( map );
        this.drawAllPoints( echelle, trackBar.Value );
      }


      public Panel legend() {
        Panel panLegend = new Panel();
        panLegend.BackColor = Color.Transparent;
        panLegend.Location = new Point( 10, 10 );
        panLegend.Size = new Size( 200, 60 );
        panLegend.Paint +=new PaintEventHandler(panLegend_Paint);
        return panLegend;
      }

      public void panLegend_Paint( object sender, System.Windows.Forms.PaintEventArgs e ) {
        Graphics graphBox = e.Graphics;
        Pen stylo = new Pen( Color.Black );
        SolidBrush solidBrush = new SolidBrush( Color.FromArgb( 255, Color.Yellow ) );
        graphBox.DrawEllipse( stylo, 0, 5, 10, 10 );
        graphBox.FillEllipse( solidBrush, 0, 5, 10.0F, 10.0F );
        graphBox.DrawString( "Disponibilité [0 : 0.33] ", new System.Drawing.Font( " Helvetica", 10, System.Drawing.FontStyle.Bold ), solidBrush, 10, 5 );

        solidBrush = new SolidBrush( Color.FromArgb( 255, Color.Orange ) );
        graphBox.DrawEllipse( stylo, 0, 20, 10, 10 );
        graphBox.FillEllipse( solidBrush, 0,20, 10.0F, 10.0F );
        graphBox.DrawString( "Disponibilité [0.33 : 0.66] ", new System.Drawing.Font( " Helvetica", 10, System.Drawing.FontStyle.Bold ), solidBrush, 10, 20 );

        solidBrush = new SolidBrush( Color.FromArgb( 255, Color.Red ) );
        graphBox.DrawEllipse( stylo, 0, 35, 10, 10 );
        graphBox.FillEllipse( solidBrush, 0, 35, 10.0F, 10.0F );
        graphBox.DrawString( "Disponibilité [0.66 : 1.0] ", new System.Drawing.Font( " Helvetica", 10, System.Drawing.FontStyle.Bold ), solidBrush, 10, 35 );
      }


      public void createChoiceTimeList() {
        choiceTime = new ComboBox();
        this.choiceTime.Location = new System.Drawing.Point( 18, 140 );
        choiceTime.Items.Add( "Heure" );
        choiceTime.Items.Add( "Jour" );
        //listeRes.Items.Add("Semaine");
        choiceTime.SelectedIndexChanged += changeEchelle;
        mapBox.Controls.Add( choiceTime );
      }

      public void createChangeTypeButton() {
        typeButton = new Button();
        this.typeButton.Location = new System.Drawing.Point( 25, 530 );
        typeButton.Text = "Carte";
        typeButton.Click += changeType;
        mapBox.Controls.Add( typeButton );
      }

      private void changeEchelle( object sender, EventArgs args ) {
        
        if ( choiceTime.SelectedIndex == 0 ) {
          echelle = "Heure";
          trackBar.Maximum = 23;
        }
        else if ( choiceTime.SelectedIndex == 1 ) {
          echelle = "Jour";
          trackBar.Maximum = 6;
        }
        else {
          echelle = "Semaine";
        }
        trackBar.Refresh();
      }

      private void mapClicked( object sender, MouseEventArgs e) {
        Size size = mapBox.Size ;
        double diff = mapBox.Location.X;   
        //MessageBox.Show( size.Height + " " + size.Width + " " + e.X + "    " + e.Y );
        Pen stylo = new Pen( Color.Black );
        MessageBox.Show( "DIFF " + mapBox.DisplayRectangle.X + "  " + e.Y );
        //Graphics graphBox =mapBox.CreateGraphics();
        //graphBox.DrawEllipse( stylo, e.X-20, e.Y-20, 40, 40 );
        MessageBox.Show( "DIFF " + map.HorizontalResolution + "   " + graphMap.RenderingOrigin.Y );
      }

     #endregion

     #region  Datas
      private KeyValuePair<int, int> convertFromGPStoPixel( KeyValuePair<double, double> coorStationGps ) {
        double xgps = coorStationGps.Key;
        double ygps = coorStationGps.Value;
        double diffXGps = Math.Abs(origineImgGPSX - xgps);
        double diffYGps = Math.Abs(origineImgGPSY - ygps);
        double tempX = (diffXGps * largeurPixel) / LargeurGPS;
        double tempY = (diffYGps * hauteurPixel) / HauteurGPS;
        return new KeyValuePair<int,int>((int) tempX,(int) tempY);
      }


      
      #endregion

     #region Services

      public List<string> ColorList {
        get { return colorList; }
        set { colorList = value; }
      }


      private List<string> GetAllColors() {
       
        List<string> colors = new List<string>();
        /*colors.Add( "Blue" );
        colors.Add( "Red" );
        colors.Add( "DodgerBlue" );
        colors.Add( "Lime" );
        colors.Add( "YellowGreen" );
        colors.Add( "Fushia" );
        colors.Add( "Chartreuse" );
        colors.Add( "Brown" );
        colors.Add( "CadetBlue" );
        colors.Add( "Crimson" );
        colors.Add( "DarkOrange" );
        colors.Add( "DeepPink" );
        colors.Add( "DodgerBlue" );
        colors.Add( "Tomato" );
        colors.Add( "Gold" );
        colors.Add( "Green" );
        colors.Add( "Blue" );
        colors.Add( "Yellow" );
        
        colors.Add( "SteelBlue" );
                                 */
        colors.Add( "Red" );
        colors.Add( "RoyalBlue" );
        colors.Add( "Violet" );
        colors.Add( "ForestGreen" );
        colors.Add( "Yellow" );
        colors.Add( "Gray" );
        colors.Add( "Orange" );
        colors.Add( "DarkViolet" );
        colors.Add( "SlateBlue" );
        colors.Add( "White" );
        colors.Add( "HotPink" );
        colors.Add( "Sienna" );
        colors.Add( "Violet" );
        colors.Add( "LightGray" );
        colors.Add( "DarkTurquoise" );
        colors.Add( "Lime" );
        //colors.Add( "" );
        //colors.Add( "" );
        //colors.Add( "" );
        //colors.Add( "" );

        return colors;
      }


      #endregion


    }
}
