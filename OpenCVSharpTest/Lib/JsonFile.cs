using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ShimLib {
   // json 파서
   public class JsonFile {
      // obj -> json file
      public static void SaveObject(string filePath, object obj) {
         using (FileStream fs = File.Create(filePath)) {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(obj.GetType());
            ser.WriteObject(fs, obj); 
         }
      }

      // json file -> T object  
      public static T LoadObject<T>(string filePath) {
         using (FileStream fs = File.OpenRead(filePath)) {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            return (T)ser.ReadObject(fs);
         }
      }
   }
}
