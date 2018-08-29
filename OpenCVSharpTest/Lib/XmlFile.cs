using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ShimLib {
   // xml 파서
   public class XmlFile {
      // obj -> xml file
      public static void SaveObject(string filePath, object obj) {
         using (FileStream fs = File.Create(filePath)) {
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            ser.Serialize(fs, obj); 
         }
      }

      // xml file -> T object  
      public static T LoadObject<T>(string filePath) {
         using (FileStream fs = File.OpenRead(filePath)) {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            return (T)ser.Deserialize(fs);
         }
      }  
   }
}
