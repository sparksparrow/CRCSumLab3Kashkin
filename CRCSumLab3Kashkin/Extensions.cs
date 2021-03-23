using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRCSumLab3Kashkin
{
    static class Extensions
    {
        public static IEnumerable<bool> CutLeftZeros(this IEnumerable<bool> CRC)
        {
            return CRC.SkipWhile(x=>!x);          
        }
    }
}
