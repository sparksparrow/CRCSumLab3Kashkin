using CRCSumLab3Kashkin;
using NUnit.Framework;
using System.Collections.Generic;

namespace CRCUnitTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCRCVariant8_FromExample_Success()
        {
            IList<bool> message = new List<bool>() { 
                true, 
                true, 
                false, 
                true,
                false,
                true,
                true,
                false,
                true,
                true
            };//сообщение 1101011011
            int[] polynome = new int[] {0, 1, 4};
            IEnumerable<bool> expectedCRC = new bool[] {
                false,
                true,
                true,
                true,
                false
            };//CRC 01110

            CRCProcessor crcProcessor = new CRCProcessor(polynome);            
            var CRC = crcProcessor.GetCRC(message);

            Assert.AreEqual(expectedCRC, CRC);
        }
    }
}