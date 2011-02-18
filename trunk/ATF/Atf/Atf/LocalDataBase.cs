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
        #endregion

        #region Methodes

        // Retourne toutes les lignes valides de la base 
        public static ArrayList getAll()
        {
            return request("select * from donnees where valid='1';");
        }

        // Retourne toutes les lignes valides de la base 
        public static ArrayList getStations(int numStation)
        {
            return request("select * from donnees where valid='1' and station='" + numStation + "';");
        }

        // Effectue les requetes
        private static ArrayList request(String query)
        {
            ArrayList result = new ArrayList();
            try
            {
                //Connect to MySQL using MyODBC
                OdbcConnection MyConnection = new OdbcConnection(MyConString);
                MyConnection.Open();

                OdbcCommand MyCommand = new OdbcCommand(query, MyConnection);
                OdbcDataReader MyDataReader;
                MyDataReader = MyCommand.ExecuteReader();
                Console.WriteLine("Executed : " + MyDataReader.RecordsAffected);
                while (MyDataReader.Read())
                {
                    String s = "";
                    if (string.Compare(MyConnection.Driver, "myodbc3.dll") == 0)
                    {
                        s = MyDataReader.GetString(1) + " " +
                                                    MyDataReader.GetString(2) + " " +
                                                    MyDataReader.GetString(3) + " " +
                                                    MyDataReader.GetString(4) + " " +
                                                    MyDataReader.GetString(5) + " " +
                                                    MyDataReader.GetString(6); //Supported only by MyODBC 3.51
                    }
                    else
                    {
                        s = "" + MyDataReader.GetString(1) + " " +
                                                    MyDataReader.GetString(2) + " " +
                                                    MyDataReader.GetString(3) + " " +
                                                    MyDataReader.GetString(4) + " " +
                                                    MyDataReader.GetString(5) + " " +
                                                    MyDataReader.GetString(6); //BIGINTs not supported by MyODBC
                    }

                    result.Add(s);
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

        #endregion
    }
}
