using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Collections;

namespace ShimLib {
   public class MesDataBase {
      // MES file to DataSet object
      // table = dataSet.Tables["table name"];
      // dataRow = table.Rows[idx];
      // data = dataRow["column name"];

      // MesFile => DataSet
      public static DataSet MesFileToDataSet(string filePath) {
         DataSet dataSet = new DataSet();                               // 데이터셋 생성
         DataTable table = null;
         string[] lines = File.ReadAllLines(filePath);                  // 파일 읽기
         foreach (var line in lines) {
            string[] words = line.Split(',');
            if (words[0].Trim() == "ITEM") {
               string tableName = words[1].Trim();
               table = new DataTable(tableName);                        // 테이블 생성
               dataSet.Tables.Add(table);                               // 테이블 추가
               foreach (var word in words) {
                  string columnName = word.Trim();
                  DataColumn col = new DataColumn(columnName);          // 컬럼 생성
                  table.Columns.Add(col);                               // 컬럼 추가
                  col.DefaultValue = new string(' ', word.Length);      // word size 보존
               }
            } else if (words[0].Trim() == "DATA") {
               if (table == null)
                  continue;
               DataRow row = table.NewRow();                            // 로우 생성
               table.Rows.Add(row);                                     // 로우 추가
               for (int i = 0; i < words.Length && i < table.Columns.Count; i++) {
                  row[i] = words[i].Trim();                             // 로우 아이템 value set
               }
            }
         }
         return dataSet;
      }

      // DataSet to MesFile
      public static void DateSetToMesFile(DataSet dataSet, string filePath) {
         List<string> lineList = new List<string>();

         string line;
         List<string> wordList = new List<string>();
         foreach (DataTable table in dataSet.Tables) {                                 // 테이블
            wordList.Clear();
            foreach (DataColumn column in table.Columns) {                             // 칼럼
               int wordSize = column.DefaultValue.ToString().Length;
               wordList.Add(column.ColumnName.PadRight(wordSize));
            }
            line = string.Join(",", wordList.ToArray());                               // line 생성
            lineList.Add(line);                                                        // line 리스트에 추가
            
            foreach (DataRow row in table.Rows) {                                      // 로우
               wordList.Clear();
               foreach (DataColumn column in table.Columns) {
                  int wordSize = column.DefaultValue.ToString().Length;
                  string word = row[column.ColumnName].ToString().PadRight(wordSize);  // 로우 아이템
                  wordList.Add(word);                                                  // 워드리스트에 추가
               }
               line = string.Join(",", wordList.ToArray());                            // line 생성
               lineList.Add(line);                                                     // line 리스트에 추가
            }
         }
         File.WriteAllLines(filePath, lineList.ToArray());                             // 파일 쓰기
      }
   }
}
