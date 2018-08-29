using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShimLib {
   public class Crc32 {
      private const uint CRC_TSIZE = 256U;
      private const uint CRC32_POLYNOMIAL = 0x04C11DB7U;
      private const uint CRC32_INIT = 0xFFFFFFFFU;
      
      private static readonly uint[] dwCRCTable = new uint[CRC_TSIZE];

      // CRC테이블 생성
      static Crc32() {
         uint CRC = 0;
         for (ushort wIndex = 0; wIndex < CRC_TSIZE; wIndex++) {
            CRC = wIndex;
            for (ushort wSize = 0; wSize < 8; wSize++) {
               if ((CRC & 1) != 0U) {
                  CRC >>= 1;
                  CRC ^= CRC32_POLYNOMIAL;
               } else {
                  CRC >>= 1;
               }
            }
            dwCRCTable[wIndex] = CRC;
         }
      }

      // CRC32 생성
      public static uint GetCRCT(byte[] pData, int iPointFrom, int iPointTo) {
         uint CRC = CRC32_INIT;
         byte Index = 0;

         for (int i = iPointFrom; i < iPointTo; i++) {
            Index = (byte)(pData[i] ^ CRC);
            CRC >>= 8;
            CRC ^= dwCRCTable[Index];
         }

         return CRC;
      }
   }
}
