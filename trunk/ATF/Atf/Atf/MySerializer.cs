using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
public static class MySerializer {


  public static void SerializeObject( string filename, object objectToSerialize ) {
    Stream stream = File.Open( filename, FileMode.Create );
    BinaryFormatter bFormatter = new BinaryFormatter();
    bFormatter.Serialize( stream, objectToSerialize );
    stream.Close();
  }

  public static object DeSerializeObject( string filename ){
    object objectToSerialize;
    Stream stream = File.Open( filename, FileMode.Open );
    BinaryFormatter bFormatter = new BinaryFormatter();
    objectToSerialize = (Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>) bFormatter.Deserialize( stream );
    stream.Close();
    return objectToSerialize;
  }

   /*
  public static Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> DeSerializeObject( string filename ) {
    Dictionary<int, Dictionary<int, KeyValuePair<double, double>>> objectToSerialize;
    Stream stream = File.Open( filename, FileMode.Open );
    BinaryFormatter bFormatter = new BinaryFormatter();
    objectToSerialize = (Dictionary<int, Dictionary<int, KeyValuePair<double, double>>>) bFormatter.Deserialize( stream );
    stream.Close();
    return objectToSerialize;
  }
    */ 
}
