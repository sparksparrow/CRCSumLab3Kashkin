using System;
using System.Collections.Generic;
using System.Linq;

namespace CRCSumLab3Kashkin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CRCProcessor crcProcessor = new CRCProcessor();
            IList<bool> binaryList = crcProcessor.GetRandomList();
            IEnumerable<bool> CRCList = crcProcessor.GetCRC(binaryList);
            CRCList.CutLeftZeros().ToList().ForEach(x=>Console.Write(Convert.ToByte(x))) ;
        }
    }
}
