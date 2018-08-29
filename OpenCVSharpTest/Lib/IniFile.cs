using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Net;

namespace ShimLib {
   /// <summary>
   /// *.ini 파일을 사용하기 위한 클래스
   /// </summary>
   public class IniFile {
      [DllImport("kernel32.dll")]
      private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
      [DllImport("kernel32.dll")]
      private static extern int WritePrivateProfileString(string section, string key, string val, string filePath);
      
      // 지원타입
      public static readonly Type[] supportedType = {
         typeof(bool), 
         typeof(char),
         typeof(sbyte),
         typeof(byte),
         typeof(short),
         typeof(ushort),
         typeof(int),
         typeof(uint),
         typeof(long),
         typeof(ulong),
         typeof(float),
         typeof(double),
         typeof(decimal),
         typeof(string),
         typeof(DateTime),
         typeof(Color),
         // and all enum types
      };

      private string iniPath;

      // 생성자
      public IniFile(string iniPath) {
         this.iniPath = iniPath;
         string iniDir = Path.GetDirectoryName(iniPath);
         if (Directory.Exists(iniDir) == false) {
            Directory.CreateDirectory(iniDir);
         }
      }

      // 값을 저장
      public void Write(string section, string key, object value) {
         if (value == null) {
            WritePrivateProfileString(section, key, string.Empty, this.iniPath);
            return;
         }

         Type type = value.GetType();

         TypeConverter tc = TypeDescriptor.GetConverter(type);
         string textValue;
         try {
            textValue = tc.ConvertToString(value);
         } catch {   // convert fail
            textValue = value.ToString();
         }
         WritePrivateProfileString(section, key, textValue, this.iniPath);
      }

      // 값을 읽음
      public object Read(string section, string key, object defValue) {
         if (defValue == null)
            return null;

         Type type = defValue.GetType();
         TypeConverter tc = TypeDescriptor.GetConverter(type);

         StringBuilder temp = new StringBuilder(255);
         
         string def = tc.ConvertToString(Convert.ChangeType(defValue, type));
         int i = GetPrivateProfileString(section, key, def, temp, 255, this.iniPath);
         string textValue = temp.ToString();

         try {
            return tc.ConvertFromString(textValue);
         } catch {   // convert fail
            return defValue;
         }
      }

      // Type 형식을 읽음
      private object ReadType(string section, string key, Type type) {
         TypeConverter tc = TypeDescriptor.GetConverter(type);

         StringBuilder temp = new StringBuilder(255);
         int i = GetPrivateProfileString(section, key, string.Empty, temp, 255, this.iniPath);
         string textValue = temp.ToString();
         
         try {
            return tc.ConvertFromString(textValue);
         } catch {   // convert fail
            return Activator.CreateInstance(type);
         }
      }

      // 클래스를 통째로 저장
      public static void SaveObject(string iniPath, object obj) {
         IniFile iniFile = new IniFile(iniPath);

         Type type = obj.GetType();

         PropertyDescriptorCollection pds = TypeDescriptor.GetProperties(type);
         PropertyInfo[] props = type.GetProperties();
         foreach (PropertyInfo prop in props) {
            string section = pds[prop.Name].Category;
            string key = prop.Name;
            Type propType = prop.PropertyType;
            if (!propType.IsArray) {
               object value = prop.GetValue(obj, null);
               iniFile.Write(section, key, value);
            } else {
               object value = prop.GetValue(obj, null);
               int arr_len = ((Array)value).Length;
               string arr_key = key+"_arr_len";
               iniFile.Write(section, arr_key, arr_len);
               for (int i = 0; i < arr_len; i++) {
                  object arr_val = ((Array)value).GetValue(i);
                  arr_key = key+"_arr_"+i.ToString();
                  iniFile.Write(section, arr_key, arr_val);
               }
            }
         }
      }

      // 클래스를 통째로 읽음
      public static void LoadObject(string iniPath, object obj) {
         IniFile iniFile = new IniFile(iniPath);

         Type type = obj.GetType();

         PropertyDescriptorCollection pds = TypeDescriptor.GetProperties(type);
         PropertyInfo[] props = type.GetProperties();
         foreach (PropertyInfo prop in props) {
            string section = pds[prop.Name].Category;
            string key = prop.Name;
            Type propType = prop.PropertyType;
            if (!propType.IsArray) {
               object value = iniFile.ReadType(section, key, prop.PropertyType);
               try { // value null
                  prop.SetValue(obj, value, null);
               } catch {}
            } else {
               string arr_key = key+"_arr_len";
               int arr_len = 0;
               try {
                  arr_len = (int)iniFile.ReadType(section, arr_key, typeof(int));
               } catch {}
               Type elementType = propType.GetElementType();
               Array arr = Array.CreateInstance(elementType, arr_len);
               for (int i = 0; i < arr_len; i++) {
                  arr_key = key+"_arr_"+i.ToString();
                  object arr_val = iniFile.ReadType(section, arr_key, elementType);
                  arr.SetValue(arr_val, i);
               }
               prop.SetValue(obj, arr, null);
            }
         }
      }
   }
}
