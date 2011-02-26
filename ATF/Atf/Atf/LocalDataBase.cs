using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.Odbc;

namespace Ming.Atf
{
    public static class LocalDataBase
    {
        #region Champs
        private static string MyConString = "DRIVER={MySQL ODBC 3.51 Driver};" +
                                     "SERVER=82.224.48.10;" +
                                     "DATABASE=velib;" +
                                     "UID=userCsharp;" +
                                     "PASSWORD=userPass11;" +
                                     "OPTION=3";

        private static string City = "";
        private static DateTime time = new DateTime(1970,1,1);
        #endregion

        #region Methodes

        // Retourne toutes les lignes valides de la base 
        public static Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> getAllLines(int i)
        {
            return sendRequest("select station , avg(available), variance(available) from donnees" + City + " where valid='1' group by station;" , i);
        }

        // Retourne toutes les lignes comprises entre start et end
        public static Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> getLinesByDateHours( DateTime start , DateTime end , int i )
        {
          if ( start.CompareTo(time) == 0 && end.CompareTo(time) == 0)
                return getAllLines(i);
            else if (start.CompareTo(time) == 0)
            return sendRequest( "select station , avg(available), variance(available) from donnees" + City + " where valid='1' and date <='" + convertToTimestamp( end ) + "' and hour='" + i + "' group by station;", i );
            else if (end.CompareTo(time) == 0)
            return sendRequest( "select station , avg(available), variance(available) from donnees" + City + " where valid='1' and date >='" + convertToTimestamp( start ) + "' and hour='" + i + "' group by station;", i );
            else
            return sendRequest( "select station , avg(available), variance(available) from donnees" + City + " where valid='1' and date >= '" + convertToTimestamp( start ) + "' and date <= '" + convertToTimestamp( end ) + "' and hour='" + i + "' group by station;", i );
        }

        // Retourne toutes les lignes comprises entre start et end
        public static Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> getLinesByDateDays(DateTime start, DateTime end, int i)
        {

            if (start.CompareTo(time) == 0 && end.CompareTo(time) == 0)
                return getAllLines(i);
            else if (start.CompareTo(time) == 0)
              return sendRequest( "select station , avg(available), variance(available) from donnees" + City + " where valid='1' and date <='" + convertToTimestamp( end ) + "' and day='" + i + "' group by station;", i );
            else if (end.CompareTo(time) == 0)
              return sendRequest( "select station , avg(available), variance(available) from donnees" + City + " where valid='1' and date >='" + convertToTimestamp( start ) + "' and day='" + i + "' group by station;", i );
            else
              return sendRequest( "select station , avg(available), variance(available) from donnees" + City + " where valid='1' and date >= '" + convertToTimestamp( start ) + "' and date <= '" + convertToTimestamp( end ) + "' and day='" + i + "' group by station;", i );
        }

        // Retourne toutes les lignes comprises entre start et end
        public static Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> getLinesByDateWeeks(DateTime start, DateTime end, int i)
        {  
          if (start.CompareTo(time) == 0 && end.CompareTo(time) == 0)
                return getAllLines(i);
            else if (start.CompareTo(time) == 0)
            return sendRequest( "select station , avg(available), variance(available) from donnees" + City + " where valid='1' and date <='" + convertToTimestamp( end ) + "' and week='" + i + "' group by station;", i );
            else if (end.CompareTo(time) == 0)
            return sendRequest( "select station , avg(available), variance(available) from donnees" + City + " where valid='1' and date >='" + convertToTimestamp( start ) + "' and week='" + i + "' group by station;", i );
            else
            return sendRequest( "select station , avg(available), variance(available) from donnees" + City + " where valid='1' and date >= '" + convertToTimestamp( start ) + "' and date <= '" + convertToTimestamp( end ) + "' and week='" + i + "' group by station;", i );
        }

        // Renvoie le details des stations
        public static ArrayList getStationsDetails()
        {
            ArrayList result = new ArrayList();
            try
            {
                //Connect to MySQL using MyODBC
                OdbcConnection MyConnection = new OdbcConnection(MyConString);
                MyConnection.Open();

                //Desc de la table donnees
                OdbcCommand MyCommand = new OdbcCommand("desc stations;", MyConnection);
                OdbcDataReader MyDataReader;
                MyDataReader = MyCommand.ExecuteReader();
                ArrayList header = new ArrayList();

                while (MyDataReader.Read())
                    if (string.Compare(MyConnection.Driver, "myodbc3.dll") == 0)
                        header.Add(MyDataReader.GetString(0)); //Supported only by MyODBC 3.5

                //Fetch
                MyCommand.CommandText = "select * from stations;";

                MyDataReader.Close();
                MyDataReader = MyCommand.ExecuteReader();

                Console.WriteLine("Executed : " + MyDataReader.RecordsAffected);
                
                while (MyDataReader.Read())
                {
                    Dictionary<string, string> temp = new Dictionary<string, string>();
                    if (string.Compare(MyConnection.Driver, "myodbc3.dll") == 0)
                        for (int i = 0; i < header.Count; i++)
                            if (MyDataReader.GetString(i) != "")
                                temp.Add(header[i] as string, MyDataReader.GetString(i));
                    result.Add(temp);
                }

                //Close all resources
                MyDataReader.Close();
                MyConnection.Close();
            }
            catch (OdbcException MyOdbcException)//Catch any ODBC exception ..
            {
                for (int i = 0; i < MyOdbcException.Errors.Count; i++)
                {
                    Console.Write("ERROR #" + i + "\n" +
                      "Message: " + MyOdbcException.Errors[i].Message + "\n" +
                      "Native: " + MyOdbcException.Errors[i].NativeError.ToString() + "\n" +
                      "Source: " + MyOdbcException.Errors[i].Source + "\n" +
                      "SQL: " + MyOdbcException.Errors[i].SQLState + "\n");
                }
            }

            return result;
        }

        // Effectue les requetes
        private static Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> sendRequest(String query, int select)
        {
            Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> result = new Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>();
            try
            {
                //Connect to MySQL using MyODBC
                OdbcConnection MyConnection = new OdbcConnection(MyConString);
                MyConnection.Open();

                Console.WriteLine("\n !!! success, connected successfully !!!\n");

                //Display connection information
                Console.WriteLine("Connection Information:");
                Console.WriteLine("\tConnection String:" + MyConnection.ConnectionString);
                Console.WriteLine("\tConnection Timeout:" + MyConnection.ConnectionTimeout);
                Console.WriteLine("\tDatabase:" + MyConnection.Database);
                Console.WriteLine("\tDataSource:" + MyConnection.DataSource);
                Console.WriteLine("\tDriver:" + MyConnection.Driver);
                Console.WriteLine("\tServerVersion:" + MyConnection.ServerVersion);

                //Desc de la table donnees
                OdbcCommand MyCommand = new OdbcCommand(query, MyConnection);
                OdbcDataReader MyDataReader;
                MyDataReader = MyCommand.ExecuteReader();

                Console.WriteLine("Executed : " + MyDataReader.RecordsAffected);
                while (MyDataReader.Read())
                {
                    KeyValuePair<double, double> temp1 = new KeyValuePair<double, double>(MyDataReader.GetDouble(1), MyDataReader.GetDouble(2));
                    Dictionary<int,KeyValuePair<double,double>> temp = new Dictionary<int , KeyValuePair<double,double>>();
                    temp[select] = temp1;
                    result[ MyDataReader.GetInt32( 0 ) ] = temp;
                    //result.Add(MyDataReader.GetInt32(0), temp);
                }

                //Close all resources
                MyDataReader.Close();
                MyConnection.Close();
            }
            catch (OdbcException MyOdbcException)//Catch any ODBC exception ..
            {
                for (int i = 0; i < MyOdbcException.Errors.Count; i++)
                {
                    Console.Write("ERROR #" + i + "\n" +
                      "Message: " + MyOdbcException.Errors[i].Message + "\n" +
                      "Native: " + MyOdbcException.Errors[i].NativeError.ToString() + "\n" +
                      "Source: " + MyOdbcException.Errors[i].Source + "\n" +
                      "SQL: " + MyOdbcException.Errors[i].SQLState + "\n");
                }
            }

            return result;
        }

        // Transforme une DateTime en Timestamp
        private static double convertToTimestamp(DateTime value)
        {
            TimeSpan span = (value - new DateTime(1970,1,1,0,0,0,0).ToLocalTime());
            return (double)span.TotalSeconds;
        }

        // Modifie la ville
        // Vide = Paris.
        // Le nom de la ville doit commencer par une MAJUSCULE
        public static void setCity(string _city)
        {
            City = _city;
        }
        #endregion
    }
}
