﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;


namespace OpenCVSharpTest {
   // 확장 메서드 클래스
   public static class ExtensionMethods {
      public static T Range<T>(this T value, T min, T max) where T : IComparable {
         if (value.CompareTo(min as IComparable) < 0)
            return min;
         if (value.CompareTo(max as IComparable) > 0)
            return max;
         return value;
      }
   }
}
